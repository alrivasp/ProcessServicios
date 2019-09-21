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
    /// Descripción breve de Process_Cargo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Process_Cargo : System.Web.Services.WebService
    {
        private CargoNE cargoNE = new CargoNE();
        private Cargo cargo = new Cargo();

        //////////////////////////////////////
        ////Web Metodos para APP de Escritorio
        //////////////////////////////////////
        [WebMethod]
        public int InsertarCargoConEntidad_Escritorio(DataSet _unidad)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                cargo = new Cargo();
                cargo.FillFromDataSet(_unidad);
                retorno = cargoNE.InsertarCargoConEntidad(cargo);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int InsertarCargoSinEntidad_Escritorio(string _nombre, string _descripcion, string _rut_empresa)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = cargoNE.InsertarCargoSinEntidad(_nombre, _descripcion, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int ActualizarCargoConEntidad_Escritorio(DataSet _unidad)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                cargo = new Cargo();
                cargo.FillFromDataSet(_unidad);
                retorno = cargoNE.ActualizarCargoConEntidad(cargo);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int ActualizarCargoSinEntidad_Escritorio(string _nombre, string _descripcion, string _rut_empresa)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = cargoNE.ActualizarCargoSinEntidad(_nombre, _descripcion, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public DataSet TraerCargoSinEntidad_Escritorio(int _id_cargo)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = cargoNE.TraerCargoSinEntidad(_id_cargo);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public Cargo TraerCargoConEntidad_Escritorio(int _id_cargo)
        {
            try
            {
                CadenaConexion();
                Cargo retorno = new Cargo();
                retorno = cargoNE.TraerCargoConEntidad(_id_cargo);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }


        [WebMethod]
        public DataSet TraerCargoConEmpresaSinEntidad_Escritorio(string _rut_empresa)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = cargoNE.TraerCargoConEmpresaSinEntidad(_rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public Cargo TraerCargoConEmpresaConEntidad_Escritorio(string _rut_empresa)
        {
            try
            {
                CadenaConexion();
                Cargo retorno = new Cargo();
                retorno = cargoNE.TraerCargoConEmpresaConEntidad(_rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerTodasCargos_Escritorio()
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = cargoNE.TraerTodasCargos();
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
