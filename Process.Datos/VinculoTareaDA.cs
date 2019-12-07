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
    public class VinculoTareaDA
    {
        public int InsertarVinculoTarea(int _id_tarea_hijo, int _id_tarea_padre, int _tipo)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "VINCULO_TAREA_INSERTAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_TAREA_HIJO", OracleDbType.Int32).Value = _id_tarea_hijo;
                cmd.Parameters.Add("V_ID_TAREA_PADRE", OracleDbType.Int32).Value = _id_tarea_padre;
                cmd.Parameters.Add("V_TIPO", OracleDbType.Char).Value = _tipo;

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

        public int ActualizarVinculoTarea(int _id_tarea_hijo, int _id_tarea_padre, int _tipo)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "VINCULO_TAREA_ACTUALIZAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_TAREA_HIJO", OracleDbType.Int32).Value = _id_tarea_hijo;
                cmd.Parameters.Add("V_ID_TAREA_PADRE", OracleDbType.Int32).Value = _id_tarea_padre;
                cmd.Parameters.Add("V_TIPO", OracleDbType.Char).Value = _tipo;

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

        public int EliminarTodosVinculosTarea(int _id_tarea)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "VINCULO_TAREA_BORRAR_TODOS";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_TAREA", OracleDbType.Int32).Value = _id_tarea;

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

        public int EliminarVinculoTarea(int _id_tarea_padre, int _id_tarea_hijo)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "VINCULO_TAREA_BORRAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_TAREA_PADRE", OracleDbType.Int32).Value = _id_tarea_padre;
                cmd.Parameters.Add("V_ID_TAREA_HIJO", OracleDbType.Int32).Value = _id_tarea_hijo;

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

        public DataSet TraerTodosVinculosTarea(int _id_tarea)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "VINCULO_TAREA_TRAER_VINCULOS";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_TAREA", OracleDbType.Int32).Value = _id_tarea;

                OracleParameter retorno = cmd.Parameters.Add("C_VINCULOS", OracleDbType.RefCursor);
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

        public DataSet TraerTodosVinculosTareaHijo(int _id_tarea)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "VINCULO_TAREA_VINCULOS_HIJO";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_TAREA", OracleDbType.Int32).Value = _id_tarea;

                OracleParameter retorno = cmd.Parameters.Add("C_VINCULOS", OracleDbType.RefCursor);
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
