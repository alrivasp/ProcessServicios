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
    public class SolucionDA
    {

        public int InsertarSolucion(string _descripcion, int _id_tipo_solucion, int _id_problema)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "SOLUCION_INSERTAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_DESCRIPCION", OracleDbType.NVarchar2).Value = _descripcion;                
                cmd.Parameters.Add("V_ID_TIPO_SOLUCION", OracleDbType.Int32).Value = _id_tipo_solucion;
                cmd.Parameters.Add("V_ID_PROBLEMA", OracleDbType.Int32).Value = _id_problema;

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

        public int ActualizarSolucion(int _id_solucion ,string _descripcion, int _id_tipo_solucion, int _id_problema)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "SOLUCION_ACTUALIZAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_SOLUCION", OracleDbType.Int32).Value = _id_solucion;
                cmd.Parameters.Add("V_DESCRIPCION", OracleDbType.NVarchar2).Value = _descripcion;
                cmd.Parameters.Add("V_ID_TIPO_SOLUCION", OracleDbType.Int32).Value = _id_tipo_solucion;
                cmd.Parameters.Add("V_ID_PROBLEMA", OracleDbType.Int32).Value = _id_problema;

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

    }
}
