using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Oracle.ManagedDataAccess.Client;
using Process.Modelos;
using Process.Negocios;
using System.Data;

namespace Process.Servicios
{
    /// <summary>
    /// Descripción breve de Process_Equipo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Process_Equipo : System.Web.Services.WebService
    {
        private EquipoNE equipoNE = new EquipoNE();
        private Equipo equipo = new Equipo();

        //////////////////////////////////////
        ////Web Metodos para APP de Escritorio
        //////////////////////////////////////
        [WebMethod]
        public int InsertarEquipoSinEntidad_Escritorio(string _nombre, int _id_unidad)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = equipoNE.InsertarEquipoSinEntidad(_nombre, _id_unidad);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int ActualizarEquipoSinEntidad_Escritorio(int _id_equipo, string _nombre, int _id_unidad)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = equipoNE.ActualizarEquipoSinEntidad(_id_equipo, _nombre, _id_unidad);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public Equipo TraerEquipoConEntidad_Escritorio(int _id_equipo)
        {
            try
            {
                CadenaConexion();
                Equipo retorno = new Equipo();
                retorno = equipoNE.TraerEquipoConEntidad(_id_equipo);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerEquipoPorClaveSinEntidad_Escritorio(int _id_unidad, string _rut_empresa, string _clave)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = equipoNE.TraerEquipoPorClaveSinEntidad(_id_unidad, _rut_empresa, _clave);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerEquipoPorEmpresaPorUnidadSinEntidad_Escritorio(int _id_unidad, string _rut_empresa)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = equipoNE.TraerEquipoPorEmpresaPorUnidadSinEntidad(_id_unidad, _rut_empresa);
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
