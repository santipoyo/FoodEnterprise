using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;

using MaxCoreBE;
using MaxCoreBLL;
using System.Data;
using System.Xml;
using System.Web.Extensions;

namespace MaxCoreWS
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        [ScriptIgnore]
        List<ClienteDomicilioInfo> clienteDomicilio = new List<ClienteDomicilioInfo>();

        [ScriptIgnore]
        DataSet clienteDomicilioDS = new DataSet();

        [WebMethod]
        public List<ClienteDomicilioInfo> GetClienteDomicilioPorCodigo(String codigoClienteDomicilio)
        {
            ClienteDomicilioLogic clienteDomicilioL = new ClienteDomicilioLogic();

            return clienteDomicilioL.GetClienteDomicilioPorCodigo(codigoClienteDomicilio);
        }

        [WebMethod]
        public DataSet GetClienteDomicilioPorCodigoDS(String codigoClienteDomicilio)
        {
            ClienteDomicilioLogic clienteDomicilioL = new ClienteDomicilioLogic();

            return clienteDomicilioL.GetClienteDomicilioPorCodigoDS(codigoClienteDomicilio);
        }

        [WebMethod]
        public XmlDocument GetClienteDomicilioPorCodigoXML(String codigoClienteDomicilio)
        {
            ClienteDomicilioLogic clienteDomicilioL = new ClienteDomicilioLogic();
            XmlDocument doc = new XmlDocument();

            return clienteDomicilioL.GetClienteDomicilioPorCodigoXML(codigoClienteDomicilio);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public String GetClienteDomicilioPorCodigoJson(String codigoClienteDomicilio)
        {
            ClienteDomicilioLogic clienteDomicilioL = new ClienteDomicilioLogic();
            JavaScriptSerializer serial = new JavaScriptSerializer();
            String strResult = String.Empty;

            clienteDomicilio = clienteDomicilioL.GetClienteDomicilioPorCodigo(codigoClienteDomicilio);
            strResult = serial.Serialize(clienteDomicilio);

            return strResult;
        }
    }
}