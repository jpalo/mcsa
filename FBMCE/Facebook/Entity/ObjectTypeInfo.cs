using System;
using System.Collections.Generic;

namespace Facebook.Entity
{
	[Serializable]
	public class ObjectTypeInfo
	{
		public ObjectTypeInfo()
		{
			Properties = new List<ObjectPropertyInfo>();
		}


		/// <summary>
		/// Name of the object type.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// (Reserved)
		/// </summary>
		public string ObjectClass { get; set; }

		/// <summary>
		/// Properties defined in the type.
		/// </summary>
		public IList<ObjectPropertyInfo> Properties { get; set; }
	}
}