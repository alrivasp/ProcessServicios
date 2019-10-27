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
    public class FlujoTipoDA
    {
        public int InsertarFlujoTipo(string _json)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                if (_json != null)
                {
                    dynamic dataJson = new ExpandoObject();
                    dataJson = JsonConvert.DeserializeObject<dynamic>(_json);

                    string procedure = "FLUJO_TIPO_INSERTAR";
                    OracleConnection cnx = Global.CadenaConexionGlobal;
                    cmd = new OracleCommand(procedure, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = dataJson.NOMBRE;
                    cmd.Parameters.Add("V_DESCRIPCION", OracleDbType.NVarchar2).Value = dataJson.DESCRIPCION;
                    cmd.Parameters.Add("V_ESTADO", OracleDbType.Char).Value = dataJson.ESTADO;
                    cmd.Parameters.Add("V_USUARIO", OracleDbType.NVarchar2).Value = dataJson.USUARIO;

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
    }
}
