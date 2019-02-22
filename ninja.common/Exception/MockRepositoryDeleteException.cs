using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ninja.common.Exception
{
   public class MockRepositoryDeleteException : System.Exception
    {
        private const string Mensaje = "No se pudo Eliminar la entidad, error";

        public MockRepositoryDeleteException() : base(Mensaje) { }

        public MockRepositoryDeleteException(System.Exception inner) : base(Mensaje, inner) { }

        protected MockRepositoryDeleteException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
