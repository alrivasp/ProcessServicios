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

        public int InsertarFlujo(DateTime _fecha_implementacion, DateTime _modificacion_fecha_hora, string _modificacion_usuario, int _id_equipo, string _rut_usuario_equipo, int _rut_usuario_creador)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "FLUJO_INSERTAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_FECHA_IMPLEMENTACION", OracleDbType.Date).Value = _fecha_implementacion;
                cmd.Parameters.Add("V_MODIFICACION_FECHA_HORA", OracleDbType.Date).Value = _modificacion_fecha_hora;
                cmd.Parameters.Add("V_MODIFICACION_USUARIO", OracleDbType.NVarchar2).Value = _modificacion_usuario;
                cmd.Parameters.Add("V_ID_EQUIPO", OracleDbType.Int32).Value = _id_equipo;
                cmd.Parameters.Add("V_RUT_USUARIO_ASIGNADO", OracleDbType.NVarchar2).Value = _rut_usuario_equipo;
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

    }
}
