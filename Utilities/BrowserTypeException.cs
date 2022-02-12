using System;
using System.Runtime.Serialization;

namespace RegistrationTests.Utilities
{
    [Serializable]
    internal class BrowserTypeException : Exception
    {
        public BrowserTypeException()
        {
        }

        public BrowserTypeException(string message) : base("Unsupported browser type " + message)
        {
            
        }

        public BrowserTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BrowserTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}