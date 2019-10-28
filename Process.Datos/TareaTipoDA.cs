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
    public class TareaTipoDA
    {
        public int InsertarTareaTipo(string _nombre, string _descripcion, int _cantidad_dias, int _id_flujo_tipo)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "TAREA_TIPO_INSERTAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _nombre;
                cmd.Parameters.Add("V_DESCRIPCION", OracleDbType.NVarchar2).Value = _descripcion;
                cmd.Parameters.Add("V_CANTIDAD_DIAS", OracleDbType.Int32).Value = _cantidad_dias;
                cmd.Parameters.Add("V_ID_FLUJO_TIPO", OracleDbType.Int32).Value = _id_flujo_tipo;

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
