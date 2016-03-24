using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MaxCoreBE;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace MaxCoreDAL
{
    public class ClienteDomicilioDal
    {
        public ClienteDomicilioDal()
        {
        }

        public List<ClienteDomicilioInfo> GetClienteDomicilioPorCodigo(String codigoClienteDomicilio)
        {
            List<ClienteDomicilioInfo> listaClientesDomicilio = new List<ClienteDomicilioInfo>();
            
            using (var entities = new SqlGerenteEntities())
            {
                //entities.Connection.ConnectionString = String.Empty;
                //entities.Connection.ConnectionString = "Data Source=SRVV-DESARROLLO;Initial Catalog=SqlGerente;Persist Security Info=True;User ID=sis_milton;Password=milton*88;";

                List<Cliente_Domicilio> cliDom = entities.Cliente_Domicilio.Where(cli => cli.Cod_Cliente_Domicilio == codigoClienteDomicilio).ToList();

                foreach (Cliente_Domicilio item in cliDom)
                {
                    ClienteDomicilioInfo cliDomInfo = new ClienteDomicilioInfo();

                    cliDomInfo.CodClienteDomicilio = item.Cod_Cliente_Domicilio;
                    cliDomInfo.RucCedula = item.Ruc_Cedula;
                    cliDomInfo.Apellidos = item.Apellidos;
                    cliDomInfo.Nombres = item.Nombres;
                    cliDomInfo.Observaciones = item.Observaciones;
                    cliDomInfo.Email = item.Email;
                    cliDomInfo.Fecha = item.Fecha.Value;
                    cliDomInfo.Ext = item.Ext;
                    cliDomInfo.CodTipoDocumento = item.Cod_Tipo_Documento.Value;

                    listaClientesDomicilio.Add(cliDomInfo);
                }
            }

            return listaClientesDomicilio;
        }
    }
}
