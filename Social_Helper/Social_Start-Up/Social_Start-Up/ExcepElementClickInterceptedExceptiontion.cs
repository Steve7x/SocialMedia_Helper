using System;
using System.Runtime.Serialization;

namespace Social_Start_Up
{
    [Serializable]
    internal class ExcepElementClickInterceptedExceptiontion : Exception
    {
        public ExcepElementClickInterceptedExceptiontion()
        {
        }

        public ExcepElementClickInterceptedExceptiontion(string message) : base(message)
        {
        }

        public ExcepElementClickInterceptedExceptiontion(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExcepElementClickInterceptedExceptiontion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}