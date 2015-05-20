using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Diagnostics;

namespace FBMCE_Configuration_Tool
{
    public partial class Tool : Form
    {
        private const string _defaultPollingInterval = "10000";
        private const string _defaultEventEnabled = "1";
        private const string _defaultDebugEnabled = "0";
        private const string _defaultConfirmUpdate = "0";
        private const string _defaultClearStatusOnExit = "1";
        private const string _defaultServiceXmlFile = "status.xml";
        private const string _userRegistryHive = "HKEY_CURRENT_USER\\SOFTWARE\\Hamar Data\\FBMCE";
        private const string _machineRegistryHive = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Hamar Data\\FBMCE";

        public Tool()
        {
            InitializeComponent();
        }

        private void Tool_Load(object sender, EventArgs e)
        {
            InitializeCurrentValues();
        }

        private bool SaveValues()
        {
            try
            {
                if ((int.Parse(pollingInterval.Text.Trim())) > 0)
                {
                    SetSetting("PollingInterval", pollingInterval.Text.Trim() + "000");
                }

                SetSetting("Debug", debug.Checked ? "1" : "0");
                SetSetting("ClearStatusOnExit", clearStatusOnExit.Checked ? "1" : "0");

                SetSetting("EventsConfig_Music_AlbumMode", albumMode.Checked ? "1" : "0");
                SetSetting("EventsConfig_DVD_StatusString", eventsConfig_DVD_StatusString.Text);
                SetSetting("EventsConfig_Music_StatusString", eventsConfig_Music_StatusString.Text);
                SetSetting("EventsConfig_Pictures_StatusString", eventsConfig_Pictures_StatusString.Text);
                SetSetting("EventsConfig_RecordedTV_StatusString", eventsConfig_RecordedTV_StatusString.Text);
                SetSetting("EventsConfig_RecordingTV_StatusString", eventsConfig_RecordingTV_StatusString.Text);
                SetSetting("EventsConfig_TV_StatusString", eventsConfig_TV_StatusString.Text);
                SetSetting("EventsConfig_Video_StatusString", eventsConfig_Video_StatusString.Text);

                SetSetting("EventsConfig_Music_QueryAmazon", eventsConfig_Music_QueryAmazon.Checked ? "1" : "0");
                SetSetting("EventsConfig_DVD_QueryAmazon", eventsConfig_DVD_QueryAmazon.Checked ? "1" : "0");
                SetSetting("EventsConfig_Pictures_QueryAmazon", eventsConfig_Pictures_QueryAmazon.Checked ? "1" : "0");
                SetSetting("EventsConfig_RecordedTV_QueryAmazon", eventsConfig_RecordedTV_QueryAmazon.Checked ? "1" : "0");
                SetSetting("EventsConfig_RecordingTV_QueryAmazon", eventsConfig_RecordingTV_QueryAmazon.Checked ? "1" : "0");
                SetSetting("EventsConfig_TV_QueryAmazon", eventsConfig_TV_QueryAmazon.Checked ? "1" : "0");
                SetSetting("EventsConfig_Video_QueryAmazon", eventsConfig_Video_QueryAmazon.Checked ? "1" : "0");

                SetSetting("EventsEnabled_Service_Facebook", eventsEnabled_Service_Facebook.Checked ? "1" : "0");
                SetSetting("EventsEnabled_Service_Xml", eventsEnabled_Service_Xml.Checked ? "1" : "0");
                SetSetting("EventsEnabled_Service_Twitter", eventsEnabled_Service_Twitter.Checked ? "1" : "0");

                SetSetting("EventsEnabled_DVD", events_DVD.Checked ? "1" : "0");
                SetSetting("EventsEnabled_Music", events_Music.Checked ? "1" : "0");
                SetSetting("EventsEnabled_Pictures", events_Pictures.Checked ? "1" : "0");
                SetSetting("EventsEnabled_RecordedTV", events_RecordedTV.Checked ? "1" : "0");
                SetSetting("EventsEnabled_RecordingTV", events_RecordingTV.Checked ? "1" : "0");
                SetSetting("EventsEnabled_TV", events_TV.Checked ? "1" : "0");
                SetSetting("EventsEnabled_Video", events_Video.Checked ? "1" : "0");

                SetSetting("Exclusion_DVD_RegExp", exclusions_DVD.Text);
                SetSetting("Exclusion_Music_RegExp", exclusions_Music.Text);
                SetSetting("Exclusion_Pictures_RegExp", exclusions_Pictures.Text);
                SetSetting("Exclusion_RecordedTV_RegExp", exclusions_RecordedTV.Text);
                SetSetting("Exclusion_RecordingTV_RegExp", exclusions_RecordingTV.Text);
                SetSetting("Exclusion_TV_RegExp", exclusions_TV.Text);
                SetSetting("Exclusion_Video_RegExp", exclusions_Video.Text);

                SetSetting("EventsEnabled_Service_TwitterFriends", eventsEnabled_Service_TwitterFriends.Checked ? "1" : "0");
                SetSetting("ConfirmUpdate_Facebook", facebookConfirmUpdates.Checked ? "1" : "0");
                SetSetting("ConfirmUpdate_Twitter", twitterConfirmUpdates.Checked ? "1" : "0");
                SetSetting("Service_Twitter_Friends_TimesPerHour", twitterFrequencyOfFriendStatusQueries.Text);
                SetSetting("Service_Twitter_Friends", twitterFriends.Text);
                SetSetting("Service_Twitter_EnableSuspend", service_Twitter_EnableSuspend.Checked ? "1" : "0");
                SetSetting("Service_Twitter_SuspendTime", service_Twitter_SuspendTime.Text);

                SetSetting("Service_Xml_File", xmlFilePath.Text);
                SetSetting("Service_Xml_ClearWhenNoMedia", service_Xml_ClearWhenNoMedia.Checked ? "1" : "0");
                SetSetting("Service_Xml_ClearStatusOnExit", service_Xml_ClearStatusOnExit.Checked ? "1" : "0");

                // Update enabled hours
                if (!string.IsNullOrEmpty(facebookEnabledBetweenStart.Text) && !string.IsNullOrEmpty(facebookEnabledBetweenEnd.Text))
                {
                    SetSetting("Service_Facebook_TimeEnabled", facebookEnabledBetweenStart.Text + "-" + facebookEnabledBetweenEnd.Text);
                }
                else
                {
                    SetSetting("Service_Facebook_TimeEnabled", "");
                }

                if (!string.IsNullOrEmpty(xmlEnabledBetweenStart.Text) && !string.IsNullOrEmpty(xmlEnabledBetweenEnd.Text))
                {
                    SetSetting("Service_Xml_TimeEnabled", xmlEnabledBetweenStart.Text + "-" + xmlEnabledBetweenEnd.Text);
                }
                else
                {
                    SetSetting("Service_Xml_TimeEnabled", "");
                }

                if (!string.IsNullOrEmpty(twitterEnabledBetweenStart.Text) && !string.IsNullOrEmpty(twitterEnabledBetweenEnd.Text))
                {
                    SetSetting("Service_Twitter_TimeEnabled", twitterEnabledBetweenStart.Text + "-" + twitterEnabledBetweenEnd.Text);
                }
                else
                {
                    SetSetting("Service_Twitter_TimeEnabled", "");
                }

                // Update Amazon locale
                string amazonUrl = "";
                switch (amazonLocaleUrl.SelectedItem.ToString())
                {
                    case ("Amazon UK"):
                        amazonUrl = "ecs.amazonaws.co.uk";
                        break;

                    case ("Amazon FR"):
                        amazonUrl = "ecs.amazonaws.fr";
                        break;

                    case ("Amazon CA"):
                        amazonUrl = "ecs.amazonaws.ca";
                        break;

                    case ("Amazon JP"):
                        amazonUrl = "ecs.amazonaws.jp";
                        break;

                    case ("Amazon DE"):
                        amazonUrl = "ecs.amazonaws.de";
                        break;

                    default:
                        amazonUrl = "ecs.amazonaws.com";
                        break;
                }

                SetSetting("Service_All_AmazonLocaleUrl", amazonUrl);

                string streamEnabled = "0";

                // Update Facebook status update type
                foreach (string item in FacebookUpdateType.SelectedItems)
                {
                    switch (item)
                    {
                        case ("Wall and News feed"):
                            streamEnabled = "1";
                            break;
                    }
                }

                SetSetting("Service_Facebook_StreamEnabled", streamEnabled);
            }
            catch (Exception)
            {
                if (DialogResult.Retry == MessageBox.Show("Error occurred when saving changes.\n\nPress Retry to retry saving, and Cancel to close without saving.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error))
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private void InitializeCurrentValues()
        {
            pollingInterval.Text = (int.Parse(GetSetting("PollingInterval", false)) / 1000).ToString();
            debug.Checked = bool.Parse(GetSetting("Debug", true));
            clearStatusOnExit.Checked = bool.Parse(GetSetting("ClearStatusOnExit", true));

            albumMode.Checked = bool.Parse(GetSetting("EventsConfig_Music_AlbumMode", true));
            eventsConfig_DVD_StatusString.Text = GetSetting("EventsConfig_DVD_StatusString", false);
            eventsConfig_Music_StatusString.Text = GetSetting("EventsConfig_Music_StatusString", false);
            eventsConfig_Pictures_StatusString.Text = GetSetting("EventsConfig_Pictures_StatusString", false);
            eventsConfig_RecordedTV_StatusString.Text = GetSetting("EventsConfig_RecordedTV_StatusString", false);
            eventsConfig_RecordingTV_StatusString.Text = GetSetting("EventsConfig_RecordingTV_StatusString", false);
            eventsConfig_TV_StatusString.Text = GetSetting("EventsConfig_TV_StatusString", false);
            eventsConfig_Video_StatusString.Text = GetSetting("EventsConfig_Video_StatusString", false);

            eventsConfig_Music_QueryAmazon.Checked = bool.Parse(GetSetting("EventsConfig_Music_QueryAmazon", true));
            eventsConfig_DVD_QueryAmazon.Checked = bool.Parse(GetSetting("EventsConfig_DVD_QueryAmazon", true));
            eventsConfig_Pictures_QueryAmazon.Checked = bool.Parse(GetSetting("EventsConfig_Pictures_QueryAmazon", true));
            eventsConfig_RecordedTV_QueryAmazon.Checked = bool.Parse(GetSetting("EventsConfig_RecordedTV_QueryAmazon", true));
            eventsConfig_RecordingTV_QueryAmazon.Checked = bool.Parse(GetSetting("EventsConfig_RecordingTV_QueryAmazon", true));
            eventsConfig_TV_QueryAmazon.Checked = bool.Parse(GetSetting("EventsConfig_TV_QueryAmazon", true));
            eventsConfig_Video_QueryAmazon.Checked = bool.Parse(GetSetting("EventsConfig_Video_QueryAmazon", true));

            eventsEnabled_Service_Facebook.Checked = bool.Parse(GetSetting("EventsEnabled_Service_Facebook", true));
            eventsEnabled_Service_Xml.Checked = bool.Parse(GetSetting("EventsEnabled_Service_Xml", true));
            eventsEnabled_Service_Twitter.Checked = bool.Parse(GetSetting("EventsEnabled_Service_Twitter", true));

            events_DVD.Checked = bool.Parse(GetSetting("EventsEnabled_DVD", true));
            events_Music.Checked = bool.Parse(GetSetting("EventsEnabled_Music", true));
            events_Pictures.Checked = bool.Parse(GetSetting("EventsEnabled_Pictures", true));
            events_RecordedTV.Checked = bool.Parse(GetSetting("EventsEnabled_RecordedTV", true));
            events_RecordingTV.Checked = bool.Parse(GetSetting("EventsEnabled_RecordingTV", true));
            events_TV.Checked = bool.Parse(GetSetting("EventsEnabled_TV", true));
            events_Video.Checked = bool.Parse(GetSetting("EventsEnabled_Video", true));

            exclusions_DVD.Text = GetSetting("Exclusion_DVD_RegExp", false);
            exclusions_Music.Text = GetSetting("Exclusion_Music_RegExp", false);
            exclusions_Pictures.Text = GetSetting("Exclusion_Pictures_RegExp", false);
            exclusions_RecordedTV.Text = GetSetting("Exclusion_RecordedTV_RegExp", false);
            exclusions_RecordingTV.Text = GetSetting("Exclusion_RecordingTV_RegExp", false);
            exclusions_TV.Text = GetSetting("Exclusion_TV_RegExp", false);
            exclusions_Video.Text = GetSetting("Exclusion_Video_RegExp", false);

            twitterFriends.Text = GetSetting("Service_Twitter_Friends", false);
            facebookConfirmUpdates.Checked = bool.Parse(GetSetting("ConfirmUpdate_Facebook", true));
            twitterConfirmUpdates.Checked = bool.Parse(GetSetting("ConfirmUpdate_Twitter", true));

            eventsEnabled_Service_TwitterFriends.Checked = bool.Parse(GetSetting("EventsEnabled_Service_TwitterFriends", true));
            twitterFrequencyOfFriendStatusQueries.Text = GetSetting("Service_Twitter_Friends_TimesPerHour", false);

            xmlFilePath.Text = GetSetting("Service_Xml_File", false);
            service_Xml_ClearWhenNoMedia.Checked = bool.Parse(GetSetting("Service_Xml_ClearWhenNoMedia", true));
            service_Xml_ClearStatusOnExit.Checked = bool.Parse(GetSetting("Service_Xml_ClearStatusOnExit", true));

            // Facebook time enabled
            string facebookServiceEnabledTime = GetSetting("Service_Facebook_TimeEnabled", false);

            if (facebookServiceEnabledTime.Contains("-"))
            {
                facebookEnabledBetweenStart.Text = facebookServiceEnabledTime.Split('-')[0];
                facebookEnabledBetweenEnd.Text = facebookServiceEnabledTime.Split('-')[1];
            }

            // XML time enabled
            string xmlServiceEnabledTime = GetSetting("Service_Xml_TimeEnabled", false);

            if (xmlServiceEnabledTime.Contains("-"))
            {
                xmlEnabledBetweenStart.Text = xmlServiceEnabledTime.Split('-')[0];
                xmlEnabledBetweenEnd.Text = xmlServiceEnabledTime.Split('-')[1];
            }

            // Twitter time enabled
            string twitterServiceEnabledTime = GetSetting("Service_Twitter_TimeEnabled", false);

            if (twitterServiceEnabledTime.Contains("-"))
            {
                twitterEnabledBetweenStart.Text = twitterServiceEnabledTime.Split('-')[0];
                twitterEnabledBetweenEnd.Text = twitterServiceEnabledTime.Split('-')[1];
            }

            InitializeEnabledHours(eventsEnabled_Service_Facebook, facebookEnabledBetweenStart, facebookEnabledBetweenEnd);
            InitializeEnabledHours(eventsEnabled_Service_Xml, xmlEnabledBetweenStart, xmlEnabledBetweenEnd);
            InitializeEnabledHours(eventsEnabled_Service_Twitter, twitterEnabledBetweenStart, twitterEnabledBetweenEnd);

            // Amazon locale
            string amazonUrl = "";
            switch (GetSetting("Service_All_AmazonLocaleUrl", false))
            {
                case ("ecs.amazonaws.co.uk"):
                    amazonUrl = "Amazon UK";
                    break;

                case ("ecs.amazonaws.fr"):
                    amazonUrl = "Amazon FR";
                    break;

                case ("ecs.amazonaws.ca"):
                    amazonUrl = "Amazon CA";
                    break;

                case ("ecs.amazonaws.jp"):
                    amazonUrl = "Amazon JP";
                    break;

                case ("ecs.amazonaws.de"):
                    amazonUrl = "Amazon DE";
                    break;

                default:
                    amazonUrl = "Amazon US";
                    break;
            }

            amazonLocaleUrl.SelectedIndex = amazonLocaleUrl.FindStringExact(amazonUrl);

            // Facebook update type
            bool fbStreamEnabled = bool.Parse(GetSetting("Service_Facebook_StreamEnabled", true));

            if (fbStreamEnabled)
            {
                FacebookUpdateType.SetSelected(FacebookUpdateType.FindStringExact("Wall and News feed"), true);
            }

            FacebookUpdateType_SelectedIndexChanged_1(FacebookUpdateType, null);

            // Twitter suspend
            service_Twitter_EnableSuspend.Checked = bool.Parse(GetSetting("Service_Twitter_EnableSuspend", true));
            service_Twitter_SuspendTime.Text = GetSetting("Service_Twitter_SuspendTime", false);

            service_Twitter_EnableSuspend_CheckedChanged(service_Twitter_EnableSuspend, null);
        }

        #region Helper methods
        /// <summary>
        /// Stores FB session key in registry
        /// </summary>
        /// <param name="Facebook_AccessToken">FB session key</param>
        private static void SetSetting(string key, string value)
        {
            try
            {
                Registry.SetValue(_machineRegistryHive, key, value, RegistryValueKind.String);
            }
            catch (Exception)
            {
                MessageBox.Show("Error", "Error when saving values. Error key: " + key, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Gets values from registry
        /// </summary>
        /// <param name="key">Registry key name</param>
        /// <returns></returns>
        private static string GetSetting(string key, bool isBoolean)
        {
            try
            {
                string value = Registry.GetValue(_machineRegistryHive, key, null) as string;

                if (value != null)
                {
                    return ParseRegistryValue(value);
                }
                else
                {
                    if (isBoolean)
                    {
                        return "false";
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Warning", "Couldn't find all required registry keys, make sure application is installed properly. Missing key: " + key, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (isBoolean)
                {
                    return "false";
                }
                else
                {
                    return "";
                }

            }
        }

        private static string ParseRegistryValue(string value)
        {
            switch (value)
            {
                case ("0"):
                    return "false";

                case ("1"):
                    return "true";

                default:
                    return value;
            }
        }

        private void InitializeEnabledHours(object sender, TextBox startHour, TextBox endHour)
        {
            if (((CheckBox)sender).Checked)
            {
                startHour.Enabled = endHour.Enabled = true;
            }
            else
            {
                startHour.Enabled = endHour.Enabled = false;
            }
        }
        #endregion

        #region Validators
        /// <summary>
        /// Validates if input value contains two integers.
        /// </summary>
        /// <param name="sender"></param>
        private bool ValidateHour(object sender)
        {
            string strValue = ((TextBox)sender).Text;
            int intValue;

            if (!int.TryParse(strValue, out intValue))
            {
                intValue = -1;
            }

            if ((!Regex.IsMatch(strValue, "^[0-9][0-9]$") || intValue < 0 || intValue > 23) && !string.IsNullOrEmpty(strValue))
            {
                errorProvider.SetError((Control)sender, "Can only contain integer hour value in format HH, e.g., 02 or 21.");
                return false;
            }
            else
            {
                errorProvider.SetError((Control)sender, "");
                return true;
            }
        }

        private bool ValidatorIntegerGreaterThanZero(object sender)
        {
            return ValidatorIntegerGreaterThanZero(sender, false);
        }

        private bool ValidatorIntegerGreaterThanZero(object sender, bool forceNoError)
        {
            if (!Regex.IsMatch(((TextBox)sender).Text, "^[1-9][0-9]*$") && !forceNoError)
            {
                errorProvider.SetError((Control)sender, "Can only contain integers greater than zero.");
                errorProvider.SetIconPadding((Control)sender, 102);

                return false;
            }
            else
            {
                errorProvider.SetError((Control)sender, "");

                return true;
            }
        }

        /// <summary>
        /// Validates all form controls
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            bool isValid = true;

            // Twitter suspend time
            if (service_Twitter_EnableSuspend.Checked && !ValidatorIntegerGreaterThanZero(service_Twitter_SuspendTime))
            {
                isValid = false;
            }

            // Facebook enabled start time
            if (!ValidateHour(facebookEnabledBetweenStart))
            {
                isValid = false;
            }

            // Facebook enabled end time
            if (!ValidateHour(facebookEnabledBetweenEnd))
            {
                isValid = false;
            }

            // Twitter enabled start time
            if (!ValidateHour(twitterEnabledBetweenStart))
            {
                isValid = false;
            }

            // Twitter enabled end time
            if (!ValidateHour(twitterEnabledBetweenEnd))
            {
                isValid = false;
            }

            // Xml enabled start time
            if (!ValidateHour(xmlEnabledBetweenStart))
            {
                isValid = false;
            }

            // Xml enabled end time
            if (!ValidateHour(xmlEnabledBetweenEnd))
            {
                isValid = false;
            }

            // Polling interval
            if (!ValidatorIntegerGreaterThanZero(pollingInterval))
            {
                isValid = false;
            }
            return isValid;
        }
        #endregion

        #region Event handlers

        private void Tool_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("Are you sure you want to exit?",
               "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                e.Cancel = true;
            }
        }

        private void eventsEnabled_Service_Facebook_CheckedChanged(object sender, EventArgs e)
        {
            InitializeEnabledHours(sender, facebookEnabledBetweenStart, facebookEnabledBetweenEnd);
        }

        private void twitterEnabledBetweenStart_TextChanged(object sender, EventArgs e)
        {
            ValidateHour(sender);
        }

        private void twitterEnabledBetweenEnd_TextChanged(object sender, EventArgs e)
        {
            ValidateHour(sender);
        }

        private void facebookEnabledBetweenStart_TextChanged(object sender, EventArgs e)
        {
            ValidateHour(sender);
        }

        private void facebookEnabledBetweenEnd_TextChanged(object sender, EventArgs e)
        {
            ValidateHour(sender);
        }

        private void service_Twitter_EnableSuspend_CheckedChanged(object sender, EventArgs e)
        {
            service_Twitter_SuspendTime.Enabled = service_Twitter_EnableSuspend.Checked;

            // Force clearing error if checkbox is cleared in order to allow invalid values when setting is disabled
            if (!service_Twitter_SuspendTime.Enabled)
            {
                ValidatorIntegerGreaterThanZero(service_Twitter_SuspendTime, true);
            }
            else
            {
                ValidatorIntegerGreaterThanZero(service_Twitter_SuspendTime);
            }
        }

        private void service_Twitter_SuspendTime_TextChanged(object sender, EventArgs e)
        {
            ValidatorIntegerGreaterThanZero(sender);
        }


        private void FacebookUpdateType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedItems.Count == 0)
            {
                eventsEnabled_Service_Facebook.Checked = false;
                eventsEnabled_Service_Facebook.Enabled = false;
                clearStatusOnExit.Enabled = false;
                clearStatusOnExit.Checked = false;
            }
            else
            {
                eventsEnabled_Service_Facebook.Enabled = true;

                // Check if clearstatus should be enabled
                foreach (string item in FacebookUpdateType.SelectedItems)
                {
                    if (item.Equals("Status"))
                    {
                        clearStatusOnExit.Enabled = true;
                        break;
                    }
                    else
                    {
                        clearStatusOnExit.Enabled = false;
                        clearStatusOnExit.Checked = false;
                    }
                }
            }
        }

        private void eventsEnabled_Service_Xml_CheckedChanged(object sender, EventArgs e)
        {
            InitializeEnabledHours(sender, xmlEnabledBetweenStart, xmlEnabledBetweenEnd);
        }

        private void xmlEnabledBetweenStart_TextChanged(object sender, EventArgs e)
        {
            ValidateHour(sender);
        }

        private void xmlEnabledBetweenEnd_TextChanged(object sender, EventArgs e)
        {
            ValidateHour(sender);
        }

        private void btnClearTwitterOfflineData_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to remove Twitter persistent\nsession data from registry?\n\n" +
                "You need log in to Twitter next time you start Media Center.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                Registry.SetValue(_userRegistryHive, "Twitter_AccessToken", "", RegistryValueKind.String);
                Registry.SetValue(_userRegistryHive, "Twitter_AccessTokenSecret", "", RegistryValueKind.String);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(helpUrl.Text);
            Process.Start(sInfo);
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                MessageBox.Show("Unable to save as there are invalid values in some field(s).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (SaveValues())
            {
                this.Close();
            }
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                MessageBox.Show("Unable to save as there are invalid values in some field(s).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SaveValues();
            }
        }

        private void pollingInterval_TextChanged(object sender, EventArgs e)
        {
            ValidatorIntegerGreaterThanZero(sender);
        }

        private void btnBrowseXmlFilePath_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == folderBrowserDialog.ShowDialog())
            {
                xmlFilePath.Text = folderBrowserDialog.SelectedPath + "\\" + _defaultServiceXmlFile;
            }
        }

        private void btnClearOfflineData_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to remove Facebook persistent\nsession data from registry?\n\n" +
                "You need log in to Facebook next time you start Media Center.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                Registry.SetValue(_userRegistryHive, "Facebook_AccessToken", "", RegistryValueKind.String);
            }
        }
        #endregion
    }
}
