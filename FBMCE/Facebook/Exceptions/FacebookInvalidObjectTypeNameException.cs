using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Facebook.Exceptions
{
    [Serializable]
    class FacebookInvalidObjectTypeNameException : FacebookException
    {
                /// <summary>
        /// Empty constructor.
        /// </summary>
        public FacebookInvalidObjectTypeNameException()
            : base()
        { }

        /// <summary>
        /// Constructor with Error Message.
        /// </summary>
        public FacebookInvalidObjectTypeNameException(string message)
            : base(message)
        { }

        /// <summary>
        /// Exception constructor with a custom message after catching an exception.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Exception caught.</param>
        public FacebookInvalidObjectTypeNameException(string message, Exception innerException)
            : base(message, innerException)
        { }

#if !NETCF
        /// <summary>
        /// Constructor used for serialization.
        /// </summary>
        /// <param name="si">The info.</param>
        /// <param name="sc">The context.</param>
        protected FacebookInvalidObjectTypeNameException(SerializationInfo si, StreamingContext sc)
            : base(si, sc)
        { }
#endif
    }
}
