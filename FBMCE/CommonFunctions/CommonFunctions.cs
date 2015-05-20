using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace FBMCE
{
    public static class CommonFunctions
    {
        private const string _userRegistryHive = "HKEY_CURRENT_USER\\SOFTWARE\\Hamar Data\\FBMCE";
        private const string _machineRegistryHive = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Hamar Data\\FBMCE";

        /// <summary>
        /// Stores configuration values in registry
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>        
        public static void SetSetting(string key, string value)
        {
            Registry.SetValue(_userRegistryHive, key, value, RegistryValueKind.String);
        }

        /// <summary>
        /// Gets values from registry
        /// </summary>
        /// <param name="key">Registry key name</param>        
        /// <returns>Registry value</returns>
        public static string GetSetting(string key)
        {
            string value;

            if (key.Equals("Facebook_AccessToken") || key.Equals("Twitter_AccessToken") || key.Equals("Twitter_AccessTokenSecret"))
            {
                value = Registry.GetValue(_userRegistryHive, key, null) as string;

                // These are not created when installing application so we should create them now
                if (value == null)
                {
                    SetSetting(key, "");
                    value = "";
                }
            }
            else
            {
                value = Registry.GetValue(_machineRegistryHive, key, null) as string;
            }

            if (value != null)
            {
                return ParseRegistryValue(key, value);
            }
            else
            {
                return "false";
            }
        }

        private static string ParseRegistryValue(string key, string value)
        {
            switch (value)
            {
                case ("0"):
                    return "false";

                case ("1"):
                    return "true";

                default:
                    if (key.StartsWith("EventsEnabled_") || key.StartsWith("ConfirmUpdate_"))
                    {
                        return "false";
                    }
                    else
                    {
                        return value;
                    }
            }
        }
    }
}
