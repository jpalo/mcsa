using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Facebook.Utility
{
    public class JSONHelper
    {
        public static string ConvertToJSONAssociativeArray(Dictionary<string, string> dict)
        {
            var elements = new List<string>();

            foreach (var pair in dict)
            {
                if (!string.IsNullOrEmpty(pair.Value))
                {
                    elements.Add(string.Format("\"{0}\":{2}{1}{2}", EscapeJsonString(pair.Key), EscapeJsonString(pair.Value), IsJSONArray(pair.Value) || IsBoolean(pair.Value) ? string.Empty : "\""));
                }
            }
            return "{" + string.Join(",", elements.ToArray()) + "}";
        }
        public static bool IsJSONArray(string test)
        {
            return test.StartsWith("{") && !test.StartsWith("{*") || test.StartsWith("[");
        }
        public static bool IsBoolean(string test)
        {
            return test.Equals("false") || test.Equals("true");
        }
        public static string ConvertToJSONArray(List<string> list)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            foreach (var item in list)
            {
                builder.Append(string.Format("{0}{1}{0},", IsJSONArray(item) || IsBoolean(item) ? string.Empty : "\"", EscapeJsonString(item)));
            }
            builder.Replace(",", "]", builder.Length - 1, 1);
            return builder.ToString();
        }
        public static string ConvertToJSONArray(List<long> list)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            foreach (var item in list)
            {
                builder.Append(string.Format("{0}{1}{0},", IsJSONArray(item.ToString()) || IsBoolean(item.ToString()) ? string.Empty : "\"", EscapeJsonString(item.ToString())));
            }
            builder.Replace(",", "]", builder.Length - 1, 1);
            return builder.ToString();
        }

        public static List<string> ConvertFromJSONArray(string array)
        {
            if (!string.IsNullOrEmpty(array))
            {
                array = array.Replace("[", "").Replace("]", "").Replace("\"", "");
                return new List<string>(array.Split(','));
            }
            else
            {
                return new List<string>();
            }
        }
        public static Dictionary<string, string> ConvertFromJSONAssoicativeArray(string array)
        {
            var dict = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(array))
            {
                array = array.Replace("{", "").Replace("}", "").Replace("\":", "|").Replace("\"", "").Replace("\\/", "/");
                var pairs = new List<string>(array.Split(','));
                foreach (var pair in pairs)
                {
                    if (!string.IsNullOrEmpty(pair))
                    {
                        var pairArray = pair.Split('|');
                        dict.Add(pairArray[0], pairArray[1]);
                    }
                }
                return dict;
            }
            else
            {
                return new Dictionary<string, string>();
            }
        }
        /// <summary>
        /// Escape backslashes and double quotes
        /// </summary>
        /// <param name="originalString">string</param>
        /// <returns>string</returns>
        internal static string EscapeJsonString(string originalString)
        {
            return IsJSONArray(originalString) ? originalString : originalString.Replace("\\/", "/").Replace("/", "\\/").Replace("\\\"", "\"").Replace("\"", "\\\"");
        }
    }
}
