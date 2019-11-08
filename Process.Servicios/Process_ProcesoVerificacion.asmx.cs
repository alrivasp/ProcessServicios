using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Process.Modelos;
using Process.Negocios;
using System.Data;

namespace Process.Servicios
{
    /// <summary>
    /// Descripción breve de Process_ProcesoVerificacion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Process_ProcesoVerificacion : System.Web.Services.WebService
    {

        private ProcesoVerificacionNE procesoVerificacionNE = new ProcesoVerificacionNE();

        //////////////////////////////////////
        ////Web Metodos para Windows Service
        //////////////////////////////////////

        [WebMethod]
        public DataSet TraerTareasVencidas_WindowsService()
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = procesoVerificacionNE.TraerTareasVencidas();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerTareasPorVencerHoy_WindowsService()
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = procesoVerificacionNE.TraerTareasPorVencerHoy();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerTareasUnDiaPorVencer_WindowsService()
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = procesoVerificacionNE.TraerTareasUnDiaPorVencer();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerTareasDosDiasPorVencer_WindowsService()
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = procesoVerificacionNE.TraerTareasDosDiasPorVencer();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerInformacionFlujoSinEntidad_WindowsService(int _id_flujo)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = procesoVerificacionNE.TraerInformacionFlujoSinEntidad(_id_flujo);
                return retorno;

            }
            catch (Exception)
            {
                throw;

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
