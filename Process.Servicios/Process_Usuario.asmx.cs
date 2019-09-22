﻿using Oracle.ManagedDataAccess.Client;
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
    /// Descripción breve de Process_Usuario
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Process_Usuario : System.Web.Services.WebService
    {

        private UsuarioNE usuarioNE = new UsuarioNE();
        private Usuario usuario = new Usuario();

        //////////////////////////////////////
        ////Web Metodos para APP de Escritorio
        //////////////////////////////////////
        [WebMethod]
        public int InsertarUsuarioConEntidad_Escritorio(DataSet _unidad)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                usuario = new Usuario();
                usuario.FillFromDataSet(_unidad);
                retorno = usuarioNE.InsertarUsuarioConEntidad(usuario);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int InsertarUsuarioSinEntidad_Escritorio(string _rut_usuario, string _primer_nombre, string _segundo_nombre, string _primer_apellido
                                            , string _segundo_apellido, string _direccion, string _correo, int _telefono_fijp
                                            , int _telefono_movil, int _estado, int _id_comuna)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = usuarioNE.InsertarrUsuarioSinEntidad(_rut_usuario, _primer_nombre, _segundo_nombre, _primer_apellido, _segundo_apellido
                                                              , _direccion, _correo, _telefono_fijp, _telefono_movil, _estado, _id_comuna);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int ActualizarUsuarioConEntidad_Escritorio(DataSet _unidad)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                usuario = new Usuario();
                usuario.FillFromDataSet(_unidad);
                retorno = usuarioNE.ActualizarrUsuarioConEntidad(usuario);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public int ActualizarUsuarioSinEntidad_Escritorio(string _rut_usuario, string _primer_nombre, string _segundo_nombre, string _primer_apellido
                                            , string _segundo_apellido, string _direccion, string _correo, int _telefono_fijp
                                            , int _telefono_movil, int _estado, int _id_comuna)
        {
            try
            {
                CadenaConexion();
                int retorno = 0;
                retorno = usuarioNE.ActualizarrUsuarioSinEntidad(_rut_usuario, _primer_nombre, _segundo_nombre, _primer_apellido, _segundo_apellido
                                                              , _direccion, _correo, _telefono_fijp, _telefono_movil, _estado, _id_comuna);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        [WebMethod]
        public DataSet TraerUsuarioSinEntidad_Escritorio(string _rut_usuario)
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = usuarioNE.TraerrUsuarioSinEntidad(_rut_usuario);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public Usuario TraerUsuarioConEntidad_Escritorio(string _rut_usuario)
        {
            try
            {
                CadenaConexion();
                Usuario retorno = new Usuario();
                retorno = usuarioNE.TraerUsuarioConEntidad(_rut_usuario);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        [WebMethod]
        public DataSet TraerTodasUsuarios_Escritorio()
        {
            try
            {
                CadenaConexion();
                DataSet retorno = new DataSet();
                retorno = usuarioNE.TraerTodasrUsuarios();
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