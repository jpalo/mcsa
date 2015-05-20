using System.Collections.Generic;
using System.Text;

namespace Facebook.Utility
{
	internal sealed class StringHelper
	{
		private StringHelper()
		{
		}

		/// <summary>
		/// Convert a collection of strings to a comma separated list.
		/// </summary>
		/// <param name="collection">The collection to convert to a comma separated list.</param>
		/// <returns>comma separated string.</returns>
		internal static string ConvertToCommaSeparated(ICollection<string> collection)
		{
			///
			/// assumed that the average string length is 10 and double the buffer multiplying by 2
			/// if this does not fit in your case, please change the values
			/// 
			int preAllocation = collection.Count*10*2;
			var sb = new StringBuilder(preAllocation);
			int i = 0;
			foreach (string key in collection)
			{
				sb.Append(key);
				if (i < collection.Count - 1)
					sb.Append(",");

				i++;
			}
			return sb.ToString();
		}

//        /// <summary>
//        /// Convert a dictionary to a comma separated list of the dictionary keys.
//        /// </summary>
//        /// <param name="dictionary"></param>
//        /// <returns>comma separated string</returns>
//        internal static string ConvertGroupDictionaryToCommaSeparated(ICollection<string> dictionary) {
//            ///
//            /// assumption is that the average string length is 10 and double the buffer multiplying by 2
//            /// if this does not fit in your case, please change the values
//            /// 
//            int preAllocation = dictionary.Count * 10 * 2;
//            StringBuilder sb = new StringBuilder(preAllocation);
//            int i = 0;
//            foreach (string key in dictionary.Keys) {
//                sb.Append(key);
//                if (i < dictionary.Keys.Count - 1)
//                    sb.Append(",");
//
//                i++;
//            }
//            return sb.ToString();
//        }
//
//        /// <summary>
//        /// Convert a dictionary to a comma separated list of the dictionary keys.
//        /// </summary>
//        /// <param name="dictionary"></param>
//        /// <returns>comma separated string</returns>
//        internal static string ConvertEventDictionaryToCommaSeparated(Dictionary<string, EventUser> dictionary) {
//            ///
//            /// assumption is that the average string length is 10 and double the buffer multiplying by 2
//            /// if this does not fit in your case, please change the values
//            /// 
//            int preAllocation = dictionary.Count * 10 * 2;
//            StringBuilder sb = new StringBuilder(preAllocation);
//            int i = 0;
//            foreach (string key in dictionary.Keys) {
//                sb.Append(key);
//                if (i < dictionary.Keys.Count - 1)
//                    sb.Append(",");
//
//                i++;
//            }
//            return sb.ToString();
//        }
	}
}