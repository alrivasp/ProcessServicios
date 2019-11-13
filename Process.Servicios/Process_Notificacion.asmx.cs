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
    /// Descripción breve de Process_Notificacion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Process_Notificacion : System.Web.Services.WebService
    {
        private NotificacionNE notificacionNE = new NotificacionNE();

        //////////////////////////////////////
        ////Web Metodos para APP WEB
        //////////////////////////////////////

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void notificacionAsignacion_Web(string json)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;

                dynamic dataJson = new ExpandoObject();
                dynamic datosRespuesta = new ExpandoObject();

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);

                string _correo_destino = dataJson.CORREO_DESTINO;
                int _id_tarea = dataJson.ID_TAREA;
                string _nombre_tarea = dataJson.NOMBRE_TAREA;
                string _flujo_nombre = dataJson.FLUJO_NOMBRE;
                string _nombre_funcionario_destino = dataJson.NOMBRE_FUNCIONARIO_DESTINO;
                string _nombre_funcionario_origen = dataJson.NOMBRE_FUNCIONARIO_ORIGEN;                              
                string _nombre_equipo = dataJson.NOMBRE_EQUIPO;
                string _nombre_unidad = dataJson.NOMBRE_UNIDAD;
                string _nombre_empresa = dataJson.NOMBRE_EMPRESA;


                retorno = notificacionNE.notificacionAsignacion(_correo_destino, _id_tarea, _nombre_tarea, _flujo_nombre, _nombre_funcionario_destino, _nombre_funcionario_origen, _nombre_equipo, _nombre_unidad,_nombre_empresa);

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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void notificacionRechazo_Web(string json)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;

                dynamic dataJson = new ExpandoObject();
                dynamic datosRespuesta = new ExpandoObject();

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);

                string _correo_destino = dataJson.CORREO_DESTINO;
                int _id_tarea = dataJson.ID_TAREA;
                string _nombre_tarea = dataJson.NOMBRE_TAREA;
                string _flujo_nombre = dataJson.FLUJO_NOMBRE;
                string _nombre_funcionario_destino = dataJson.NOMBRE_FUNCIONARIO_DESTINO;
                string _nombre_funcionario_origen = dataJson.NOMBRE_FUNCIONARIO_ORIGEN;
                string _nombre_equipo = dataJson.NOMBRE_EQUIPO;
                string _nombre_unidad = dataJson.NOMBRE_UNIDAD;
                string _nombre_empresa = dataJson.NOMBRE_EMPRESA;
                string _motivo = dataJson.MOTIVO;


                retorno = notificacionNE.notificacionRechazo(_correo_destino, _id_tarea, _nombre_tarea, _flujo_nombre, _nombre_funcionario_destino, _nombre_funcionario_origen, _nombre_equipo, _nombre_unidad, _nombre_empresa, _motivo);

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
