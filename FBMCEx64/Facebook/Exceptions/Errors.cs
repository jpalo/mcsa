using System;

namespace Facebook.Exceptions
{
	[Serializable]
	internal sealed class Errors
	{
		private Errors()
		{
		}

		#region Nested type: ErrorCodes

		internal enum ErrorCodes
		{
			Unknown = 1,
			Unavailable = 2,
			MaxRequestLimit = 3,
			RemoteAddressDenied = 5,
			InvalidParameters = 101,
			InvalidAPIKey = 100,
			IncorrectSignature = 104
		}

		#endregion
	}
}