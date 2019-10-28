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
    }
}
