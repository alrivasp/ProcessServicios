using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Oracle.ManagedDataAccess.Client;
using Process.Modelos;
using Process.Negocios;
using System.Data;
using System.Web.Script.Services;
using System.Dynamic;
using Newtonsoft.Json;

namespace Process.Servicios
{
    /// <summary>
    /// Descripción breve de Process_UsuarioEquipo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Process_UsuarioEquipo : System.Web.Services.WebService
    {

        private UsuarioEquipoNE usuarioEquipoNE = new UsuarioEquipoNE();
        private UsuarioEquipo usuarioEquipo = new UsuarioEquipo();

        //////////////////////////////////////
        ////Web Metodos para APP de Escritorio
        //////////////////////////////////////
        [WebMethod]
        public int InsertarUsuarioEquipoSinEntidad_Escritorio(string _rut_usuario, int _id_equipo, int _responsable)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = usuarioEquipoNE.InsertarUsuarioEquipoSinEntidad(_rut_usuario, _id_equipo, _responsable);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int ActualizarUsuarioEquipoSinEntidad_Escritorio(string _rut_usuario, int _id_equipo, int _responsable)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = usuarioEquipoNE.ActualizarUsuarioEquipoSinEntidad(_rut_usuario, _id_equipo, _responsable);

                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public UsuarioEquipo TraerUsuarioEquiPorEquipoPorRutConEntidad_Escritorio(int _id_equipo, string _rut_usuario)
        {
            try
            {
                CadenaConexion();
                UsuarioEquipo retorno = new UsuarioEquipo();
                retorno = usuarioEquipoNE.TraerUsuarioEquiPorEquipoPorRutConEntidad(_id_equipo, _rut_usuario);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerUsuarioEquipoSinEntidad_Escritorio(int _id_equipo)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = usuarioEquipoNE.TraerUsuarioEquipoSinEntidad(_id_equipo);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public int EliminarUsuarioEquipoSinEntidad_Escritorio(int _id_equipo)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = usuarioEquipoNE.EliminarUsuarioEquipoSinEntidad(_id_equipo);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        //////////////////////////////////////
        ////Web Metodos para APP WEB
        //////////////////////////////////////

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void TraerUsuariosEquipo_Web(string json)
        {
            dynamic datosRespuesta = new ExpandoObject();
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();

                dynamic dataJson = new ExpandoObject();

                dynamic data = new ExpandoObject();

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);//Se lee el json

                int _id_equipo = dataJson.id_equipo;

                retorno = usuarioEquipoNE.TraerUsuariosEquipo(_id_equipo);//se envian variables

                if (retorno != null && retorno.Tables.Count > 0)
                {
                    data.usuarios = retorno.Tables[0];
                }
                else
                {
                    data.usuarios = retorno;
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
