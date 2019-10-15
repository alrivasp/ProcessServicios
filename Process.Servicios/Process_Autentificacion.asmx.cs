using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Oracle.ManagedDataAccess.Client;
using Process.Negocios;
using Process.Modelos;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using Newtonsoft.Json;
using System.Dynamic;
using System.IO;

namespace Process.Servicios
{
    /// <summary>
    /// Descripción breve de Process_Autentificacion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Process_Autentificacion : System.Web.Services.WebService
    {

        private AutentificacionNE autentificacionNE = new AutentificacionNE();

        //////////////////////////////////////
        ////Web Metodos para APP de Escritorio
        //////////////////////////////////////

        [WebMethod]
        public int Login_Escritorio(string _rut_usuario, string _contrasena)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = autentificacionNE.Login(_rut_usuario, _contrasena);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }

           
        }

        [WebMethod]
        public DataSet TraerSesionUsuario_Escritorio(string _rut_usuario)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                string _rut_empresa = string.Empty;
                retorno = autentificacionNE.TraerSesionUsuario(_rut_usuario, _rut_empresa);
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }


        }

        //////////////////////////////////////
        ////Web Metodos para APP WEB
        //////////////////////////////////////

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Login_Web(string json)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;

                dynamic dataJson = new ExpandoObject(); //Objeto json
                dynamic datosRespuesta = new ExpandoObject();//Objeto respuesta

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);//Se lee el json

                string _rut_usuario = dataJson.rut_usuario;
                string _contrasena = dataJson.contrasena;

                retorno = autentificacionNE.Login(_rut_usuario, _contrasena);//se envian variables

                datosRespuesta.datos = retorno; //se pasa respuesta dataset a objeto respuesta

                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(datosRespuesta);//Objeto respuesta se pasa a json
                Context.Response.ContentType = "application/json";
                Context.Response.Write(JSONString);//se responde método

            }
            catch (Exception ex)
            {
                Context.Response.ContentType = "application/json";
                Context.Response.Write("Error : "+ex.Message);
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void TraerSesionUsuario_Web(string json)
        {
            try
            {
                CadenaConexion();
                DataSet retornoSesion = new DataSet();
                DataSet retornoPermisos = new DataSet();

                dynamic dataJson = new ExpandoObject();//Objeto json
                dynamic datosRespuesta = new ExpandoObject();//Objeto respuesta
                dynamic data = new ExpandoObject();

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);//Se lee el json

                string _rut_usuario = dataJson.rut_usuario;
                string _rut_empresa = dataJson.rut_empresa;

                retornoSesion = autentificacionNE.TraerSesionUsuario(_rut_usuario, _rut_empresa);//se envian variables
                retornoPermisos = autentificacionNE.TraerPermisosUsuario(_rut_usuario, _rut_empresa);

                data.sesion = retornoSesion.Tables[0];
                data.permisos = retornoPermisos.Tables[0];

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
