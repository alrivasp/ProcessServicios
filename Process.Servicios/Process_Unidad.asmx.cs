using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Process.Modelos;
using Process.Negocios;
using System.Data;
using System.Web.Script.Services;
using Newtonsoft.Json;
using System.Dynamic;

namespace Process.Servicios
{
    /// <summary>
    /// Descripción breve de Process_Unidad
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Process_Unidad : System.Web.Services.WebService
    {
        private UnidadNE unidadNE = new UnidadNE();
        private Unidad unidad = new Unidad();

        //////////////////////////////////////
        ////Web Metodos para APP de Escritorio
        //////////////////////////////////////
        [WebMethod]
        public int InsertarUnidadConEntidad_Escritorio(DataSet _unidad)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                unidad = new Unidad();
                unidad.FillFromDataSet(_unidad);
                retorno = unidadNE.InsertarUnidadConEntidad(unidad);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int InsertarUnidadSinEntidad_Escritorio(string _nombre, string _descripcion, int _estado, string _rut_empresa)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = unidadNE.InsertarUnidadSinEntidad(_nombre, _descripcion, _estado, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int ActualizarUnidadConEntidad_Escritorio(DataSet _unidad)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                unidad = new Unidad();
                unidad.FillFromDataSet(_unidad);
                retorno = unidadNE.ActualizarUnidadConEntidad(unidad);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int ActualizarUnidadSinEntidad_Escritorio(int _id_unidad, string _nombre, string _descripcion, int _estado, string _rut_empresa)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = unidadNE.ActualizarUnidadSinEntidad(_id_unidad, _nombre, _descripcion, _estado, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public DataSet TraerUnidadSinEntidad_Escritorio(int _id_unidad, string _rut_empresa)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = unidadNE.TraerUnidadSinEntidad(_id_unidad, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerUnidadPorEmpresaSinEntidad_Escritorio(string _rut_empresa)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = unidadNE.TraerUnidadPorEmpresaSinEntidad(_rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public Unidad TraerUnidadConEntidad_Escritorio(int _id_unidad, string _rut_empresa)
        {
            try
            {
                CadenaConexion();
                Unidad retorno = new Unidad();
                retorno = unidadNE.TraerUnidadConEntidad(_id_unidad, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public Unidad TraerUnidadPorNombrePorEmpresaConEntidad_Escritorio(string _nombre, string _rut_empresa)
        {
            try
            {
                CadenaConexion();
                Unidad retorno = new Unidad();
                retorno = unidadNE.TraerUnidadPorNombrePorEmpresaConEntidad(_nombre, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerUnidadConClaveSinEntidad_Escritorio(string _palabra_clave)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = unidadNE.TraerUnidadConClaveSinEntidad(_palabra_clave);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerTodasUnidades_Escritorio()
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = unidadNE.TraerTodasUnidades();
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
        public void TraerUnidadPorEmpresa_Web(string json)
        {
            dynamic datosRespuesta = new ExpandoObject();
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                dynamic dataJson = new ExpandoObject();
                dynamic data = new ExpandoObject();

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);

                string _rut_empresa = dataJson.rut_empresa;

                retorno = unidadNE.TraerUnidadPorEmpresaSinEntidad(_rut_empresa);

                if(retorno != null && retorno.Tables.Count > 0)
                {
                    data.unidades = retorno.Tables[0];
                }
                else
                {
                    data.unidades = retorno;
                }

                datosRespuesta.datos = data;

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
