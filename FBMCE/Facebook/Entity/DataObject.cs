using System;
using System.Collections.Generic;

namespace Facebook.Entity
{
	[Serializable]
	public class DataObject
	{
		private readonly Dictionary<string, string> _properties;


		public DataObject()
		{
			_properties = new Dictionary<string, string>();
		}


		public long ID { get; set; }

		public Dictionary<string, string> Properties
		{
			get { return _properties; }
		}
	}
}