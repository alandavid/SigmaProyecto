using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ninja.common.Exception
{
    [Serializable]
    public class WindsorMisconfiguredHandlersException : System.Exception
    {
        private const string Msg = "Windsor tiene componentes mal configurados o dependencias sin registrar; Para mas información, depurar la creación del container";

        public string[] components { get; set; }

        public WindsorMisconfiguredHandlersException() { }
        public WindsorMisconfiguredHandlersException(string[] components)
            : base(Msg)
        {
            this.components = components;
        }
        public WindsorMisconfiguredHandlersException(string[] components, System.Exception inner)
            : base(Msg, inner)
        {
            this.components = components;
        }
        protected WindsorMisconfiguredHandlersException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
