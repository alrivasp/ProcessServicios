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
    /// Descripción breve de Process_FlujoTipo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Process_FlujoTipo : System.Web.Services.WebService
    {

        private FlujoTipoNE flujoTipoNE = new FlujoTipoNE();

        //////////////////////////////////////
        ////Web Metodos para APP WEB
        //////////////////////////////////////

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertarFlujoTipo_Web(string json)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;

                dynamic datosRespuesta = new ExpandoObject();

                retorno = flujoTipoNE.InsertarFlujoTipo(json);

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
        public void InsertarFlujoTipoUnidad_Web(string json)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;

                dynamic dataJson = new ExpandoObject();
                dynamic datosRespuesta = new ExpandoObject();
                dynamic detalleUnidades = new ExpandoObject();

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);

                int _id_flujo_tipo = dataJson.idFlujoTipo;
                detalleUnidades = dataJson.detalleUnidades;

                foreach (var item in detalleUnidades)
                {
                    retorno = flujoTipoNE.InsertarFlujoTipoUnidad(Convert.ToInt32(item["ID_UNIDAD"]), _id_flujo_tipo);
                    //retorno = item["ID_UNIDAD"];
                }

                //for (int i = 0; i < detalleUnidades.Length; i++)
                //{
                //    retorno = flujoTipoNE.InsertarFlujoTipoUnidad(detalleUnidades[i].ID_UNIDAD, _id_flujo_tipo);
                //}

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
        public void TraerTodosFlujosTipo_Web(string json)
        {
            try
            {
                CadenaConexion();
                DataSet retornoFlujosTipo = new DataSet();

                dynamic dataJson = new ExpandoObject();//Objeto json
                dynamic datosRespuesta = new ExpandoObject();//Objeto respuesta
                dynamic data = new ExpandoObject();

                dataJson = JsonConvert.DeserializeObject<dynamic>(json);//Se lee el json

                string _rut_empresa = dataJson.rut_empresa;

                retornoFlujosTipo = flujoTipoNE.TraerTodosFlujosTipo(_rut_empresa);//se envian variables

                data.flujosTipos = retornoFlujosTipo.Tables[0];

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
