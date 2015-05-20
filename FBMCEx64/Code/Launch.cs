using System.Collections.Generic;
using Microsoft.MediaCenter.Hosting;
using System;
using Microsoft.MediaCenter;
using Microsoft.MediaCenter.Samples.MediaState;
using System.Threading;
using Facebook.API;
using Twitter;

namespace FBMCE
{
    public class MyAddIn : IAddInModule, IAddInEntryPoint
    {
        public const string AppName = "Status Application";

        private const string _fbAppId = "";
        private static FacebookAPI _fbApi;
        private static TwitterAPI _twitter;
        private static MediaState _mediaState;
        private static string _fbAccessToken = "";
        private static bool _statusHasBeenChanged;
        private Application _application;
        private AddInHost _host;
        private int _pollingInterval = 10000;
        private DateTime _twitterSuspendTime = DateTime.Now;

        public static bool disableTwitterNotifications;

        public static bool StatusHasBeenChanged
        {
            get { return _statusHasBeenChanged; }
            set { _statusHasBeenChanged = value; }
        }

        /// <summary>
        /// Gets the single MediaStatusState object associated with the application.
        /// </summary>
        public static MediaState MediaState
        {
            get { return _mediaState; }
        }

        public static FacebookAPI FbApi
        {
            get { return _fbApi; }
        }

        public static TwitterAPI TwitterApi
        {
            get { return _twitter; }
        }

        public static bool DebugEnabled { get; set; }

        public void Initialize(Dictionary<string, object> appInfo, Dictionary<string, object> entryPointInfo)
        {
            _mediaState = new MediaState();
            DebugEnabled = bool.Parse(CommonFunctions.GetSetting("Debug"));
        }

        public void Uninitialize()
        {
            if (bool.Parse(CommonFunctions.GetSetting("Service_Xml_ClearWhenNoMedia")))
            {
                _application.UpdateXml(new string[] { "", "", "", "0" });
            }

            _mediaState.Dispose();
        }

        public void Launch(AddInHost host)
        {
            _host = host;

            // Do not run this on extenders as extenders don't support MSAS
            if (_host.MediaCenterEnvironment.Capabilities.ContainsKey("Console"))
            {
                try
                {
                    // Initialize FB session
                    InitializeFacebook();

                    // Initialize Twitter session
                    InitializeTwitter();

                    // Connect must be done here and not in Initialize, else the events are not launched (if using MSASEventHandler)
                    // or _mediaState will always be null.
                    _mediaState.Connect();

                    _application = new Application(_host);

                    int.TryParse(CommonFunctions.GetSetting("PollingInterval"), out _pollingInterval);
                    
                    int twitterStatusUpdateQueryCounter = 0; // Used to ensure that Twitter friend updates are not queried more that 100 times per hour, which is the limit
                    int twitterStatusUpdateQueryCounterLimit = 3600000 / int.Parse(CommonFunctions.GetSetting("Service_Twitter_Friends_TimesPerHour")) / _pollingInterval;

                    while (true)
                    {
                        Sleep(_pollingInterval);

                        bool runApp = false;

                        // DoEvents must be done here, else _mediaState doesn't contain current states
                        System.Windows.Forms.Application.DoEvents();

                        if (bool.Parse(CommonFunctions.GetSetting("EventsEnabled_Service_Facebook")) && EventTimeEnabled("Service_Facebook_TimeEnabled"))
                        {
                            if (_fbApi != null && !string.IsNullOrEmpty(_fbApi.AccessToken))
                            {
                                runApp = true;
                            }
                        }

                        if ((bool.Parse(CommonFunctions.GetSetting("EventsEnabled_Service_Xml")) && EventTimeEnabled("Service_Xml_TimeEnabled")) ||
                            (bool.Parse(CommonFunctions.GetSetting("EventsEnabled_Service_Twitter")) && EventTimeEnabled("Service_Twitter_TimeEnabled")))
                        {
                            // If event is enabled and also allowed by time settings
                            runApp = true;
                        }

                        if (runApp)
                        {
                            runApp = false;
                            _application.Run();
                        }

                        if (!disableTwitterNotifications)
                        {
                            // For showing Twitter updates of friends
                            if (bool.Parse(CommonFunctions.GetSetting("EventsEnabled_Service_TwitterFriends")) && twitterStatusUpdateQueryCounter++ > twitterStatusUpdateQueryCounterLimit)
                            {
                                twitterStatusUpdateQueryCounter = 0;

                                // Check if Twitter suspend time has passed
                                if (DateTime.Now.CompareTo(_twitterSuspendTime) < 0) // returns greater than zero if current time is past suspend end time
                                {
                                    // Twitter update is still suspended, just get latest ID in order not to spam user with queued tweets after suspend period ends
                                    _twitter.UpdateLatestTwitterStatusId();
                                }
                                else if (!_twitter.UpdateLatestTwitterStatusChanges())
                                {
                                    _host.MediaCenterEnvironment.Dialog("Error getting Twitter updates, retrying later.", AppName, DialogButtons.Ok, 5, true);
                                }
                            }

                            if (bool.Parse(CommonFunctions.GetSetting("EventsEnabled_Service_TwitterFriends")))
                            {
                                ShowNextTwitterStatus();
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    _host.MediaCenterEnvironment.Dialog("Unable to launch, quitting. " + exc.ToString(), AppName, DialogButtons.Ok, 0, true);
                }
            }
        }

      

        /// <summary>
        /// Initialized Facebook session
        /// </summary>
        private void InitializeFacebook()
        {
            if (bool.Parse(CommonFunctions.GetSetting("EventsEnabled_Service_Facebook")))
            {
                _fbApi = new FacebookAPI
                {
                    IsDesktopApplication = true,
                    ApplicationKey = _fbAppId,
                };

                // If persistent session key was found, use it, else login
                if (!string.IsNullOrEmpty(_fbAccessToken = CommonFunctions.GetSetting("Facebook_AccessToken")) && !_fbAccessToken.Equals("false"))
                {
                    _fbApi.AccessToken = _fbAccessToken;

                    try
                    {
                        string uid = _fbApi.GetLoggedInUser();

                        // If uid was not found, session is invalid
                        if (string.IsNullOrEmpty(uid))
                        {
                            _fbApi.AccessToken = "";

                            CommonFunctions.SetSetting("Facebook_AccessToken", "");

                            FacebookLogin(false);
                        }
                    }
                    catch (Exception)
                    {
                        _fbApi.AccessToken = "";

                        CommonFunctions.SetSetting("Facebook_AccessToken", "");

                        FacebookLogin(false);
                    }
                }
                else
                {
                    FacebookLogin(false);
                }
            }
        }

        /// <summary>
        /// Initializes Twitter, including showing login screen
        /// </summary>
        private void InitializeTwitter()
        {
            if (bool.Parse(CommonFunctions.GetSetting("EventsEnabled_Service_Twitter")) || bool.Parse(CommonFunctions.GetSetting("EventsEnabled_Service_TwitterFriends")))
            {
                _twitter = new TwitterAPI();

                if (string.IsNullOrEmpty(CommonFunctions.GetSetting("Twitter_AccessToken")) || string.IsNullOrEmpty(CommonFunctions.GetSetting("Twitter_AccessTokenSecret")))
                {
                    // Show Twitter login screen
                    TwitterLoginScreen();
                }
                else
                {
                    if (!InitializeTwitterApi(CommonFunctions.GetSetting("Twitter_AccessToken"), CommonFunctions.GetSetting("Twitter_AccessTokenSecret")))
                    {
                        // Show Twitter login screen
                        TwitterLoginScreen();
                    }
                }

                // Get latest friend update status id
                if (bool.Parse(CommonFunctions.GetSetting("EventsEnabled_Service_TwitterFriends")) && !disableTwitterNotifications)
                {
                    if (!_twitter.UpdateLatestTwitterStatusId())
                    {
                        _host.MediaCenterEnvironment.Dialog("Error getting latest Twitter status ID, disabling Twitter friend status update notifications", AppName, DialogButtons.Ok, 10, true);
                        disableTwitterNotifications = true;
                    }
                }
            }
        }

        /// <summary>
        /// Sleeps the given interval but runs DoEvents every now and then
        /// </summary>
        /// <param name="pollingInterval">Sleep time in milliseconds</param>
        private void Sleep(int pollingInterval)
        {
            for (int i = 0; i < pollingInterval / 1000; i++)
            {
                Thread.Sleep(1000);

                // DoEvents must be done here, else _mediaState doesn't contain current states
                System.Windows.Forms.Application.DoEvents();
            }
        }

        /// <summary>
        /// Shows Twitter login screen
        /// </summary>
        private static void TwitterLoginScreen()
        {
            // Show Twitter login screen
            TwitterLogin twitterLogin = new TwitterLogin(_twitter);

            if (System.Windows.Forms.DialogResult.OK == twitterLogin.ShowDialog())
            {
                InitializeTwitterApi();
            }
            else
            {
                disableTwitterNotifications = true;
            }
        }

        /// <summary>
        /// Shows next Twitter status
        /// </summary>
        private void ShowNextTwitterStatus()
        {
            string[] twitterStatusString = _twitter.GetNextTwitterStatus();

            if (twitterStatusString != null)
            {
                int timeToShow = 5;

                // Show long tweets longer time
                if (twitterStatusString[1].Length > 100)
                {
                    timeToShow = 10;
                }

                // Show suspend tweets button if configured
                if (bool.Parse(CommonFunctions.GetSetting("Service_Twitter_EnableSuspend")))
                {
                    var buttons = new string[] { "OK", "Suspend" };

                    DialogClosedCallback dcc = new DialogClosedCallback(TwitterDialogClosed);
                    _host.MediaCenterEnvironment.Dialog(twitterStatusString[1], twitterStatusString[0] + " says", buttons, timeToShow, false, "", dcc);
                }
                else
                {
                    _host.MediaCenterEnvironment.Dialog(twitterStatusString[1], twitterStatusString[0] + " says", DialogButtons.Ok, timeToShow, false);
                }
            }
        }

        /// <summary>
        /// Handles Twitter dialog button press and suspends Twitter if Suspend was clicked
        /// </summary>
        /// <param name="result"></param>
        public void TwitterDialogClosed(DialogResult result)
        {
            // Suspend was pressed
            if ((int)result == 101)
            {
                InitTwitterSuspend();
            }
        }

        /// <summary>
        /// Sets the time when to re-enable showing Twitter updates
        /// </summary>
        private void InitTwitterSuspend()
        {
            // Immdiately clear all queued tweets
            _twitter.ClearStatusQueue();

            double suspendTime = 0;
            double.TryParse(CommonFunctions.GetSetting("Service_Twitter_SuspendTime"), out suspendTime);
            
            _twitterSuspendTime = DateTime.Now.AddMinutes(suspendTime);
        }

        /// <summary>
        /// Initializes Twitter API
        /// </summary>
        private static void InitializeTwitterApi()
        {
            if ((!string.IsNullOrEmpty(_twitter.oAuthTwitter.Token) && !string.IsNullOrEmpty(_twitter.oAuthTwitter.TokenSecret)))
            {
                _twitter.SetAllowedFriends(CommonFunctions.GetSetting("Service_Twitter_Friends"));
            }
        }

        /// <summary>
        /// Initializes Twitter API
        /// </summary>
        private static bool InitializeTwitterApi(string accessToken, string accessTokenSecret)
        {
            if (!string.IsNullOrEmpty(accessToken) && !string.IsNullOrEmpty(accessTokenSecret))
            {
                _twitter = new TwitterAPI(accessToken, accessTokenSecret);
            }

            if ((!string.IsNullOrEmpty(_twitter.oAuthTwitter.Token) && !string.IsNullOrEmpty(_twitter.oAuthTwitter.TokenSecret)))
            {
                // Verify that stored token and secret are still valid
                if (_twitter.VerifyCredentials())
                {
                    InitializeTwitterApi();

                    return true;
                }
                else
                {
                    // If stored token/secret are not valid, clear then from registry
                    CommonFunctions.SetSetting("Twitter_AccessToken", "");
                    CommonFunctions.SetSetting("Twitter_AccessTokenSecret", "");

                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether service is enabled based on registry start and end hour of day.
        /// </summary>
        /// <param name="key">Registry key containing time value when the specific service is enabled.</param>
        /// <returns>True if enabled</returns>
        private bool EventTimeEnabled(string key)
        {
            bool retVal = false;

            try
            {
                string timeSpan = CommonFunctions.GetSetting(key);

                if (string.IsNullOrEmpty(timeSpan))
                {
                    retVal = true;
                }
                else if (timeSpan.Contains("-"))
                {
                    string[] timeArr = timeSpan.Split('-');

                    int start, end;

                    if (int.TryParse(timeArr[0], out start) && int.TryParse(timeArr[1], out end))
                    {
                        int hour = DateTime.Now.Hour;

                        if (end < start)
                        {
                            if (hour >= start || hour < end)
                            {
                                retVal = true;
                            }
                        }
                        else
                        {
                            if (hour >= start && hour < end)
                            {
                                retVal = true;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                _host.MediaCenterEnvironment.Dialog("Error occurred in Event Time processing, please verify " + key, AppName,
                DialogButtons.Ok, 5, false);
            }

            return retVal;
        }

        /// <summary>
        /// Displays Facebook login dialog
        /// </summary>
        /// <param name="forceLogin">Force login</param>
        /// <returns>True if login succeeded, false if failed.</returns>
        private bool FacebookLogin(bool forceLogin)
        {
            bool retVal = false;

            try
            {
                // If connection to Facebook was successfull
                if (_fbApi.ConnectToFacebook(forceLogin))
                {
                    retVal = true;

                    if (!_fbApi.SessionExpires)
                    {
                        // If session doesn't expire and connect was successfull, store session info in settings file
                        try
                        {
                            CommonFunctions.SetSetting("Facebook_AccessToken", _fbApi.AccessToken);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            _host.MediaCenterEnvironment.Dialog("Offline access data could not be stored in registry. Check that you have permissions to registry.",
                                       AppName, DialogButtons.Ok, 10, false);
                        }
                    }
                }
                else
                {
                    _host.MediaCenterEnvironment.Dialog("Facebook login failed.", AppName, DialogButtons.Ok, 10, true);
                }
            }
            catch (Facebook.Exceptions.FacebookInvalidUserException)
            {
                _host.MediaCenterEnvironment.Dialog("Facebook login failed, invalid user.", AppName, DialogButtons.Ok, 10, true);
            }
            catch (Exception)
            {
                _host.MediaCenterEnvironment.Dialog("Error occurred while logging into Facebook.", AppName, DialogButtons.Ok, 10, true);
            }

            return retVal;
        }
    }
}