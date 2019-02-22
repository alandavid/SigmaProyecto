using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ninja.Mapping
{
    [Serializable]
    public class NonTransformableException : Exception
    {
        public NonTransformableException() { }

        public NonTransformableException(string message) : base(message) { }

        public NonTransformableException(string message, Exception inner) : base(message, inner) { }

        protected NonTransformableException(
          SerializationInfo info,
          StreamingContext context)
            : base(info, context) { }
    }
}