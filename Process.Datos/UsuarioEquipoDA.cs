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
    public class UsuarioEquipoDA
    {
        public int InsertarUsuarioEquipoSinEntidad(string _rut_usuario, int _id_equipo, int _responsable)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "USUARIO_EQUIPO_INSERTAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_RUT_USUARIO", OracleDbType.NVarchar2).Value = _rut_usuario;
                cmd.Parameters.Add("V_ID_EQUIPO", OracleDbType.Int32).Value = _id_equipo;
                cmd.Parameters.Add("V_RESPONSABLE", OracleDbType.Char).Value = _responsable;

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

        public int ActualizarUsuarioEquipoSinEntidad(string _rut_usuario, int _id_equipo, int _responsable)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "USUARIO_EQUIPO_ACTUALIZAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_RUT_USUARIO", OracleDbType.NVarchar2).Value = _rut_usuario;
                cmd.Parameters.Add("V_ID_EQUIPO", OracleDbType.Int32).Value = _id_equipo;
                cmd.Parameters.Add("V_RESPONSABLE", OracleDbType.Char).Value = _responsable;

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

        public UsuarioEquipo TraerUsuarioEquiPorEquipoPorRutConEntidad(int _id_equipo, string _rut_usuario)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            UsuarioEquipo usuarioEquipo = new UsuarioEquipo();
            try
            {
                string procedure = "USUARIO_EQUIPO_TRAER_USU_EQUI";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_EQUIPO", OracleDbType.Int32).Value = _id_equipo;
                cmd.Parameters.Add("V_RUT_USUARIO", OracleDbType.NVarchar2).Value = _rut_usuario;

                OracleParameter retorno = cmd.Parameters.Add("C_USUARIO_EQUIPO", OracleDbType.RefCursor);
                retorno.Direction = ParameterDirection.Output;

                cmd.Connection.Open();

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    datos.Tables.Add(dt);
                    usuarioEquipo.FillFromDataSet(datos);
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

            return usuarioEquipo;
        }

        public DataSet TraerUsuarioEquipoSinEntidad(int _id_equipo)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "USUARIO_EQUIPO_TRAER_EQUIPO";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_EQUIPO", OracleDbType.Int32).Value = _id_equipo;                

                OracleParameter retorno = cmd.Parameters.Add("C_USUARIO_EQUIPO ", OracleDbType.RefCursor);
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

        public int EliminarUsuarioEquipoSinEntidad(int _id_equipo)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "USUARIO_EQUIPO_BORRAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add("V_ID_EQUIPO", OracleDbType.Int32).Value = _id_equipo;

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

        public DataSet TraerUsuariosEquipo(int _id_equipo)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "USUARIO_EQUIPO_TRAER_USUARIOS";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_EQUIPO", OracleDbType.Int32).Value = _id_equipo;

                OracleParameter retorno = cmd.Parameters.Add("C_USUARIO_EQUIPO ", OracleDbType.RefCursor);
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
