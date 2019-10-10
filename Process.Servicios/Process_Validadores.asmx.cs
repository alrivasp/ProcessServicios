using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Process.Negocios;

namespace Process.Servicios
{
    /// <summary>
    /// Descripción breve de Process_Validadores
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Process_Validadores : System.Web.Services.WebService
    {

        [WebMethod]
        public bool numeroValidacionService(string num)
        {
            ValidadoresNE auxNegocio = new ValidadoresNE();
            return auxNegocio.IsNumeric(num);
        }

        [WebMethod]
        public bool rutValidacionService(string rut)
        {
            ValidadoresNE auxNegocio = new ValidadoresNE();
            return auxNegocio.validarRut(rut);
        }

        [WebMethod]
        public bool correoValidacionService(string email)
        {
            ValidadoresNE auxNegocio = new ValidadoresNE();
            return auxNegocio.validaCorreo(email);
        }
    }
}
