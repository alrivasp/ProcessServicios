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
    /// Descripción breve de Process_Cuenta
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Process_Cuenta : System.Web.Services.WebService
    {
        private CuentaNE cuentaNE = new CuentaNE();
        private Cuenta cuenta = new Cuenta();

        //////////////////////////////////////
        ////Web Metodos para APP de Escritorio
        //////////////////////////////////////
        [WebMethod]
        public int InsertarCuentaConEntidad_Escritorio(DataSet _unidad)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                cuenta = new Cuenta();
                cuenta.FillFromDataSet(_unidad);
                retorno = cuentaNE.InsertarCuentaConEntidad(cuenta);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int InsertarCuentaSinEntidad_Escritorio(string _rut_usuario, string _rut_empresa, string _contrasena, int _estado, int _id_rol)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = cuentaNE.InsertarCuentaSinEntidad(_rut_usuario, _rut_empresa, _contrasena, _estado, _id_rol);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int ActualizarCuentaConEntidad_Escritorio(DataSet _unidad)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                cuenta = new Cuenta();
                cuenta.FillFromDataSet(_unidad);
                retorno = cuentaNE.ActualizarCuentaConEntidad(cuenta);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int ActualizarCuentaSinEntidad_Escritorio(string _rut_usuario, string _rut_empresa, string _contrasena, int _estado, int _id_rol)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = cuentaNE.ActualizarCuentaSinEntidad(_rut_usuario, _rut_empresa, _contrasena, _estado, _id_rol);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public DataSet TraerCuentaSinEntidad_Escritorio(string _rut_usuario)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = cuentaNE.TraerCuentaSinEntidad(_rut_usuario);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public Cuenta TraerCuentaConEntidad_Escritorio(string _rut_usuario)
        {
            try
            {
                CadenaConexion();
                Cuenta retorno = new Cuenta();
                retorno = cuentaNE.TraerCuentaConEntidad(_rut_usuario);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
        
        [WebMethod]
        public DataSet TraerCuentaConEmpresaSinEntidad_Escritorio(string _rut_usuario, string _rut_empresa)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = cuentaNE.TraerCuentaConEmpresaSinEntidad(_rut_usuario, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public Cuenta TraerCuentaConEmpresaConEntidad_Escritorio(string _rut_usuario, string _rut_empresa)
        {
            try
            {
                CadenaConexion();
                Cuenta retorno = new Cuenta();
                retorno = cuentaNE.TraerCuentaConEmpresaConEntidad(_rut_usuario, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }


        [WebMethod]
        public DataSet TraerTodasCuentas_Escritorio()
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = cuentaNE.TraerTodasCuentas();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerCuentaConClaveSinEntidad_Escritorio(string _palabra_clave)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = cuentaNE.TraerCuentaConClaveSinEntidad(_palabra_clave);
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
