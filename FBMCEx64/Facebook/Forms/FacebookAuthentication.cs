using System;
using System.Security.Permissions;
using System.Windows.Forms;
using Facebook.API;
using System.Text.RegularExpressions;

namespace Facebook.Forms
{
    internal sealed partial class FacebookAuthentication : Form
    {
        FacebookAPI _fbApi;
        private string _previousState = "";

        private FacebookAuthentication()
        {
            InitializeComponent();
        }

        [SecurityPermission(SecurityAction.LinkDemand)]
        internal FacebookAuthentication(string loginUrl, string state, FacebookAPI fbApi)
            : this(new Uri(loginUrl), state, fbApi)
        {
            _previousState = state;
        }

        [SecurityPermission(SecurityAction.LinkDemand)]
        internal FacebookAuthentication(Uri loginUrl, string state, FacebookAPI fbApi)
            : this()
        {
            _previousState = state;

            wbFacebookLogin.Navigate(loginUrl);
            _fbApi = fbApi;
        }


        private void wbFacebookLogin_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (e.Url.AbsoluteUri.StartsWith("https://www.facebook.com/connect/login_success.html"))
            {
                // Get session information from URL
                var stateMatch = Regex.Match(e.Url.ToString(), "state=([^&]+)");
                var accessTokenMatch = Regex.Match(e.Url.ToString(), "access_token=([^&]+)");
                //Match expiresInMatch = Regex.Match(e.Url.ToString(), "expires_in=([^&]+)");

                string accessToken = "";
                string state = "";

                // State
                if (stateMatch.Groups[1].Success)
                {
                    state = stateMatch.Groups[1].Value;

                    // Verify that state matches the state that was passed (prevent Cross Site Request Forgery (CSRF))
                    if (!state.Equals(_previousState))
                    {
                        DialogResult = DialogResult.Cancel;
                        this.Close();
                    }
                }

                // Access_token
                if (accessTokenMatch.Groups[1].Success)
                {
                    accessToken = accessTokenMatch.Groups[1].Value;
                }

                if (!string.IsNullOrEmpty(accessToken))
                {
                    _fbApi.AccessToken = accessToken;

                    // Access_token
                    //if (accessTokenMatch.Groups[1].Success)
                    //{
                    _fbApi.SessionExpires = false; // !accessTokenMatch.Groups[3].Value.Equals("0");
                    //}

                    // Must use also this.Close() here, otherwise an extra IE window opens at next DoEvents at FB success URL
                    // Reason why this happens is unknown...
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                }
            }
            else if (e.Url.AbsoluteUri.StartsWith("https://www.facebook.com/connect/login_failure.html"))
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void FacebookAuthentication_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}