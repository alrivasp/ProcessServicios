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
    /// Descripción breve de Process_TareaTipo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Process_TareaTipo : System.Web.Services.WebService
    {

        private TareaTipoNE tareaTipoNE = new TareaTipoNE();

        //////////////////////////////////////
        ////Web Metodos para APP WEB
        //////////////////////////////////////

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertarTareaTipo_Web(string json)
        {
            dynamic datosRespuesta = new ExpandoObject();
            try
            {
                CadenaConexion();
                int retorno = 0;

                dynamic dataJson = new ExpandoObject();
                dynamic tareasTipo = new ExpandoObject();

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);

                tareasTipo = dataJson.tareasTipo;

                foreach (var item in tareasTipo)
                {
                    retorno = tareaTipoNE.InsertarTareaTipo(
                        Convert.ToString(item["NOMBRE"]),
                        Convert.ToString(item["DESCRIPCION"]),
                        Convert.ToInt32(item["CANTIDAD_DIAS"]),
                        Convert.ToInt32(item["ID_FLUJO_TIPO"]));
                }
                
                datosRespuesta.datos = retorno;

                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(datosRespuesta);
                Context.Response.ContentType = "application/json";
                Context.Response.Write(JSONString);

            }
            catch (Exception ex)
            {
                dynamic dataError = new ExpandoObject();
                dataError.error = ex.Message;
                datosRespuesta.datos = dataError;

                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(datosRespuesta);
                Context.Response.ContentType = "application/json";
                Context.Response.Write(JSONString);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ActualizarTareaTipo_Web(string json)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;

                dynamic dataJson = new ExpandoObject();
                dynamic datosRespuesta = new ExpandoObject();

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);

                int _id_tarea_tipo = dataJson.ID_TAREA_TIPO;
                string _nombre = dataJson.NOMBRE;
                string _descripcion = dataJson.DESCRIPCION;
                int _cantidad_dias = dataJson.CANTIDAD_DIAS;
                int _id_flujo_tipo = dataJson.ID_FLUJO_TIPO;

                retorno = tareaTipoNE.ActualizarTareaTipo(_id_tarea_tipo, _nombre, _descripcion, _cantidad_dias, _id_flujo_tipo);

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
        public void EliminarTareaTipo_Web(string json)
        {
            dynamic datosRespuesta = new ExpandoObject();

            try
            {
                CadenaConexion();
                int retorno = 0;

                dynamic dataJson = new ExpandoObject();
                dynamic flujosTipoUnidades = new ExpandoObject();

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);

                int _id_flujo_tipo = dataJson.id_flujo_tipo;

                retorno = tareaTipoNE.EliminarTareaTipo(_id_flujo_tipo);

                datosRespuesta.datos = retorno;

                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(datosRespuesta);
                Context.Response.ContentType = "application/json";
                Context.Response.Write(JSONString);

            }
            catch (Exception ex)
            {
                dynamic dataError = new ExpandoObject();
                dataError.error = ex.Message;
                datosRespuesta.datos = dataError;

                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(datosRespuesta);
                Context.Response.ContentType = "application/json";
                Context.Response.Write(JSONString);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void TraerTodosTareaTipo_Web(string json)
        {
            dynamic datosRespuesta = new ExpandoObject();
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();

                dynamic dataJson = new ExpandoObject();//Objeto json
                dynamic data = new ExpandoObject();

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);

                string _id_tipo_flujo = dataJson.id_flujo_tipo;

                retorno = tareaTipoNE.TraerTodosTareaTipo(_id_tipo_flujo);//se envian variables

                if (retorno != null && retorno.Tables.Count > 0)
                {
                    data.tareasTipo = retorno.Tables[0];
                }
                else
                {
                    data.tareasTipo = retorno;
                }

                datosRespuesta.datos = data; //se pasa respuesta dataset a objeto respuesta

                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(datosRespuesta);//Objeto respuesta se pasa a json
                Context.Response.ContentType = "application/json";
                Context.Response.Write(JSONString);//se responde método

            }
            catch (Exception ex)
            {
                dynamic dataError = new ExpandoObject();
                dataError.error = ex.Message;
                datosRespuesta.datos = dataError;

                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(datosRespuesta);
                Context.Response.ContentType = "application/json";
                Context.Response.Write(JSONString);
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
