using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Process.Modelos;
using Newtonsoft.Json;
using System.Dynamic;

namespace Process.Datos
{
    public class FlujoDA
    {

        public int InsertarFlujo(int _id_equipo, string _rut_usuario_creador, string _nombre)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "FLUJO_INSERTAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_EQUIPO", OracleDbType.Int32).Value = _id_equipo;
                cmd.Parameters.Add("V_RUT_USUARIO_CREADOR", OracleDbType.NVarchar2).Value = _rut_usuario_creador;
                cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _nombre;

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

        public int ActualizarFlujo(int _id_flujo, string _modificacion_usuario, int _id_equipo, string _nombre)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "FLUJO_ACTUALIZAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_FLUJO", OracleDbType.Int32).Value = _id_flujo;
                cmd.Parameters.Add("V_MODIFICACION_USUARIO", OracleDbType.NVarchar2).Value = _modificacion_usuario;
                cmd.Parameters.Add("V_ID_EQUIPO", OracleDbType.Int32).Value = _id_equipo;
                cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _nombre;

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

        public int ImplementarFlujo(int _id_flujo, string _modificacion_usuario, int _id_equipo, string _nombre)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "FLUJO_IMPLEMENTAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_FLUJO", OracleDbType.Int32).Value = _id_flujo;
                cmd.Parameters.Add("V_MODIFICACION_USUARIO", OracleDbType.NVarchar2).Value = _modificacion_usuario;
                cmd.Parameters.Add("V_ID_EQUIPO", OracleDbType.Int32).Value = _id_equipo;
                cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _nombre;

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

        public DataSet TraerTodosFlujo()
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "FLUJO_TRAER_TODOS";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter retorno = cmd.Parameters.Add("C_FLUJOS", OracleDbType.RefCursor);
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

        public DataSet TraerTodosFlujoUsuario(string _rut_usuario, string _rut_empresa)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "FLUJO_TRAER_TODOS_USUARIO";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_RUT_USUARIO", OracleDbType.NVarchar2).Value = _rut_usuario;
                cmd.Parameters.Add("V_RUT_EMPRESA", OracleDbType.NVarchar2).Value = _rut_empresa;

                OracleParameter retorno = cmd.Parameters.Add("C_FLUJOS", OracleDbType.RefCursor);
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

        public DataSet TraerFlujo(int _id_flujo)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "FLUJO_TRAER_ID_FLUJO";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_FLUJO", OracleDbType.Int32).Value = _id_flujo;

                OracleParameter retorno = cmd.Parameters.Add("C_FLUJOS", OracleDbType.RefCursor);
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
