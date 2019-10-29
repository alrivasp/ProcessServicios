using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Oracle.ManagedDataAccess.Client;
using Process.Negocios;
using Process.Modelos;
using System.Web.Script.Services;
using Newtonsoft.Json;
using System.Dynamic;
using System.Data;

namespace Process.Servicios
{
    /// <summary>
    /// Descripción breve de Process_VinculoTarea
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Process_VinculoTarea : System.Web.Services.WebService
    {

        private VinculoTareaNE vinculoTareaNE = new VinculoTareaNE();

        //////////////////////////////////////
        ////Web Metodos para APP WEB
        //////////////////////////////////////

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertarVinculoTarea_Web(string json)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;

                dynamic dataJson = new ExpandoObject();
                dynamic datosRespuesta = new ExpandoObject();

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);

                int _id_tarea_hijo = dataJson.ID_TAREA_HIJO;
                int _id_tarea_padre = dataJson.ID_TAREA_PADRE;
                int _tipo = dataJson.TIPO;

                retorno = vinculoTareaNE.InsertarVinculoTarea(_id_tarea_hijo, _id_tarea_padre, _tipo);
                

                datosRespuesta.datos = retorno;

                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(datosRespuesta);
                Context.Response.ContentType = "application/json";
                Context.Response.Write(JSONString);

            }
            catch (Exception ex)
            {
                Context.Response.ContentType = "application/json";
                Context.Response.Write("Error : " + ex.Message);
            }
        }

        /// <summary>
        /// CONEXION 
        /// </summary>
        public void CadenaConexion()// Método que extrae la conexión del webconfig y la pasa a una variable global para reutilizarla en la capa de datos
        {
            //Support.Support desEncrip = new Support.Support();// Esto es para la encriptación de la conexión
            String cn = "";
            cn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Process"].ConnectionString;
            OracleConnectionStringBuilder cnn = new OracleConnectionStringBuilder(cn);

            string dbs = cnn.DataSource;
            string usid = cnn.UserID;
            //string psw = desEncrip.Deserialice(cnn.Password);
            string psw = cnn.Password;
            string conex = string.Empty;

            conex = "Data Source=" + dbs + "; User ID=" + usid + "; Password=" + psw;

            OracleConnection sqlString = new OracleConnection();
            sqlString.ConnectionString = conex;

            Global.CadenaConexionGlobal = sqlString;
        }
    }
}
