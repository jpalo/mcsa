using System;

namespace Facebook.Entity
{
	[Serializable]
	public class ObjectPropertyInfo
	{
		public string Name { get; set; }

		public ObjectPropertyType DataType { get; set; }

		/// <summary>
		/// (reserved)
		/// </summary>
		public int IndexType { get; set; }
	}
}