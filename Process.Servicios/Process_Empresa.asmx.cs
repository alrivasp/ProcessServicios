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
    /// Descripción breve de Process_Empresa
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Process_Empresa : System.Web.Services.WebService
    {
        private EmpresaNE empresaNE = new EmpresaNE();
        private Empresa empresa = new Empresa();

        //////////////////////////////////////
        ////Web Metodos para APP de Escritorio
        //////////////////////////////////////
        [WebMethod]
        public int InsertarEmpresaConEntidad_Escritorio(DataSet _unidad)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                empresa = new Empresa();
                empresa.FillFromDataSet(_unidad);
                retorno = empresaNE.InsertarEmpresaConEntidad(empresa);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int InsertarEmpresaSinEntidad_Escritorio(string _rut_empresa, string _nombre, string _giro, string _direccion, int _estado, int _id_comuna)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = empresaNE.InsertarEmpresaSinEntidad(_rut_empresa, _nombre, _giro, _direccion, _estado, _id_comuna);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int ActualizarEmpresaConEntidad_Escritorio(DataSet _unidad)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                empresa = new Empresa();
                empresa.FillFromDataSet(_unidad);
                retorno = empresaNE.ActualizarEmpresaConEntidad(empresa);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int ActualizarEmpresaSinEntidad_Escritorio(string _rut_empresa, string _nombre, string _giro, string _direccion, int _estado, int _id_comuna)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = empresaNE.ActualizarEmpresaSinEntidad(_rut_empresa, _nombre, _giro, _direccion, _estado, _id_comuna);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public DataSet TraerEmpresaSinEntidad_Escritorio(string _rut_empresa)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = empresaNE.TraerEmpresaSinEntidad(_rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerEmpresaConClaveSinEntidad_Escritorio(string _palabra_clave)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = empresaNE.TraerEmpresaConClaveSinEntidad(_palabra_clave);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public Empresa TraerEmpresaConEntidad_Escritorio(string _rut_empresa)
        {
            try
            {
                CadenaConexion();
                Empresa retorno = new Empresa();
                retorno = empresaNE.TraerEmpresaConEntidad(_rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerTodasEmpresas_Escritorio()
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = empresaNE.TraerTodasEmpresas();
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
