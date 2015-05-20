using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Facebook.Entity;
using Facebook.Exceptions;
using Facebook.Parser;
using Facebook.Utility;

namespace Facebook.API
{
	public partial class FacebookAPI
	{		
        internal void AddOptionalParameter(IDictionary<string, string> dict, string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                dict.Add(key, value);
            }
        }

        internal void AddOptionalParameter(IDictionary<string, string> dict, string key, int value)
        {
            if (value >= 0)
            {
                dict.Add(key, value.ToString());
            }
        }

        internal void AddOptionalParameter(IDictionary<string, string> dict, string key, int? value)
        {
            if (value != null)
            {
                AddOptionalParameter(dict, key, value.Value);
            }
        }
	}
}