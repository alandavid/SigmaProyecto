using System;


namespace ninja.common.Exception
{
    [Serializable]
    public class MockRepositoryInsertException : System.Exception
    {
        private const string Mensaje = "No se pudo insertar la entidad, error";

        public MockRepositoryInsertException() : base(Mensaje) { }

        public MockRepositoryInsertException(System.Exception inner) : base(Mensaje, inner) { }

        protected MockRepositoryInsertException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
