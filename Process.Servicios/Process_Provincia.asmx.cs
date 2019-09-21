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
    /// Descripción breve de Process_Provincia
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Process_Provincia : System.Web.Services.WebService
    {
        private ProvinciaNE provinciaNE = new ProvinciaNE();
        private Provincia provincia = new Provincia();

        //////////////////////////////////////
        ////Web Metodos para APP de Escritorio
        //////////////////////////////////////


        [WebMethod]
        public DataSet TraerProvinciaSinEntidad_Escritorio(int _id_provincia)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = provinciaNE.TraerProvinciaSinEntidad(_id_provincia);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public Provincia TraerProvinciaConEntidad_Escritorio(int _id_provincia)
        {
            try
            {
                CadenaConexion();
                Provincia retorno = new Provincia();
                retorno = provinciaNE.TraerProvinciaConEntidad(_id_provincia);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerTodasProvinciasPorRegion_Escritorio(int _id_region)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = provinciaNE.TraerTodasProvinciasPorRegion(_id_region);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerTodasProvincias_Escritorio()
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = provinciaNE.TraerTodasProvincias();
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
