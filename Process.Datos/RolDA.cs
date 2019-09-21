using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Process.Modelos;

namespace Process.Datos
{
    public class RolDA
    {
        public int InsertarRolConEntidad(Rol _entidad)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                if (_entidad != null)
                {
                    string procedure = "ROL_INSERTAR";
                    OracleConnection cnx = Global.CadenaConexionGlobal;
                    cmd = new OracleCommand(procedure, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _entidad.Nombre;                    
                    cmd.Parameters.Add("V_ESTADO", OracleDbType.Char).Value = _entidad.Estado;                    

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

        public int InsertarRolSinEntidad(string _nombre, int _estado)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "ROL_INSERTAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _nombre;
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

        public int ActualizarRolConEntidad(Rol _entidad)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                if (_entidad != null)
                {
                    string procedure = "ROL_ACTUALIZAR";
                    OracleConnection cnx = Global.CadenaConexionGlobal;
                    cmd = new OracleCommand(procedure, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("V_ID_ROL", OracleDbType.Int32).Value = _entidad.Id_rol;
                    cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _entidad.Nombre;                    
                    cmd.Parameters.Add("V_ESTADO", OracleDbType.Char).Value = _entidad.Estado;                    

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

        public int ActualizarRolSinEntidad(int _id_rol,string _nombre, int _estado)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "ROL_ACTUALIZAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_ROL", OracleDbType.Int32).Value = _id_rol;
                cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _nombre;
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

        public DataSet TraerRolSinEntidad(int _id_rol)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "ROL_TRAER_ROL";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_ROL", OracleDbType.Int32).Value = _id_rol;                

                OracleParameter retorno = cmd.Parameters.Add("C_ROLES", OracleDbType.RefCursor);
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

        public Rol TraerRolConEntidad(int _id_rol)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            Rol rol = new Rol();
            try
            {
                string procedure = "ROL_TRAER_ROL";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_ROL", OracleDbType.Int32).Value = _id_rol;

                OracleParameter retorno = cmd.Parameters.Add("C_ROLES", OracleDbType.RefCursor);
                retorno.Direction = ParameterDirection.Output;

                cmd.Connection.Open();

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    datos.Tables.Add(dt);
                    rol.FillFromDataSet(datos);
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

            return rol;
        }

        public DataSet TraerTodosRoles()
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "ROL_TRAER_TODOS_ROL";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
             
                OracleParameter retorno = cmd.Parameters.Add("C_ROLES", OracleDbType.RefCursor);
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
