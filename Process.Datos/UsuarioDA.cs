using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Process.Modelos;

namespace Process.Datos
{
    public class UsuarioDA
    {
        public int InsertarUsuarioConEntidad(Usuario _entidad)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                if (_entidad != null)
                {
                    string procedure = "USUARIO_INSERTAR";
                    OracleConnection cnx = Global.CadenaConexionGlobal;
                    cmd = new OracleCommand(procedure, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("V_RUT_USUARIO", OracleDbType.NVarchar2).Value = _entidad.Rut_usuario;
                    cmd.Parameters.Add("V_PRIMER_NOMBRE", OracleDbType.NVarchar2).Value = _entidad.Primer_nombre;
                    cmd.Parameters.Add("V_SEGUNDO_NOMBRE", OracleDbType.NVarchar2).Value = _entidad.Segundo_nombre;
                    cmd.Parameters.Add("V_PRIMER_APELLIDO", OracleDbType.NVarchar2).Value = _entidad.Primer_apellido;
                    cmd.Parameters.Add("V_SEGUNDO_APELLIDO", OracleDbType.NVarchar2).Value = _entidad.Segundo_apellido;
                    cmd.Parameters.Add("V_DIRECCION", OracleDbType.NVarchar2).Value = _entidad.Direccion;
                    cmd.Parameters.Add("V_CORREO", OracleDbType.NVarchar2).Value = _entidad.Correo;
                    cmd.Parameters.Add("V_TELEFONO_FIJO", OracleDbType.Int32).Value = _entidad.Telefono_fijo;
                    cmd.Parameters.Add("V_TELEFONO_MOVIL", OracleDbType.Int32).Value = _entidad.Telefono_movil;
                    cmd.Parameters.Add("V_ESTADO", OracleDbType.Char).Value = _entidad.Estado;
                    cmd.Parameters.Add("V_ID_COMUNA", OracleDbType.Int32).Value = _entidad.Id_comuna;

                    OracleParameter retorno = cmd.Parameters.Add("V_RESULTADO", OracleDbType.Int32);
                    retorno.Direction = ParameterDirection.Output;

                    cmd.Connection.Open();

                    cmd.ExecuteNonQuery();
                    object resultado = retorno.Value;
                    respuesta = Int32.Parse(resultado.ToString());

                }

            }
            catch (Exception pe)
            {
                Console.Write(pe.Message);
                respuesta = -1;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return respuesta;
        }

        public int InsertarUsuarioSinEntidad(string _rut_usuario, string _primer_nombre, string _segundo_nombre, string _primer_apellido
                                            ,string _segundo_apellido, string _direccion, string _correo, int _telefono_fijp
                                            , int _telefono_movil,int _estado, int _id_comuna)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "USUARIO_INSERTAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_RUT_USUARIO", OracleDbType.NVarchar2).Value = _rut_usuario;
                cmd.Parameters.Add("V_PRIMER_NOMBRE", OracleDbType.NVarchar2).Value = _primer_nombre;
                cmd.Parameters.Add("V_SEGUNDO_NOMBRE", OracleDbType.NVarchar2).Value = _segundo_nombre;
                cmd.Parameters.Add("V_PRIMER_APELLIDO", OracleDbType.NVarchar2).Value = _primer_apellido;
                cmd.Parameters.Add("V_SEGUNDO_APELLIDO", OracleDbType.NVarchar2).Value = _segundo_apellido;
                cmd.Parameters.Add("V_DIRECCION", OracleDbType.NVarchar2).Value = _direccion;
                cmd.Parameters.Add("V_CORREO", OracleDbType.NVarchar2).Value = _correo;
                cmd.Parameters.Add("V_TELEFONO_FIJO", OracleDbType.Int32).Value = _telefono_fijp;
                cmd.Parameters.Add("V_TELEFONO_MOVIL", OracleDbType.Int32).Value = _telefono_movil;
                cmd.Parameters.Add("V_ESTADO", OracleDbType.Char).Value = _estado;
                cmd.Parameters.Add("V_ID_COMUNA", OracleDbType.Int32).Value = _id_comuna;

                OracleParameter retorno = cmd.Parameters.Add("V_RESULTADO", OracleDbType.Int32);
                retorno.Direction = ParameterDirection.Output;

                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
                object resultado = retorno.Value;
                respuesta = Int32.Parse(resultado.ToString());

            }
            catch (Exception pe)
            {
                Console.Write(pe.Message);
                respuesta = -1;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return respuesta;
        }

        public int ActualizarUsuarioConEntidad(Usuario _entidad)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                if (_entidad != null)
                {
                    string procedure = "USUARIO_ACTUALIZAR";
                    OracleConnection cnx = Global.CadenaConexionGlobal;
                    cmd = new OracleCommand(procedure, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("V_RUT_USUARIO", OracleDbType.NVarchar2).Value = _entidad.Rut_usuario;
                    cmd.Parameters.Add("V_PRIMER_NOMBRE", OracleDbType.NVarchar2).Value = _entidad.Primer_nombre;
                    cmd.Parameters.Add("V_SEGUNDO_NOMBRE", OracleDbType.NVarchar2).Value = _entidad.Segundo_nombre;
                    cmd.Parameters.Add("V_PRIMER_APELLIDO", OracleDbType.NVarchar2).Value = _entidad.Primer_apellido;
                    cmd.Parameters.Add("V_SEGUNDO_APELLIDO", OracleDbType.NVarchar2).Value = _entidad.Segundo_apellido;
                    cmd.Parameters.Add("V_DIRECCION", OracleDbType.NVarchar2).Value = _entidad.Direccion;
                    cmd.Parameters.Add("V_CORREO", OracleDbType.NVarchar2).Value = _entidad.Correo;
                    cmd.Parameters.Add("V_TELEFONO_FIJO", OracleDbType.Int32).Value = _entidad.Telefono_fijo;
                    cmd.Parameters.Add("V_TELEFONO_MOVIL", OracleDbType.Int32).Value = _entidad.Telefono_movil;
                    cmd.Parameters.Add("V_ESTADO", OracleDbType.Char).Value = _entidad.Estado;
                    cmd.Parameters.Add("V_ID_COMUNA", OracleDbType.Int32).Value = _entidad.Id_comuna;

                    OracleParameter retorno = cmd.Parameters.Add("V_RESULTADO", OracleDbType.Int32);
                    retorno.Direction = ParameterDirection.Output;

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    object resultado = retorno.Value;
                    respuesta = Int32.Parse(resultado.ToString());

                }

            }
            catch (Exception pe)
            {
                Console.Write(pe.Message);
                respuesta = -1;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return respuesta;
        }

        public int ActualizarUsuarioSinEntidad(string _rut_usuario, string _primer_nombre, string _segundo_nombre, string _primer_apellido
                                            , string _segundo_apellido, string _direccion, string _correo, int _telefono_fijp
                                            , int _telefono_movil, int _estado, int _id_comuna)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "USUARIO_ACTUALIZAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_RUT_USUARIO", OracleDbType.NVarchar2).Value = _rut_usuario;
                cmd.Parameters.Add("V_PRIMER_NOMBRE", OracleDbType.NVarchar2).Value = _primer_nombre;
                cmd.Parameters.Add("V_SEGUNDO_NOMBRE", OracleDbType.NVarchar2).Value = _segundo_nombre;
                cmd.Parameters.Add("V_PRIMER_APELLIDO", OracleDbType.NVarchar2).Value = _primer_apellido;
                cmd.Parameters.Add("V_SEGUNDO_APELLIDO", OracleDbType.NVarchar2).Value = _segundo_apellido;
                cmd.Parameters.Add("V_DIRECCION", OracleDbType.NVarchar2).Value = _direccion;
                cmd.Parameters.Add("V_CORREO", OracleDbType.NVarchar2).Value = _correo;
                cmd.Parameters.Add("V_TELEFONO_FIJO", OracleDbType.Int32).Value = _telefono_fijp;
                cmd.Parameters.Add("V_TELEFONO_MOVIL", OracleDbType.Int32).Value = _telefono_movil;
                cmd.Parameters.Add("V_ESTADO", OracleDbType.Char).Value = _estado;
                cmd.Parameters.Add("V_ID_COMUNA", OracleDbType.Int32).Value = _id_comuna;

                OracleParameter retorno = cmd.Parameters.Add("V_RESULTADO", OracleDbType.Int32);
                retorno.Direction = ParameterDirection.Output;

                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
                object resultado = retorno.Value;
                respuesta = Int32.Parse(resultado.ToString());

            }
            catch (Exception pe)
            {
                Console.Write(pe.Message);
                respuesta = -1;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return respuesta;
        }

        public DataSet TraerUsuarioSinEntidad(string _rut_usuario)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "USUARIO_TRAER_USUARIO";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_RUT_USUARIO", OracleDbType.NVarchar2).Value = _rut_usuario;

                OracleParameter retorno = cmd.Parameters.Add("C_USUARIO", OracleDbType.RefCursor);
                retorno.Direction = ParameterDirection.Output;

                cmd.Connection.Open();

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    datos.Tables.Add(dt);
                }

            }
            catch (Exception pe)
            {
                Console.Write(pe.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }

            return datos;
        }

        public Usuario TraerUsuarioConEntidad(string _rut_usuario)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            Usuario usuario = new Usuario();
            try
            {
                string procedure = "USUARIO_TRAER_USUARIO";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_RUT_USUARIO", OracleDbType.NVarchar2).Value = _rut_usuario;
                

                OracleParameter retorno = cmd.Parameters.Add("C_USUARIO", OracleDbType.RefCursor);
                retorno.Direction = ParameterDirection.Output;

                cmd.Connection.Open();

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    datos.Tables.Add(dt);
                    usuario.FillFromDataSet(datos);
                }

            }
            catch (Exception pe)
            {
                Console.Write(pe.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }

            return usuario;
        }

        public DataSet TraerTodasUsuarios()
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "USUARIO_TRAER_TODOS_USUARIO";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
   

                OracleParameter retorno = cmd.Parameters.Add("C_USUARIOS", OracleDbType.RefCursor);
                retorno.Direction = ParameterDirection.Output;

                cmd.Connection.Open();

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    datos.Tables.Add(dt);
                }

            }
            catch (Exception pe)
            {
                Console.Write(pe.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }

            return datos;
        }
    }
}
