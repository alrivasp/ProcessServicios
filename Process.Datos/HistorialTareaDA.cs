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
    public class HistorialTareaDA
    {

        public int InsertarHistorialTarea(string _descripcion, int _id_estado_tarea, int _id_tarea)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "HISTORIAL_TAREA_INSERTAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add("V_DESCRIPCION", OracleDbType.NVarchar2).Value = _descripcion;                
                cmd.Parameters.Add("V_ID_ESTADO_TAREA", OracleDbType.Int32).Value = _id_estado_tarea;
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

        public int ActualizarHistorialTarea(int _id_historial_tarea, string _descripcion, int _id_estado_tarea, int _id_tarea)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "HISTORIAL_TAREA_ACTUALIZAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_HISTORIAL_TAREA", OracleDbType.Int32).Value = _id_historial_tarea;
                cmd.Parameters.Add("V_DESCRIPCION", OracleDbType.NVarchar2).Value = _descripcion;
                cmd.Parameters.Add("V_ID_ESTADO_TAREA", OracleDbType.Int32).Value = _id_estado_tarea;
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

        public DataSet TraerTodosHistorialTarea()
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "HISTORIAL_TAREA_TRAER_TODOS";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter retorno = cmd.Parameters.Add("C_HISTORIAL_TAREAS", OracleDbType.RefCursor);
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
