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
    /// Descripción breve de Process_CargosUsuarios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Process_CargosUsuarios : System.Web.Services.WebService
    {
        private CargosUsuariosNE cargosUsuariosNE = new CargosUsuariosNE();
        private CargosUsuarios cargosUsuarios = new CargosUsuarios();

        //////////////////////////////////////
        ////Web Metodos para APP de Escritorio
        //////////////////////////////////////

        [WebMethod]
        public int InsertarCargosUsuarioSinEntidad_Escritorio(string _rut_usuario, int _id_cargo, int _estado)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = cargosUsuariosNE.InsertarCargosUsuarioSinEntidad(_rut_usuario, _id_cargo, _estado);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int ActualizarCargosUsuarioSinEntidad_Escritorio(string _rut_usuario, int _id_cargo, int _estado)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = cargosUsuariosNE.ActualizarCargosUsuarioSinEntidad(_rut_usuario, _id_cargo, _estado);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public DataSet TraerCargosUsuarioPorRutPorCargoSinEntidad_Escritorio(string _rut_usuario, int _id_cargo)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = cargosUsuariosNE.TraerCargosUsuarioPorRutPorCargoSinEntidad(_rut_usuario, _id_cargo);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerCargosUsuarioPorRutSinEntidad_Escritorio(string _rut_usuario)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = cargosUsuariosNE.TraerCargosUsuarioPorRutSinEntidad(_rut_usuario);
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
