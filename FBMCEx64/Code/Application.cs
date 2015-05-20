using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.MediaCenter;
using Microsoft.MediaCenter.Hosting;
using Microsoft.MediaCenter.UI;
using System;
using System.Threading;
using System.Text;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Xml;
using Facebook.Types.Stream;
using FBMCE.Amazon;
using System.Web;

namespace FBMCE
{
    public class Application : ModelItem
    {
        private static Application _singleApplicationInstance;
        private AddInHost _host;
        private static Dictionary<MediaTypes, string> _previousMediaName =
            new Dictionary<MediaTypes, string>() 
            { 
                { MediaTypes.TV, "" }, 
                { MediaTypes.Video, "" }, 
                { MediaTypes.Pictures, "" }, 
                { MediaTypes.TVRecorded, "" },
                { MediaTypes.Music, "" },
                { MediaTypes.DVD, "" },
                { MediaTypes.TVRecording, "" }
            };
        private static string _previousStatus = "";

        enum MediaTypes
        {
            TV,
            Video,
            Pictures,
            TVRecorded,
            Music,
            DVD,
            TVRecording
        }

        public Application(AddInHost host)
        {
            this._host = host;
            _singleApplicationInstance = this;
        }

        public MediaCenterEnvironment MediaCenterEnvironment
        {
            get
            {
                if (_host == null) return null;
                return _host.MediaCenterEnvironment;
            }
        }

        public void Run()
        {
            string[] newStatus = { "", "", "", "0" };

            try
            {
                newStatus = GetMediaStatus();
            }
            catch (Exception)
            {
                ShowDialog("Unable to get current media status.", false, 2, DialogButtons.Ok);
            }

            try
            {
                // If current status is not empty, and not same as previously updated, and update bit is set
                if (!string.IsNullOrEmpty(newStatus[0]) && !_previousStatus.Equals(newStatus[0]) && newStatus[3].Equals("1"))
                {
                    ShowDebugDialog(newStatus[0]);
                    UpdateFacebook(newStatus);
                    UpdateTwitter(newStatus);
                }

                UpdateXml(newStatus);
            }
            catch (Exception e)
            {
                ShowDialog("Unable to update status. " + e.Message, false, 2, DialogButtons.Ok);
            }
        }

        /// <summary>
        /// Updates Facebook status
        /// </summary>
        /// <param name="newStatus"></param>
        private void UpdateFacebook(string[] newStatus)
        {
            if (bool.Parse(CommonFunctions.GetSetting("EventsEnabled_Service_Facebook")))
            {
                if (MyAddIn.FbApi != null && !string.IsNullOrEmpty(MyAddIn.FbApi.AccessToken))
                {
                    try
                    {
                        bool updateConfirmed = true;

                        // Confirm Facebook update from the user
                        if (bool.Parse(CommonFunctions.GetSetting("ConfirmUpdate_Facebook")))
                        {
                            DialogResult confirmUpdateResult = ShowDialog("Publish to Facebook: '" + newStatus[0] + "'?", true, 10, DialogButtons.Yes | DialogButtons.No);

                            // If update isn't confirmed or dialog times out, do not prompt for confirmation again
                            if (confirmUpdateResult == DialogResult.No || confirmUpdateResult == DialogResult.Timeout)
                            {
                                updateConfirmed = false;
                                _previousStatus = newStatus[0];
                            }
                        }

                        if (updateConfirmed)
                        {
                            try
                            {
                                attachment attachment = null;
                                bool streamEnabled = bool.Parse(CommonFunctions.GetSetting("Service_Facebook_StreamEnabled"));
                                bool statusEnabled = bool.Parse(CommonFunctions.GetSetting("Service_Facebook_StatusEnabled"));

                                if (streamEnabled)
                                {
                                    string amazonLocaleApiUrl = CommonFunctions.GetSetting("Service_All_AmazonLocaleUrl");

                                    // If Amazon queries are enabled for current media
                                    if (!string.IsNullOrEmpty(newStatus[1]))
                                    {
                                        string[] amazonDetails = { "", "", "", "", "", "", "" };
                                        // Title, DetailUrl, ImageUrl, Error, AverageRating, Artist

                                        amazonDetails = Query.SearchItems(newStatus[1], newStatus[2], amazonDetails, amazonLocaleApiUrl);

                                        // If ASIN exists, continue search
                                        if (!string.IsNullOrEmpty(amazonDetails[4]))
                                        {
                                            amazonDetails = Query.LookupItem(amazonDetails, amazonLocaleApiUrl);

                                            if (string.IsNullOrEmpty(amazonDetails[3]))
                                            {
                                                attachment = new attachment();

                                                // For videos/tv, show video/tv title as a link
                                                if (newStatus[2].Equals("Video") && newStatus[2].StartsWith("TV"))
                                                {
                                                    attachment.caption = "";
                                                    attachment.name = amazonDetails[0]; // Artist                                                    
                                                }
                                                else
                                                {
                                                    attachment.caption = amazonDetails[0]; // Album
                                                    attachment.name = amazonDetails[6]; // Artist                                                    
                                                }

                                                attachment.href = amazonDetails[1];
                                                attachment.description = null;
                                                attachment.properties = new attachment_property()
                                                {
                                                    category = null, /*new attachment_category()
                                                        {
                                                            href = "",
                                                            text = ""
                                                        }*/
                                                    ratings = !string.IsNullOrEmpty(amazonDetails[5]) ? amazonDetails[5] + " stars" : null
                                                };

                                                attachment.media = new List<attachment_media>(){new attachment_media_image()
                                                        {
                                                            src = amazonDetails[2],
                                                            href = amazonDetails[1]
                                                        }};
                                            }
                                        }
                                        else
                                        {
                                            attachment = null;
                                        }
                                    }
                                    else
                                    {
                                        attachment = null;
                                    }

                                    // Finally post to user's Wall and News feed
                                    if (!string.IsNullOrEmpty(MyAddIn.FbApi.StreamPublish(newStatus[0], attachment, null, "", 0)))
                                    {
                                        _previousStatus = newStatus[0];

                                        MyAddIn.StatusHasBeenChanged = true;
                                    }
                                }

                                if (statusEnabled)
                                {
                                    if (string.IsNullOrEmpty(MyAddIn.FbApi.SetStatus(newStatus[0], true)))
                                    {
                                        _previousStatus = newStatus[0];

                                        MyAddIn.StatusHasBeenChanged = true;
                                    }
                                }
                            }
                            catch (Facebook.Exceptions.FacebookSigningException)
                            {
                                MyAddIn.FbApi.AccessToken = "";
                                CommonFunctions.SetSetting("Facebook_AccessToken", "");

                                ShowDialog("Facebook session is invalid, opening login screen...", false, 2, DialogButtons.Ok);
                            }
                            catch (Facebook.Exceptions.FacebookTimeoutException)
                            {
                                MyAddIn.FbApi.AccessToken = "";
                                CommonFunctions.SetSetting("Facebook_AccessToken", "");

                                ShowDialog("Facebook session is invalid, opening login screen...", false, 2, DialogButtons.Ok);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        ShowDialog("Unable to publish to Facebook." + e.Message, false, 2, DialogButtons.Ok);
                    }
                }
            }
        }

        /// <summary>
        /// Outputs debug message
        /// </summary>
        /// <param name="newStatus"></param>
        public void ShowDebugDialog(string newStatus)
        {
            if (MyAddIn.DebugEnabled)
            {
                ShowDialog("DEBUG MODE\n" + newStatus, false, 5, DialogButtons.Ok);



            }
        }

        /// <summary>
        /// Updates Twitter status
        /// </summary>
        /// <param name="newStatus"></param>
        private void UpdateTwitter(string[] newStatus)
        {
            if (bool.Parse(CommonFunctions.GetSetting("EventsEnabled_Service_Twitter")) && !MyAddIn.disableTwitterNotifications)
            {
                try
                {
                    bool updateConfirmed = true;

                    // Confirm Twitter update from the user
                    if (bool.Parse(CommonFunctions.GetSetting("ConfirmUpdate_Twitter")))
                    {
                        DialogResult confirmUpdateResult = ShowDialog("Publish to Twitter: '" + newStatus[0] + "'?", true, 10, DialogButtons.Yes | DialogButtons.No);

                        if (confirmUpdateResult == DialogResult.No || confirmUpdateResult == DialogResult.Timeout)
                        {
                            updateConfirmed = false;
                            _previousStatus = newStatus[0];
                        }
                    }

                    if (updateConfirmed)
                    {
                        if (!MyAddIn.TwitterApi.SetStatus(newStatus[0]))
                        {
                            ShowDialog("Unable to publish to Twitter.", false, 2, DialogButtons.Ok);
                        }
                    }
                }
                catch (Exception e)
                {
                    ShowDialog("Unable to publish to Twitter. " + e.Message, false, 2, DialogButtons.Ok);
                }
                finally
                {
                    _previousStatus = newStatus[0];

                    MyAddIn.StatusHasBeenChanged = true;
                }
            }
        }

        /// <summary>
        /// Updates status to XML file
        /// </summary>
        /// <param name="newStatus"></param>
        public void UpdateXml(string[] newStatus)
        {
            if (bool.Parse(CommonFunctions.GetSetting("EventsEnabled_Service_Xml")))
            {

                if (string.IsNullOrEmpty(newStatus[0]) && bool.Parse(CommonFunctions.GetSetting("Service_Xml_ClearWhenNoMedia")))
                {
                    WriteXmlFile(new string[] { "", "", "", "0" });
                }
                else
                {
                    try
                    {
                        WriteXmlFile(newStatus);
                    }
                    catch (Exception e)
                    {
                        ShowDialog("Unable to save status XML file. " + e.Message, false, 2, DialogButtons.Ok);
                    }
                    finally
                    {
                        _previousStatus = newStatus[0];

                        MyAddIn.StatusHasBeenChanged = true;
                    }
                }
            }
        }

        private static void WriteXmlFile(string[] newStatus)
        {
            XmlDocument xmlDoc = new XmlDocument();
            StringBuilder xml = new StringBuilder("<status><value>");
            xml.Append(newStatus[0]);
            xml.Append("</value><media>");
            xml.Append(newStatus[1]);
            xml.Append("</media><mediatype>");
            xml.Append(newStatus[2]);
            xml.Append("</mediatype></status>");

            xmlDoc.LoadXml(xml.ToString());
            xmlDoc.Save(CommonFunctions.GetSetting("Service_Xml_File"));
        }

        private static attachment ConstructSimpleAttachment(string[] newStatus, attachment attachment, string amazonLocaleUrlAndTag)
        {
            // Only do simple attachment containing status
            attachment = new attachment();

            attachment.caption = null;
            attachment.name = newStatus[1];

            attachment.href = amazonLocaleUrlAndTag;

            if (!string.IsNullOrEmpty(amazonLocaleUrlAndTag))
            {
                attachment.href += "&url=search-alias%3Daps&field-keywords=" + HttpUtility.UrlEncode(newStatus[1]);
            }

            attachment.description = null;
            attachment.properties = new attachment_property()
            {
                category = null,
                ratings = null
            };

            attachment.media = null;

            return attachment;
        }

        /// <summary>
        /// Constructs the current media string that is set as status
        /// </summary>
        /// <returns></returns>
        private string[] GetMediaStatus()
        {
            string[] status = { "", "", "", "0" };
            string exclusion = "";

            #region TV Recording
            if (MyAddIn.MediaState.TVRecording.Active)
            {
                string tvRecording = MyAddIn.MediaState.TVRecording.MediaName;

                if (!string.IsNullOrEmpty(tvRecording) &&
                   !_previousMediaName[MediaTypes.TVRecording].Equals(tvRecording) &&
                   bool.Parse(CommonFunctions.GetSetting("EventsEnabled_RecordingTV")) &&
                   (string.IsNullOrEmpty(exclusion = CommonFunctions.GetSetting("Exclusion_RecordingTV_RegExp")) ||
                   (!string.IsNullOrEmpty(exclusion) && !Regex.IsMatch(tvRecording, exclusion))))
                {
                    status[0] = CommonFunctions.GetSetting("EventsConfig_RecordingTV_StatusString").Replace("%TITLE%", tvRecording);
                    _previousMediaName[MediaTypes.TVRecording] = tvRecording;

                    if (bool.Parse(CommonFunctions.GetSetting("EventsConfig_RecordingTV_QueryAmazon")))
                    {
                        status[1] = tvRecording;
                    }

                    status[2] = "Recording TV";
                    status[3] = "1";

                    return status;
                }
            }
            #endregion

            #region TV
            if (MyAddIn.MediaState.TV.Active)
            {
                string tv = MyAddIn.MediaState.TV.MediaName;

                if (!string.IsNullOrEmpty(tv) &&
                    !_previousMediaName[MediaTypes.TV].Equals(tv) &&
                    bool.Parse(CommonFunctions.GetSetting("EventsEnabled_TV")) &&
                    (string.IsNullOrEmpty(exclusion = CommonFunctions.GetSetting("Exclusion_TV_RegExp")) ||
                    (!string.IsNullOrEmpty(exclusion) && !Regex.IsMatch(tv, exclusion))))
                {
                    status[0] = CommonFunctions.GetSetting("EventsConfig_TV_StatusString").Replace("%TITLE%", tv);
                    _previousMediaName[MediaTypes.TV] = tv;

                    if (bool.Parse(CommonFunctions.GetSetting("EventsConfig_TV_QueryAmazon")))
                    {
                        status[1] = tv;
                    }

                    status[2] = "Live TV";
                    status[3] = "1";

                    return status;
                }
            }
            #endregion

            #region Recorded TV
            if (MyAddIn.MediaState.TVRecorded.Active)
            {
                string tvRecorded = MyAddIn.MediaState.TVRecorded.MediaName;

                if (!string.IsNullOrEmpty(tvRecorded) &&
                    !_previousMediaName[MediaTypes.TVRecorded].Equals(tvRecorded) &&
                    bool.Parse(CommonFunctions.GetSetting("EventsEnabled_RecordedTV")) &&
                    (string.IsNullOrEmpty(exclusion = CommonFunctions.GetSetting("Exclusion_RecordedTV_RegExp")) ||
                    (!string.IsNullOrEmpty(exclusion) && !Regex.IsMatch(tvRecorded, exclusion))))
                {
                    status[0] = CommonFunctions.GetSetting("EventsConfig_RecordedTV_StatusString").Replace("%TITLE%", tvRecorded);
                    _previousMediaName[MediaTypes.TVRecorded] = tvRecorded;

                    if (bool.Parse(CommonFunctions.GetSetting("EventsConfig_RecordedTV_QueryAmazon")))
                    {
                        status[1] = tvRecorded;
                    }

                    status[2] = "Recorded TV";
                    status[3] = "1";

                    return status;
                }
            }
            #endregion

            #region Video
            if (MyAddIn.MediaState.Video.Active)
            {
                string video = MyAddIn.MediaState.Video.MediaName;

                if (!string.IsNullOrEmpty(video) &&
                    !_previousMediaName[MediaTypes.Video].Equals(video) &&
                    bool.Parse(CommonFunctions.GetSetting("EventsEnabled_Video")) &&
                    (string.IsNullOrEmpty(exclusion = CommonFunctions.GetSetting("Exclusion_Video_RegExp")) ||
                    (!string.IsNullOrEmpty(exclusion) && !Regex.IsMatch(video, exclusion)
                    )))
                {
                    status[3] = "1";
                }

                status[0] = CommonFunctions.GetSetting("EventsConfig_Video_StatusString").Replace("%TITLE%", video);
                _previousMediaName[MediaTypes.Video] = video;

                if (bool.Parse(CommonFunctions.GetSetting("EventsConfig_Video_QueryAmazon")))
                {
                    status[1] = video;
                }

                status[2] = "DVD";

                return status;
            }
            #endregion

            #region Pictures
            if (MyAddIn.MediaState.Pictures.Active)
            {
                string picture = MyAddIn.MediaState.Pictures.CurrentPicture;

                if (!string.IsNullOrEmpty(picture) &&
                    !_previousMediaName[MediaTypes.Pictures].Equals(picture) &&
                    bool.Parse(CommonFunctions.GetSetting("EventsEnabled_Pictures")))
                {
                    status[0] = CommonFunctions.GetSetting("EventsConfig_Pictures_StatusString").Replace("%TITLE%", picture);
                    _previousMediaName[MediaTypes.Pictures] = picture;

                    status[2] = "Pictures";
                    status[3] = "1";

                    return status;
                }
            }
            #endregion

            #region DVD
            if (MyAddIn.MediaState.DVD.Active)
            {
                string dvd = MyAddIn.MediaState.DVD.MediaName;

                if (!string.IsNullOrEmpty(dvd) &&
                    !_previousMediaName[MediaTypes.DVD].Equals(dvd) &&
                    bool.Parse(CommonFunctions.GetSetting("EventsEnabled_DVD")) &&
                    (string.IsNullOrEmpty(exclusion = CommonFunctions.GetSetting("Exclusion_DVD_RegExp")) ||
                    (!string.IsNullOrEmpty(exclusion) && !Regex.IsMatch(dvd, exclusion))))
                {
                    status[0] = CommonFunctions.GetSetting("EventsConfig_DVD_StatusString").Replace("%TITLE%", dvd);
                    _previousMediaName[MediaTypes.DVD] = dvd;

                    if (bool.Parse(CommonFunctions.GetSetting("EventsConfig_DVD_QueryAmazon")))
                    {
                        status[1] = dvd;
                    }

                    status[2] = "DVD";
                    status[3] = "1";

                    return status;
                }
            }
            #endregion

            #region Music
            if (MyAddIn.MediaState.Music.Active)
            {
                string music = MyAddIn.MediaState.Music.ArtistName + " - ";

                // Determine whether to append track or album name
                if (bool.Parse(CommonFunctions.GetSetting("EventsConfig_Music_AlbumMode")))
                {
                    music += MyAddIn.MediaState.Music.MediaName;
                }
                else
                {
                    music += MyAddIn.MediaState.Music.TrackName;
                }

                if (!music.Equals(" - ") &&
                    !_previousMediaName[MediaTypes.Music].Equals(music) &&
                    bool.Parse(CommonFunctions.GetSetting("EventsEnabled_Music")) &&
                    (string.IsNullOrEmpty(exclusion = CommonFunctions.GetSetting("Exclusion_Music_RegExp")) ||
                    (!string.IsNullOrEmpty(exclusion) && !Regex.IsMatch(music, exclusion))))
                {
                    status[0] = CommonFunctions.GetSetting("EventsConfig_Music_StatusString").Replace("%TITLE%", music);
                    _previousMediaName[MediaTypes.Music] = music;

                    if (bool.Parse(CommonFunctions.GetSetting("EventsConfig_Music_QueryAmazon")))
                    {
                        // Always use media name in music search
                        status[1] = MyAddIn.MediaState.Music.ArtistName + "|" + MyAddIn.MediaState.Music.MediaName;
                    }

                    status[2] = "Music";
                    status[3] = "1";

                    return status;
                }
            }
            #endregion

            return status;
        }

        public DialogResult ShowDialog(string clickedText, bool modal, int timeout, DialogButtons dialogButtons)
        {
            DialogResult result = DialogResult.Cancel;

            if (_host != null)
            {
                result = MediaCenterEnvironment.Dialog(clickedText,
                                              MyAddIn.AppName,
                                              dialogButtons,
                                              timeout,
                                              modal);
            }

            return result;
        }
    }
}

