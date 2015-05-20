using System;

namespace Facebook.Entity
{
	[Serializable]
	public class DataAssociation
	{
		public string Name { get; set; }

		public long ID1 { get; set; }

		public long ID2 { get; set; }

		public string Data { get; set; }

		public DateTime? Time { get; set; }
	}
}