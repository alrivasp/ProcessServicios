﻿using System;
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
    /// Descripción breve de Process_Flujo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Process_Flujo : System.Web.Services.WebService
    {

        private FlujoNE flujoNE = new FlujoNE();

        //////////////////////////////////////
        ////Web Metodos para APP WEB
        //////////////////////////////////////

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertarFlujo_Web(string json)
        {
            dynamic dataJson = new ExpandoObject();
            dynamic datosRespuesta = new ExpandoObject();

            try
            {
                CadenaConexion();
                int retorno = 0;      

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);

                int _id_equipo = dataJson.ID_EQUIPO;
                string _rut_usuario_creador = dataJson.RUT_USUARIO_CREADOR;
                string _nombre = dataJson.NOMBRE;

                retorno = flujoNE.InsertarFlujo(_id_equipo, _rut_usuario_creador, _nombre);

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
        public void ActualizarFlujo_Web(string json)
        {
            dynamic dataJson = new ExpandoObject();
            dynamic datosRespuesta = new ExpandoObject();

            try
            {
                CadenaConexion();
                int retorno = 0;

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);

                int _id_flujo = dataJson.ID_FLUJO;
                string _modificacion_usuario = dataJson.MODIFICACION_USUARIO;
                int _id_equipo = dataJson.ID_EQUIPO;
                string _nombre = dataJson.NOMBRE;

                retorno = flujoNE.ActualizarFlujo(_id_flujo,_modificacion_usuario, _id_equipo, _nombre);

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
        public void ImplementarFlujo_Web(string json)
        {
            dynamic dataJson = new ExpandoObject();
            dynamic datosRespuesta = new ExpandoObject();

            try
            {
                CadenaConexion();
                int retorno = 0;

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);

                int _id_flujo = dataJson.ID_FLUJO;
                string _modificacion_usuario = dataJson.MODIFICACION_USUARIO;
                int _id_equipo = dataJson.ID_EQUIPO;
                string _nombre = dataJson.NOMBRE;

                retorno = flujoNE.ImplementarFlujo(_id_flujo, _modificacion_usuario, _id_equipo, _nombre);

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
        public void TraerTodosFlujo_Web()
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();

                dynamic dataJson = new ExpandoObject();//Objeto json
                dynamic datosRespuesta = new ExpandoObject();//Objeto respuesta
                dynamic data = new ExpandoObject();

                retorno = flujoNE.TraerTodosFlujo();//se envian variables

                data.archivos = retorno.Tables[0];

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
        public void TraerTodosFlujoUsuario_Web(string json)
        {
            dynamic datosRespuesta = new ExpandoObject();
            try
            {
                CadenaConexion();
                DataSet retornoFlujos = new DataSet();

                dynamic dataJson = new ExpandoObject();

                dynamic data = new ExpandoObject();

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);//Se lee el json

                string _rut_usuario = dataJson.rut_usuario;
                string _rut_empresa = dataJson.rut_empresa;

                retornoFlujos = flujoNE.TraerTodosFlujoUsuario(_rut_usuario, _rut_empresa);//se envian variables

                if (retornoFlujos != null && retornoFlujos.Tables.Count > 0)
                {
                    data.flujos = retornoFlujos.Tables[0];
                }
                else
                {
                    data.flujos = retornoFlujos;
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
        public void TraerFlujo_Web(string json)
        {
            dynamic datosRespuesta = new ExpandoObject();
            try
            {
                CadenaConexion();
                DataSet retornoFlujos = new DataSet();

                dynamic dataJson = new ExpandoObject();

                dynamic data = new ExpandoObject();

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);//Se lee el json

                int _id_flujo = dataJson.id_flujo;

                retornoFlujos = flujoNE.TraerFlujo(_id_flujo);//se envian variables

                if (retornoFlujos != null && retornoFlujos.Tables.Count > 0)
                {
                    data.flujos = retornoFlujos.Tables[0];
                }
                else
                {
                    data.flujos = retornoFlujos;
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
        public void TraerEstadisticasFlujo_Web(string json)
        {
            dynamic datosRespuesta = new ExpandoObject();
            try
            {
                CadenaConexion();
                DataSet retornoFlujos = new DataSet();

                dynamic dataJson = new ExpandoObject();

                dynamic data = new ExpandoObject();

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);//Se lee el json

                string _rut_usuario = dataJson.rut_usuario;
                string _rut_empresa = dataJson.rut_empresa;

                retornoFlujos = flujoNE.TraerEstadisticasFlujo(_rut_usuario, _rut_empresa);//se envian variables

                if (retornoFlujos != null && retornoFlujos.Tables.Count > 0)
                {
                    data.estadisticas = retornoFlujos.Tables[0];
                }
                else
                {
                    data.estadisticas = retornoFlujos;
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
