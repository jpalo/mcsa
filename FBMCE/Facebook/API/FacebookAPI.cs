using Facebook.Forms;

namespace Facebook.API
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;
    using System.Xml;
    using Exceptions;
    using Properties;
    using Types;
    using Utility;
    using Facebook.Types.Stream;
    using System.Windows.Forms;

    /// <summary>
    /// Provides various methods to use the Facebook Platform API.
    /// </summary>
    public partial class FacebookAPI
    {
        private const string ANDCLAUSE = " AND";
        private const string NEWLINE = "\r\n";
        private const string PREFIX = "--";
        private const string VERSION = "1.0";
        private string _stateVerification = "";

        public string ApplicationKey { get; set; }

        /// <summary>
        /// Whether or not the session expires
        /// </summary>
        public bool SessionExpires { get; set; }

        /// <summary>
        /// Whether or not this component is being used in a desktop application
        /// </summary>
        public bool IsDesktopApplication { get; set; }

        /// <summary>
        /// Secret word
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Access Token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// User Id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Authorization token
        /// </summary>
        public string AuthToken { get; set; }

        private string LoginUrl
        {
            get
            {
                var args = new object[2];
                args[0] = ApplicationKey;
                args[1] = _stateVerification;

                return String.Format(CultureInfo.InvariantCulture, Resources.FacebookLoginUrl, args);
            }
        }

        /// <summary>
        /// XML Namespace Manager
        /// </summary>
        public XmlNamespaceManager NsManager { get; private set; }

        internal CultureInfo InstalledCulture { get; private set; }

        #region Public Methods

        /// <summary>
        /// Displays an integrated browser to allow the user to log on to the
        /// Facebook web page.
        /// </summary>
        public bool ConnectToFacebook(bool forceLogin)
        {
            if ((!IsSessionActive() && IsDesktopApplication) || forceLogin)
            {
                DialogResult result;

                //Generate State GUID for preventing CSRF
                _stateVerification = Guid.NewGuid().ToString();

                var formLogin = new FacebookAuthentication(LoginUrl, _stateVerification, this);

                result = formLogin.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    formLogin.Dispose();
                    return false;
                }

                int loggedInUserId;

                if (int.TryParse(GetLoggedInUser(), out loggedInUserId))
                {
                    if (loggedInUserId > 0)
                    {
                        formLogin.Dispose();
                        return true;
                    }
                    else
                    {
                        formLogin.Dispose();
                        return false;
                    }
                }
                else
                {
                    formLogin.Dispose();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Update your status on Facebook
        /// Requires Facebook extended permission of "status_update"
        /// </summary>
        /// <param name="statusMessage">Your status message to be posted</param>
        /// <param name="IncludeVerb">Have your message start with the word "is"</param>
        public string SetStatus(string statusMessage, bool IncludeVerb)
        {
            var parameterList = new Dictionary<string, string>(5)
			                    	{
			                    		{"method", "Users.setStatus"},
			                    		{"status", statusMessage},
			                    		{"status_includes_verb", IncludeVerb.ToString()}
			                    	};

            return GetSingleNode(ExecuteApiCallString(parameterList, true), "users_setStatus_response");
        }

        /// <summary>
        /// Do you have permission to do the task needed?
        /// </summary>
        /// <param name="permission">Your status message to be posted</param>
        public bool HasPerission(Enums.Extended_Permissions permission)
        {
            var parameterList = new Dictionary<string, string>(5)
			                    	{
			                    		{"method", "Users.hasAppPermission"},
			                    		{"ext_perm", permission.ToString()}
			                    	};

            XmlNode node;
            return GetSingleNode(ExecuteApiCallString(parameterList, true), "Users_hasAppPermission_response", out node) && Convert.ToBoolean(node.InnerText);
        }

        private bool GetSingleNode(string xml, string rootTag, out XmlNode node)
        {
            node = null;

            if (!String.IsNullOrEmpty(xml))
            {
                var xmlDocument = LoadXMLDocument(xml);
                var nodeList = xmlDocument.GetElementsByTagName(rootTag);
                if (nodeList.Count > 0)
                {
                    if (nodeList[0].HasChildNodes)
                    {
                        node = nodeList[0];
                        return true;
                    }
                }
            }

            return false;
        }

        public string GetSingleNode(string xml, string rootTag)
        {
            XmlNode node;
            return GetSingleNode(xml, rootTag, out node) ? node.InnerText : string.Empty;
        }

        /// <summary>
        /// Uses Stream.Publish to publish stream
        /// </summary>
        /// <param name="message"></param>
        /// <param name="attachment"></param>
        /// <param name="action_links"></param>
        /// <param name="target_id"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public string StreamPublish(string message, attachment attachment, Dictionary<string, string> action_links, string target_id, int uid)
        {
            var parameterList = new Dictionary<string, string>();

            AddOptionalParameter(parameterList, "message", message);

            if (attachment != null)
            {
                if (attachment.properties.ratings != null)
                {
                    if (!string.IsNullOrEmpty(attachment.properties.ratings))
                    {
                        AddOptionalParameter(parameterList, "description", "Average rating: " + attachment.properties.ratings);
                    }
                }

                if (attachment.media != null)
                {
                    foreach (var item in attachment.media)
                    {
                        if (item.type == attachment_media_type.image)
                        {
                            var image = item as attachment_media_image;
                            AddOptionalParameter(parameterList, "picture", image.src);

                            break;
                        }
                    }

                }
                //var dict = new Dictionary<string, string>();

                //if (!string.IsNullOrEmpty(attachment.name))
                //{
                //    AddOptionalParameter(parameterList, "name", attachment.name);
                //}

                if (!string.IsNullOrEmpty(attachment.href))
                {
                    AddOptionalParameter(parameterList, "link", attachment.href);
                }

                //if (!string.IsNullOrEmpty(attachment.caption))
                //{
                //    AddOptionalParameter(parameterList, "caption", attachment.caption);
                //}
            }

            //if (action_links != null)
            //{
            //    var list = new List<string>();
            //    foreach (var item in action_links)
            //    {
            //        var dict = new Dictionary<string, string>{
            //        {"text", item.Key},
            //        {"href", item.Value}
            //    };
            //        list.Add(JSONHelper.ConvertToJSONAssociativeArray(dict));
            //    }
            //    AddJSONArray(parameterList, "action_links", list);
            //}

            /*
             * Pure GRAPH UI, for future use

            StringBuilder url = new StringBuilder(Resources.Stream);
            url.Append("&message=");
            url.Append(message);
            url.Append("&link=");
            url.Append(attachment.href);
            url.Append("&caption=");
            url.Append(attachment.caption);
            url.Append("&name=");
            url.Append(attachment.name);


            if (attachment.properties.ratings != null)
            {
                if (!string.IsNullOrEmpty(attachment.properties.ratings))
                {
                    url.Append("&description=Average rating:");
                    url.Append(attachment.properties.ratings);
                }
            }

            if (attachment.media != null)
            {
                foreach (var item in attachment.media)
                {
                    if (item.type == attachment_media_type.image)
                    {
                        var image = item as attachment_media_image;
                        url.Append("&picture=");
                        url.Append(image.src);
                    }
                }
            }
*/
            return ExecuteApiCallString(parameterList, true, Resources.Stream);
        }

        /// <summary>
        /// Get the facebook user id of the user associated with the current session
        /// </summary>
        /// <returns>facebook userid</returns>
        public string GetLoggedInUser()
        {
            List<string> arr = JSONHelper.ConvertFromJSONArray(ExecuteApiCallString(null, true, Resources.CurrentUser));

            //{id:628920325}
            // Only works if user id only contains digits
            return System.Text.RegularExpressions.Regex.Match(arr[0], "\\d+").Groups[0].Value;
        }

        /// <summary>
        /// Forgets all connection information so that this object may be used for another connection.
        /// </summary>
        public void LogOff()
        {
            AuthToken = null;
            AccessToken = null;
            UserId = null;
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Get Query Response
        /// </summary>
        /// <param name="requestUrl">Request Url</param>
        /// <param name="postString">posted query</param>
        /// <returns>Response data</returns>
        internal static string GetQueryResponse(string requestUrl, string postString)
        {
            // Create a web request for input path.
            HttpWebRequest webRequest = WebRequest.Create(requestUrl) as HttpWebRequest;
            if (!string.IsNullOrEmpty(postString))
            {
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";

                byte[] parameterString = Encoding.ASCII.GetBytes(postString);
                webRequest.ContentLength = parameterString.Length;

                using (Stream buffer = webRequest.GetRequestStream())
                {
                    buffer.Write(parameterString, 0, parameterString.Length);
                    buffer.Close();
                }
            }
            else
            {
                webRequest.Method = "GET";
            }



            HttpWebResponse webResponse = null;
            string responseData = "";

            try
            {
                webResponse = webRequest.GetResponse() as HttpWebResponse;
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    //Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data = response.GetResponseStream())
                    {
                        return new StreamReader(data).ReadToEnd();
                    }
                }
            }

            using (var streamReader = new StreamReader(webResponse.GetResponseStream()))
            {
                responseData = streamReader.ReadToEnd();
            }

            return responseData;
        }

        internal string ExecuteApiCallString(IDictionary<string, string> parameterDictionary, bool useSession)
        {
            throw new NotImplementedException();
        }

        internal string ExecuteApiCallString(IDictionary<string, string> parameterDictionary, bool useSession, string requestUrl)
        {
            string access_token = "";
            string parameters = "";

            if (useSession)
            {
                access_token = "access_token=" + AccessToken;
            }

            if (null != parameterDictionary)
            {
                parameters = CreateHTTPParameterList(parameterDictionary);
            }

            return GetQueryResponse(string.Format(requestUrl, access_token), parameters);
        }

        /// <summary>
        /// Parse the data and extract the session details
        /// </summary>
        /// <param name="rawXML">string</param>
        /// <returns>XmlDocument</returns>
        internal XmlDocument LoadXMLDocument(string rawXML)
        {
            var xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(rawXML);

            NsManager = new XmlNamespaceManager(xmlDocument.NameTable);
            NsManager.AddNamespace("Facebook", Resources.FacebookNamespace);

            ErrorCheck(xmlDocument);
            return xmlDocument;
        }

        internal string CreateHTTPParameterList(IDictionary<string, string> parameterList)
        {
            var queryBuilder = new StringBuilder();

            //parameterList.Add("api_key", ApplicationKey);
            //parameterList.Add("v", VERSION);
            //parameterList.Add("call_id", DateTime.Now.Ticks.ToString("x", CultureInfo.InvariantCulture));
            //parameterList.Add("sig", GenerateSignature(parameterList));

            // Build the query
            foreach (var kvp in parameterList)
            {
                queryBuilder.Append(kvp.Key);
                queryBuilder.Append("=");
                queryBuilder.Append(HttpUtility.UrlEncode(kvp.Value));
                queryBuilder.Append("&");
            }
            queryBuilder.Remove(queryBuilder.Length - 1, 1);

            return queryBuilder.ToString();
        }

        internal static List<string> ParameterDictionaryToList(IEnumerable<KeyValuePair<string, string>> parameterDictionary)
        {
            var parameters = new List<string>();

            foreach (var kvp in parameterDictionary)
            {
                parameters.Add(String.Format(CultureInfo.InvariantCulture, "{0}", kvp.Key));
            }
            return parameters;
        }

        /// <summary>
        /// This method generates the signature based on parameters supplied
        /// </summary>
        /// <param name="parameters">List of paramenters</param>
        /// <returns>Generated signature</returns>
        internal string GenerateSignature(IDictionary<string, string> parameters)
        {
            var signatureBuilder = new StringBuilder();

            // Sort the keys of the method call in alphabetical order
            List<string> keyList = ParameterDictionaryToList(parameters);
            keyList.Sort();

            // Append all the parameters to the signature input paramaters
            foreach (string key in keyList)
                signatureBuilder.Append(String.Format(CultureInfo.InvariantCulture, "{0}={1}", key, parameters[key]));

            // Append the secret to the signature builder
            signatureBuilder.Append(Secret);

            MD5 md5 = MD5.Create();
            // Compute the MD5 hash of the signature builder
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(signatureBuilder.ToString().Trim()));

            // Reinitialize the signature builder to store the actual signature
            signatureBuilder = new StringBuilder();

            // Append the hash to the signature
            foreach (byte hashByte in hash)
                signatureBuilder.Append(hashByte.ToString("x2", CultureInfo.InvariantCulture));

            return signatureBuilder.ToString();
        }

        internal bool IsSessionActive()
        {
            return !String.IsNullOrEmpty(AccessToken);
        }

        /// <summary>
        /// Parse the Facebook result for an error, and throw an exception. 
        /// For some of the different types of exceptions, custom action might be desirable.
        /// </summary>
        /// <param name="doc">The XML result.</param>
        internal static void ErrorCheck(XmlDocument doc)
        {
            XmlNodeList errors = doc.GetElementsByTagName("error_response");

            if (errors.Count > 0)
            {
                var errorCode = int.Parse(XmlHelper.GetNodeText(errors[0], "error_code"), CultureInfo.InvariantCulture);

                // Custom exception for some of the errors
                switch (errorCode)
                {
                    case 1:
                        throw new FacebookUnknownException(XmlHelper.GetNodeText(errors[0], "error_msg"));
                    case 2:
                        throw new FacebookServiceUnavailableException(XmlHelper.GetNodeText(errors[0], "error_msg"));
                    case 4:
                        throw new FacebookRequestLimitException(XmlHelper.GetNodeText(errors[0], "error_msg"));
                    case 102:
                        throw new FacebookTimeoutException(XmlHelper.GetNodeText(errors[0], "error_msg"));
                    case 104:
                        throw new FacebookSigningException(XmlHelper.GetNodeText(errors[0], "error_msg"));
                    case 110:
                        throw new FacebookInvalidUserException(XmlHelper.GetNodeText(errors[0], "error_msg"));
                    case 120:
                        throw new FacebookInvalidAlbumException(XmlHelper.GetNodeText(errors[0], "error_msg"));
                    case 210: // user not visible
                    case 220: // album not visible
                    case 221: // photo not visible
                        throw new FacebookNotVisibleException(XmlHelper.GetNodeText(errors[0], "error_msg"));
                    case 601:
                        throw new FacebookInvalidFqlSyntaxException(XmlHelper.GetNodeText(errors[0], "error_msg"));
                    default:
                        throw new FacebookException(XmlHelper.GetNodeText(errors[0], "error_msg"));
                }
            }
        }

        #endregion

        public FacebookAPI()
        {
            AuthToken = string.Empty;
            IsDesktopApplication = true;
#if NETCF 
			InstalledCulture = CultureInfo.CurrentUICulture;
#else
            InstalledCulture = CultureInfo.InstalledUICulture;
#endif
        }
    }
}