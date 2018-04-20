using System;
using System.Runtime.Serialization;

namespace Container
{
    [Serializable]
    internal class TypeNotRegisteredExceoption : Exception
    {
        public TypeNotRegisteredExceoption()
        {
        }

        public TypeNotRegisteredExceoption(string message) : base(message)
        {
        }

        public TypeNotRegisteredExceoption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TypeNotRegisteredExceoption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}