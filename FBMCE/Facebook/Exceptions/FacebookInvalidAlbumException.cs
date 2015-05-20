using System;
#if !NETCF

#endif

namespace Facebook.Exceptions
{
	/// <summary>
	/// Exception returned for ERRORNO 120
	/// </summary>
	[Serializable]
	public class FacebookInvalidAlbumException : FacebookException
	{
		/// <summary>
		/// Empty constructor.
		/// </summary>
		public FacebookInvalidAlbumException()
		{
		}

		/// <summary>
		/// Constructor with Error Message.
		/// </summary>
		public FacebookInvalidAlbumException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Exception constructor with a custom message after catching an exception.
		/// </summary>
		/// <param name="message">Exception message.</param>
		/// <param name="innerException">Exception caught.</param>
		public FacebookInvalidAlbumException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

#if !NETCF
		/// <summary>
		/// Constructor used for serialization.
		/// </summary>
		/// <param name="si">The info.</param>
		/// <param name="sc">The context.</param>
		protected FacebookInvalidAlbumException(System.Runtime.Serialization.SerializationInfo si, System.Runtime.Serialization.StreamingContext sc)
			: base(si, sc)
		{
		}
#endif
	}
}