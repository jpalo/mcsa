using System;

namespace Facebook.Entity
{
	[Serializable]
	public class DataAssociationInfo
	{
		public DataAssociationInfo()
			: this(null, null, false)
		{
		}

		public DataAssociationInfo(string alias)
			: this(alias, null, false)
		{
		}

		public DataAssociationInfo(string alias, string objectType)
			: this(alias, objectType, false)
		{
		}

		public DataAssociationInfo(string alias, string objectType, bool unique)
		{
			Alias = alias;
			ObjectType = objectType;
			Unique = unique;
		}


		public string Alias { get; set; }

		public string ObjectType { get; set; }

		public bool Unique { get; set; }
	}
}