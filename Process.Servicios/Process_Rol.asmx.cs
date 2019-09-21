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
    /// Descripción breve de Process_Rol
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Process_Rol : System.Web.Services.WebService
    {

        private RolNE rolNE = new RolNE();
        private Rol rol = new Rol();

        //////////////////////////////////////
        ////Web Metodos para APP de Escritorio
        //////////////////////////////////////
        [WebMethod]
        public int InsertarRolConEntidad_Escritorio(DataSet _unidad)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                rol = new Rol();
                rol.FillFromDataSet(_unidad);
                retorno = rolNE.InsertarRolConEntidad(rol);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int InsertarRolSinEntidad_Escritorio(string _nombre, int _estado)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = rolNE.InsertarRolSinEntidad(_nombre, _estado);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int ActualizarRolConEntidad_Escritorio(DataSet _unidad)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                rol = new Rol();
                rol.FillFromDataSet(_unidad);
                retorno = rolNE.ActualizarRolConEntidad(rol);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int ActualizarRolSinEntidad_Escritorio(int _id_rol, string _nombre,int _estado)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = rolNE.ActualizarRolSinEntidad(_id_rol, _nombre, _estado);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public DataSet TraerRolSinEntidad_Escritorio(int _id_rol)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = rolNE.TraerRolSinEntidad(_id_rol);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public Rol TraerRolConEntidad_Escritorio(int _id_rol)
        {
            try
            {
                CadenaConexion();
                Rol retorno = new Rol();
                retorno = rolNE.TraerRolConEntidad(_id_rol);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerTodasRoles_Escritorio()
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = rolNE.TraerTodasRoles();
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
