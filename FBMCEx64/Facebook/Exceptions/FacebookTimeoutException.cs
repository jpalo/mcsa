using System;
#if !NETCF

#endif

namespace Facebook.Exceptions
{
	/// <summary>
	/// Exception returned for ERRORNO 102
	/// </summary>
	[Serializable]
	public class FacebookTimeoutException : FacebookException
	{
		/// <summary>
		/// Empty constructor.
		/// </summary>
		public FacebookTimeoutException()
		{
		}

		/// <summary>
		/// Constructor with Error Message.
		/// </summary>
		public FacebookTimeoutException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Exception constructor with a custom message after catching an exception.
		/// </summary>
		/// <param name="message">Exception message.</param>
		/// <param name="innerException">Exception caught.</param>
		public FacebookTimeoutException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

#if !NETCF
		/// <summary>
		/// Constructor used for serialization.
		/// </summary>
		/// <param name="si">The info.</param>
		/// <param name="sc">The context.</param>
		protected FacebookTimeoutException(System.Runtime.Serialization.SerializationInfo si, System.Runtime.Serialization.StreamingContext sc)
			: base(si, sc)
		{
		}
#endif
	}
}