using System;

namespace WAApuestas
{
    public class GestionApuestasException: Exception
    {
        public int CodigoError { get; private set; }

        public GestionApuestasException()
        {

        }

        public GestionApuestasException(string mensaje) : base(mensaje)
        { }


        public GestionApuestasException(string mensaje, Exception innerException) : base(mensaje, innerException)
        { }

        public GestionApuestasException(string mensaje, int _codigoError) : base(mensaje)
        {
            this.CodigoError = _codigoError;
        }


        public GestionApuestasException(string mensaje, int _codigoError, Exception innerException) : base(mensaje, innerException)
        {
            this.CodigoError = _codigoError;
        }

    }
}
