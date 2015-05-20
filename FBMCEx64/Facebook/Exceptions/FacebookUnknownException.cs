using System;
#if !NETCF

#endif

namespace Facebook.Exceptions
{
	/// <summary>
	/// Exception returned for ERRORNO 1
	/// </summary>
	[Serializable]
	public class FacebookUnknownException : FacebookException
	{
		/// <summary>
		/// Empty constructor.
		/// </summary>
		public FacebookUnknownException()
		{
		}

		/// <summary>
		/// Constructor with Error Message.
		/// </summary>
		public FacebookUnknownException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Exception constructor with a custom message after catching an exception.
		/// </summary>
		/// <param name="message">Exception message.</param>
		/// <param name="innerException">Exception caught.</param>
		public FacebookUnknownException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

#if !NETCF
		/// <summary>
		/// Constructor used for serialization.
		/// </summary>
		/// <param name="si">The info.</param>
		/// <param name="sc">The context.</param>
		protected FacebookUnknownException(System.Runtime.Serialization.SerializationInfo si, System.Runtime.Serialization.StreamingContext sc)
			: base(si, sc)
		{
		}
#endif
	}
}