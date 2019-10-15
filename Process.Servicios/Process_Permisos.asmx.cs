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
    /// Descripción breve de Process_Permisos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Process_Permisos : System.Web.Services.WebService
    {
        private PermisosNE permisosNE = new PermisosNE();
        private Permisos permisos = new Permisos();

        //////////////////////////////////////
        ////Web Metodos para APP de Escritorio
        //////////////////////////////////////

        [WebMethod]
        public int InsertarPermisosSinEntidad_Escritorio(int _id_acceso, int _rol)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = permisosNE.InsertarPermisosSinEntidad(_id_acceso, _rol);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int ActualizarPermisosSinEntidad_Escritorio(int _id_acceso, int _rol)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = permisosNE.ActualizarPermisosSinEntidad(_id_acceso, _rol);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }


        [WebMethod]
        public int EliminarPermisosSinEntidad_Escritorio(int _rol)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = permisosNE.EliminarPermisosSinEntidad(_rol);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public DataSet TraerPermisosPorAccesoPorRolSinEntidad_Escritorio(int _id_acceso, int _rol)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = permisosNE.TraerPermisosPorAccesoPorRolSinEntidad(_id_acceso, _rol);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerPermisosPorRolSinEntidad_Escritorio(int _rol)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = permisosNE.TraerPermisosPorRolSinEntidad(_rol);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public Permisos TraerPermisosPorRolConEntidad_Escritorio(int _id_rol)
        {
            try
            {
                CadenaConexion();
                Permisos retorno = new Permisos();
                retorno = permisosNE.TraerPermisosPorRolConEntidad(_id_rol);
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
