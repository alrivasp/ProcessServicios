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
    /// Descripción breve de Process_Comuna
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Process_Comuna : System.Web.Services.WebService
    {
        private ComunaNE comunaNE = new ComunaNE();
        private Comuna comuna = new Comuna();

        //////////////////////////////////////
        ////Web Metodos para APP de Escritorio
        //////////////////////////////////////


        [WebMethod]
        public DataSet TraerComunaSinEntidad_Escritorio(int _id_comuna)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = comunaNE.TraerComunaSinEntidad(_id_comuna);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public Comuna TraerComunaConEntidad_Escritorio(int _id_comuna)
        {
            try
            {
                CadenaConexion();
                Comuna retorno = new Comuna();
                retorno = comunaNE.TraerComunaConEntidad(_id_comuna);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerTodasComunasPorProvincia_Escritorio(int _id_provincia)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = comunaNE.TraerTodasComunsPorProvincia(_id_provincia);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerTodasComunas_Escritorio()
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = comunaNE.TraerTodasComunas();
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
