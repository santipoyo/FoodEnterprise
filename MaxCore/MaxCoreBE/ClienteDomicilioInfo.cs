using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaxCoreBE
{
    [Serializable]
    public class ClienteDomicilioInfo
    {
        private String _codClienteDomicilio;

        public String CodClienteDomicilio
        {
            get { return _codClienteDomicilio; }
            set { _codClienteDomicilio = value; }
        }


        private String _rucCedula;

        public String RucCedula
        {
            get { return _rucCedula; }
            set { _rucCedula = value; }
        }


        private String _nombres;

        public String Nombres
        {
            get { return _nombres; }
            set { _nombres = value; }
        }


        private String _apellidos;

        public String Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }


        private String _observaciones;

        public String Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }


        private String _email;

        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }


        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }


        private String _ext;

        public String Ext
        {
            get { return _ext; }
            set { _ext = value; }
        }


        private int _estado;

        public int Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }


        private int _codTipoDocumento;

        public int CodTipoDocumento
        {
            get { return _codTipoDocumento; }
            set { _codTipoDocumento = value; }
        }

        public ClienteDomicilioInfo()
        {
        }

        public ClienteDomicilioInfo(String codClienteDomicilio, String rucCedula, String nombres, String apellidos, String observaciones, String email, DateTime fecha, String ext, int estado, int codTipoDocumento)
        {
            _codClienteDomicilio = codClienteDomicilio;
            _rucCedula = rucCedula;
            _nombres = nombres;
            _apellidos = apellidos;
            _observaciones = observaciones;
            _email = email;
            _fecha = fecha;
            _ext = ext;
            _estado = estado;
            _codTipoDocumento = codTipoDocumento;
        }

    }
}
