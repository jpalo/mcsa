using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Xml;
using System.Security.Cryptography;
using System.Xml.XPath;
using System.Net;
using FBMCE.Properties;
using FBMCE;
using Newtonsoft.Json;

namespace Twitter
{
    public class TwitterAPI
    {
        private ulong _newestFriendStatusId = 0;

        private ulong _currentUserId = 0;
        private List<string> _allowedTwitterFriends = new List<string>();

        private Queue<string[]> _friendStatuses = new Queue<string[]>();

        public oAuthTwitter oAuthTwitter;

        public TwitterAPI()
        {
            oAuthTwitter = new oAuthTwitter();
        }

        public TwitterAPI(string accessToken, string accessTokenSecret)
        {
            oAuthTwitter = new oAuthTwitter();
            oAuthTwitter.Token = accessToken;
            oAuthTwitter.TokenSecret = accessTokenSecret;
        }

        public void SetAllowedFriends(string allowedFriends)
        {
            if (!string.IsNullOrEmpty(allowedFriends))
            {
                _allowedTwitterFriends.AddRange(allowedFriends.Replace(',', ';').Split(';'));
            }
        }

        public bool VerifyCredentials()
        {
            try
            {
                string resp = oAuthTwitter.oAuthWebRequest(oAuthTwitter.Method.GET, Resources.Twitter_VerifyCredentialsUrl, "");

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Logs in to Twitter
        /// </summary>
        /// <param name="username">Twitter username</param>
        /// <param name="password">Twitter password</param>
        /// <param name="rememberMe">True if access token and secret are stored to registry after successful login.</param>
        /// <returns>True if credentials are valid, otherwise false</returns>
        public bool Login(string username, string password, bool rememberMe)
        {
            try
            {
                // Clear stored tokens in case they are expired or have errors, as we have ended to this function
                oAuthTwitter.Token = "";
                oAuthTwitter.TokenSecret = "";

                oAuthTwitter.xAuthAccessTokenGet(username, password);

                if (oAuthTwitter.TokenSecret.Length > 0)
                {
                    //Save oAuth.Token & oAuth.TokenSecret at this point.
                    //You can reuse the tokens unless the user revokes access to your application.
                    //Store login values to registry
                    if (rememberMe)
                    {
                        CommonFunctions.SetSetting("Twitter_AccessToken", oAuthTwitter.Token);
                        CommonFunctions.SetSetting("Twitter_AccessTokenSecret", oAuthTwitter.TokenSecret);
                    }

                    return true;
                }

            }
            catch (Exception)
            {

            }

            return false;
        }

        /// <summary>
        /// Updates user status
        /// </summary>
        /// <param name="status"></param>
        public bool SetStatus(string status)
        {
            bool updateSuccessful = false;

            try
            {
                string statusString = "status=" + oAuthTwitter.UrlEncodeForOAuth(status) + "&source=mediacenterstatusapplication";
                string resp = oAuthTwitter.oAuthWebRequest(oAuthTwitter.Method.POST, Resources.Twitter_StatusUrl, statusString);

                // Verify that update request succeeded
                if (!string.IsNullOrEmpty(resp))
                {
                    updateSuccessful = true;
                }
            }
            catch (Exception)
            {
                updateSuccessful = false;
            }

            return updateSuccessful;
        }

        /// <summary>
        /// Updates internal latest status ID of user's friends
        /// </summary>
        /// <returns>True if update was successfull, otherwise false.</returns>
        public bool UpdateLatestTwitterStatusId()
        {
            bool retVal = false;

            try
            {
                string resp = oAuthTwitter.oAuthWebRequest(oAuthTwitter.Method.GET, Resources.Twitter_FriendStatusUrl + "?count=1&trim_user=1", "");

                if (!string.IsNullOrEmpty(resp))
                {

                    var tro = JsonConvert.DeserializeObject<List<TwitterRootObject>>(resp);

                    if (!string.IsNullOrEmpty(tro[0].id_str))
                    {
                        _newestFriendStatusId = ulong.Parse(tro[0].id_str);
                        retVal = true;
                    }
                }
            }
            catch (Exception)
            {
                retVal = false;
            }

            return retVal;
        }

        /// <summary>
        /// Returns oldest status string from status queue
        /// </summary>
        /// <returns>Status string, if there are no statuses, returns empty string.</returns>
        public string[] GetNextTwitterStatus()
        {
            if (_friendStatuses.Count > 0)
            {
                return _friendStatuses.Dequeue();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Appends new friend statues to the internal list of new friend status updates.
        /// </summary>
        /// <returns>
        /// True if successful, otherwise false.
        /// </returns>
        public bool UpdateLatestTwitterStatusChanges()
        {
            bool retVal = true;

            try
            {
                // Do not use trim_user=1 as it will not include user screen_name or name
                string resp = oAuthTwitter.oAuthWebRequest(oAuthTwitter.Method.GET, Resources.Twitter_FriendStatusUrl + "?since_id=" + _newestFriendStatusId.ToString() + "&contributor_details=1", "");

                if (!string.IsNullOrEmpty(resp))
                {
                    var tweets = JsonConvert.DeserializeObject<List<TwitterRootObject>>(resp);

                    for (int i = 0; i < tweets.Count; i++)
                    {
                        // Update latest tweet ID as we move on
                        var currentId = (ulong)tweets[i].id;
                        if (currentId > _newestFriendStatusId)
                        {
                            _newestFriendStatusId = currentId;
                        }

                        // Do not show own tweets NOR tweets of people you do not want to see
                        if ((ulong)tweets[i].user.id == _currentUserId || (_allowedTwitterFriends.Count > 0 && !_allowedTwitterFriends.Contains(tweets[i].user.screen_name)))
                        {
                            continue;
                        }

                        _friendStatuses.Enqueue(new string[] { tweets[i].user.name, tweets[i].text });
                    }
                }
            }
            catch (Exception)
            {
                retVal = false;
            }

            return retVal;
        }

        /// <summary>
        /// Clears all status updates from the queue.
        /// </summary>
        public void ClearStatusQueue()
        {
            _friendStatuses.Clear();
        }
    }
}
