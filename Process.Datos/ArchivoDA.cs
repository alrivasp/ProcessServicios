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
    public class ArchivoDA
    {

        public int InsertarArchivo(string _ruta, string _nombre , int _id_historial_tarea)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "ARCHIVO_INSERTAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_RUTA", OracleDbType.NVarchar2).Value = _ruta;
                cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _nombre;
                cmd.Parameters.Add("V_ID_HISTORIAL_TAREA", OracleDbType.Int32).Value = _id_historial_tarea;

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
