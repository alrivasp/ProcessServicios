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
    /// Descripción breve de Process_Tarea
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Process_Tarea : System.Web.Services.WebService
    {

        private TareaNE tareaNE = new TareaNE();

        //////////////////////////////////////
        ////Web Metodos para APP WEB
        //////////////////////////////////////

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertarTarea_Web(string json)
        {
            dynamic dataJson = new ExpandoObject();
            dynamic datosRespuesta = new ExpandoObject();

            try
            {
                CadenaConexion();
                int retorno = 0;
                
                dataJson = JsonConvert.DeserializeObject<dynamic>(json);

                string _nombre = dataJson.NOMBRE;
                string _descripcion = dataJson.DESCRIPCION;
                DateTime _fecha_inicio = dataJson.FECHA_INICIO;
                DateTime _fecha_termino = dataJson.FECHA_TERMINO;
                string _modificacion_usuario_cambio = dataJson.MODIFICACION_USUARIO_CAMBIO;
                int _id_flujo = dataJson.ID_FLUJO;
                int _id_estado_tarea = dataJson.ID_ESTADO_TAREA;
                string _rut_usuario_asignado = dataJson.RUT_USUARIO_ASIGNADO;
                string _rut_usuario_creador = dataJson.RUT_USUARIO_CREADOR;


                retorno = tareaNE.InsertarTarea(_nombre, _descripcion, _fecha_inicio, _fecha_termino, _modificacion_usuario_cambio, _id_flujo, _id_estado_tarea, _rut_usuario_asignado, _rut_usuario_creador);                
                               
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
        public void ActualizarTarea_Web(string json)
        {
            dynamic dataJson = new ExpandoObject();
            dynamic datosRespuesta = new ExpandoObject();

            try
            {
                CadenaConexion();
                int retorno = 0;

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);

                int _id_tarea = dataJson.ID_TAREA;
                string _nombre = dataJson.NOMBRE;
                string _descripcion = dataJson.DESCRIPCION;
                DateTime _fecha_inicio = dataJson.FECHA_INICIO;
                DateTime _fecha_termino = dataJson.FECHA_TERMINO;
                string _modificacion_usuario_cambio = dataJson.MODIFICACION_USUARIO_CAMBIO;
                int _id_flujo = dataJson.ID_FLUJO;
                int _id_estado_tarea = dataJson.ID_ESTADO_TAREA;
                string _rut_usuario_asignado = dataJson.RUT_USUARIO_ASIGNADO;
                string _rut_usuario_creador = dataJson.RUT_USUARIO_CREADOR;


                retorno = tareaNE.ActualizarTarea(_id_tarea, _nombre, _descripcion, _fecha_inicio, _fecha_termino, _modificacion_usuario_cambio, _id_flujo, _id_estado_tarea, _rut_usuario_asignado, _rut_usuario_creador);

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
        public void TraerTodosTarea_Web()
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();

                dynamic dataJson = new ExpandoObject();//Objeto json
                dynamic datosRespuesta = new ExpandoObject();//Objeto respuesta
                dynamic data = new ExpandoObject();

                retorno = tareaNE.TraerTodosTarea();//se envian variables

                data.tarea = retorno.Tables[0];

                datosRespuesta.datos = data; //se pasa respuesta dataset a objeto respuesta

                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(datosRespuesta);//Objeto respuesta se pasa a json
                Context.Response.ContentType = "application/json";
                Context.Response.Write(JSONString);//se responde método

            }
            catch (Exception ex)
            {
                Context.Response.ContentType = "application/json";
                Context.Response.Write("Error : " + ex.Message);
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void TraerTodosTareaFlujo_Web(string json)
        {
            dynamic dataJson = new ExpandoObject();//Objeto json
            dynamic datosRespuesta = new ExpandoObject();//Objeto respuesta
            dynamic data = new ExpandoObject();

            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);

                int _id_flujo = dataJson.id_flujo;
                string _rut_empresa = dataJson.rut_empresa;

                retorno = tareaNE.TraerTodosTareaFlujo(_id_flujo,_rut_empresa);//se envian variables

                if (retorno != null && retorno.Tables.Count > 0)
                {
                    data.tareas = retorno.Tables[0];
                }
                else
                {
                    data.tareas = retorno;
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void TraerTodosTareaUsuario_Web(string json)
        {
            dynamic dataJson = new ExpandoObject();//Objeto json
            dynamic datosRespuesta = new ExpandoObject();//Objeto respuesta
            dynamic data = new ExpandoObject();

            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);

                string _rut_usuario = dataJson.rut_usuario;
                string _rut_empresa = dataJson.rut_empresa;

                retorno = tareaNE.TraerTodosTareaUsuario(_rut_usuario, _rut_empresa);//se envian variables

                if (retorno != null && retorno.Tables.Count > 0)
                {
                    data.tareas = retorno.Tables[0];
                }
                else
                {
                    data.tareas = retorno;
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void TraerTodosTareaSubtareas_Web(string json)
        {
            dynamic dataJson = new ExpandoObject();//Objeto json
            dynamic datosRespuesta = new ExpandoObject();//Objeto respuesta
            dynamic data = new ExpandoObject();

            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);

                int id_tarea = dataJson.id_tarea;
                string _rut_empresa = dataJson.rut_empresa;

                retorno = tareaNE.TraerTodosTareaSubtareas(id_tarea, _rut_empresa);//se envian variables

                if (retorno != null && retorno.Tables.Count > 0)
                {
                    data.tareas = retorno.Tables[0];
                }
                else
                {
                    data.tareas = retorno;
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ValidaSubordinacion_Web(string json)
        {
            dynamic dataJson = new ExpandoObject();//Objeto json
            dynamic datosRespuesta = new ExpandoObject();//Objeto respuesta
            dynamic data = new ExpandoObject();

            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);

                int id_tarea = dataJson.id_tarea;

                retorno = tareaNE.ValidaSubordinacion(id_tarea);//se envian variables

                if (retorno != null && retorno.Tables.Count > 0)
                {
                    data.tareas = retorno.Tables[0];
                }
                else
                {
                    data.tareas = retorno;
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void TraerEstadisticasTarea_Web(string json)
        {
            dynamic dataJson = new ExpandoObject();//Objeto json
            dynamic datosRespuesta = new ExpandoObject();//Objeto respuesta
            dynamic data = new ExpandoObject();

            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);

                string _rut_usuario = dataJson.rut_usuario;
                string _rut_empresa = dataJson.rut_empresa;

                retorno = tareaNE.TraerEstadisticasTarea(_rut_usuario, _rut_empresa);//se envian variables

                if (retorno != null && retorno.Tables.Count > 0)
                {
                    data.estadisticas = retorno.Tables[0];
                }
                else
                {
                    data.estadisticas = retorno;
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void TraerEstadisticasTareaMes_Web(string json)
        {
            dynamic dataJson = new ExpandoObject();//Objeto json
            dynamic datosRespuesta = new ExpandoObject();//Objeto respuesta
            dynamic data = new ExpandoObject();

            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);

                string _rut_usuario = dataJson.rut_usuario;
                string _rut_empresa = dataJson.rut_empresa;
                int mes = dataJson.mes;

                retorno = tareaNE.TraerEstadisticasTareaMes(_rut_usuario, _rut_empresa, mes);//se envian variables

                if (retorno != null && retorno.Tables.Count > 0)
                {
                    data.estadisticas = retorno.Tables[0];
                }
                else
                {
                    data.estadisticas = retorno;
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
