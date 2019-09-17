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

        [WebMethod]
        public int InsertarUnidadConEntidad(DataSet _unidad)
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
        public int InsertarUnidadSinEntidad(string _nombre, string _descripcion, int _estado, string _rut_empresa)
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
        public int ActualizarUnidadConEntidad(DataSet _unidad)
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
        public int ActualizarUnidadSinEntidad(int _id_unidad, string _nombre, string _descripcion, int _estado, string _rut_empresa)
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
        public DataSet TraerUnidadSinEntidad(int _id_unidad, string _rut_empresa)
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
        public Unidad TraerUnidadConEntidad(int _id_unidad, string _rut_empresa)
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
        public DataSet TraerTodasUnidades(string _rut_empresa)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = unidadNE.TraerTodasUnidades(_rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

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
