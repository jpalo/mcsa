using System;

namespace Facebook.Entity
{
	[Serializable]
	public class Status
	{
		#region Private Data

		#endregion Private Data

		#region Properties

		/// <summary>
		/// Message
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Time
		/// </summary>
		public DateTime Time { get; set; }

		#endregion Properties
	}
}