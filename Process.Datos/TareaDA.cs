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
    public class TareaDA
    {
        public int InsertarTarea(string _nombre, string _descripcion, DateTime _fecha_inicio, DateTime _fecha_termino,  
                                    string  _modificacion_usuario_cambio, int _id_flujo, int _id_estado_tarea, string _rut_usuario_asignado, string _rut_usuario_creador)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "TAREA_INSERTAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _nombre;
                cmd.Parameters.Add("V_DESCRIPCION", OracleDbType.NVarchar2).Value = _descripcion;
                cmd.Parameters.Add("V_FECHA_INICIO", OracleDbType.Date).Value = _fecha_inicio;
                cmd.Parameters.Add("V_FECHA_TERMINO", OracleDbType.Date).Value = _fecha_termino;                
                cmd.Parameters.Add("V_MODIFICACION_USUARIO_CAMBIO", OracleDbType.NVarchar2).Value = _modificacion_usuario_cambio;
                cmd.Parameters.Add("V_ID_FLUJO", OracleDbType.Int32).Value = _id_flujo;
                cmd.Parameters.Add("V_ID_ESTADO_TAREA", OracleDbType.Int32).Value = _id_estado_tarea;
                cmd.Parameters.Add("V_RUT_USUARIO_ASIGNADO", OracleDbType.NVarchar2).Value = _rut_usuario_asignado;
                cmd.Parameters.Add("V_RUT_USUARIO_CREADOR", OracleDbType.NVarchar2).Value = _rut_usuario_creador;

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

        public int ActualizarTarea(int _id_tarea, string _nombre, string _descripcion, DateTime _fecha_inicio, DateTime _fecha_termino,
                                   string _modificacion_usuario_cambio, int _id_flujo, int _id_estado_tarea, string _rut_usuario_asignado, string _rut_usuario_creador)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "TAREA_ACTUALIZAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_TAREA", OracleDbType.Int32).Value = _id_tarea;
                cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _nombre;
                cmd.Parameters.Add("V_DESCRIPCION", OracleDbType.NVarchar2).Value = _descripcion;
                cmd.Parameters.Add("V_FECHA_INICIO", OracleDbType.Date).Value = _fecha_inicio;
                cmd.Parameters.Add("V_FECHA_TERMINO", OracleDbType.Date).Value = _fecha_termino;
                cmd.Parameters.Add("V_MODIFICACION_USUARIO_CAMBIO", OracleDbType.NVarchar2).Value = _modificacion_usuario_cambio;
                cmd.Parameters.Add("V_ID_FLUJO", OracleDbType.Int32).Value = _id_flujo;
                cmd.Parameters.Add("V_ID_ESTADO_TAREA", OracleDbType.Int32).Value = _id_estado_tarea;
                cmd.Parameters.Add("V_RUT_USUARIO_ASIGNADO", OracleDbType.NVarchar2).Value = _rut_usuario_asignado;
                cmd.Parameters.Add("V_RUT_USUARIO_CREADOR", OracleDbType.NVarchar2).Value = _rut_usuario_creador;

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


        public DataSet TraerTodosTarea()
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "TAREA_TRAER_TODOS";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter retorno = cmd.Parameters.Add("C_TAREAS", OracleDbType.RefCursor);
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

        public DataSet TraerTodosTareaFlujo(int _id_flujo, string _rut_empresa)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "TAREA_TRAER_TODAS_FLUJO";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_FLUJO", OracleDbType.Int32).Value = _id_flujo;
                cmd.Parameters.Add("V_RUT_EMPRESA", OracleDbType.NVarchar2).Value = _rut_empresa;

                OracleParameter retorno = cmd.Parameters.Add("C_TAREAS", OracleDbType.RefCursor);
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
