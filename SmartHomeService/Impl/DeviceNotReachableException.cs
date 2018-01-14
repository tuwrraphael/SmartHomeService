using System;
using System.Runtime.Serialization;

namespace SmartHomeService.Impl
{
    [Serializable]
    internal class DeviceNotReachableException : Exception
    {
        public DeviceNotReachableException()
        {
        }

        public DeviceNotReachableException(string message) : base(message)
        {
        }

        public DeviceNotReachableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DeviceNotReachableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}