using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Process.Modelos;

namespace Process.Datos
{
    public class CargosUsuariosDA
    {
        public int InsertarCargosUsuarioSinEntidad(string _rut_usuario, int _id_cargo, int _estado)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "CARGOS_USUARIOS_INSERTAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_RUT_USUARIO", OracleDbType.NVarchar2).Value = _rut_usuario;
                cmd.Parameters.Add("V_ID_CARGO", OracleDbType.Int32).Value = _id_cargo;
                cmd.Parameters.Add("V_ESTADO", OracleDbType.Char).Value = _estado;                

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

        public int ActualizarCargosUsuarioSinEntidad(string _rut_usuario, int _id_cargo, int _estado)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "CARGOS_USUARIOS_ACTUALIZAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_RUT_USUARIO", OracleDbType.NVarchar2).Value = _rut_usuario;
                cmd.Parameters.Add("V_ID_CARGO", OracleDbType.Int32).Value = _id_cargo;
                cmd.Parameters.Add("V_ESTADO", OracleDbType.Char).Value = _estado;

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

        public DataSet TraerCargosUsuarioPorRutPorCargoSinEntidad(string _rut_usuario, int _id_cargo)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "CARGOS_USUARIOS_TRAER_CAR_USU";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_RUT_USUARIO", OracleDbType.NVarchar2).Value = _rut_usuario;
                cmd.Parameters.Add("V_ID_CARGO", OracleDbType.Int32).Value = _id_cargo;

                OracleParameter retorno = cmd.Parameters.Add("C_USUARIO", OracleDbType.RefCursor);
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
