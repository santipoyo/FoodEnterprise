using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MaxCoreBE;
using MaxCoreDAL;
using System.Data;
using System.Xml;

namespace MaxCoreBLL
{
    public class ClienteDomicilioLogic
    {
        public ClienteDomicilioLogic()
        {
        }

        public List<ClienteDomicilioInfo> GetClienteDomicilioPorCodigo(String codigoClienteDomicilio)
        {
            List<ClienteDomicilioInfo> clienteDomicilio = new List<ClienteDomicilioInfo>();

            clienteDomicilio = (new MaxCoreDAL.ClienteDomicilioDal()).GetClienteDomicilioPorCodigo(codigoClienteDomicilio);

            return clienteDomicilio;
        }

        public DataSet GetClienteDomicilioPorCodigoDS(String codigoClienteDomicilio)
        {
            List<ClienteDomicilioInfo> clienteDomicilio = new List<ClienteDomicilioInfo>();

            clienteDomicilio = (new MaxCoreDAL.ClienteDomicilioDal()).GetClienteDomicilioPorCodigo(codigoClienteDomicilio);

            return GenericsExtension.ConvertGenericList(clienteDomicilio);
        }

        public XmlDocument GetClienteDomicilioPorCodigoXML(String codigoClienteDomicilio)
        {
            List<ClienteDomicilioInfo> clienteDomicilio = new List<ClienteDomicilioInfo>();

            clienteDomicilio = (new MaxCoreDAL.ClienteDomicilioDal()).GetClienteDomicilioPorCodigo(codigoClienteDomicilio);

            return GenericsExtension.ConvertListToXML(clienteDomicilio);
        }
    }
}
