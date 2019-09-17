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
    public class UnidadDA
    {
        public int InsertarUnidadConEntidad(Unidad _entidad)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                if (_entidad != null)
                {
                    string procedure = "UNIDAD_INSERTAR";
                    OracleConnection cnx = Global.CadenaConexionGlobal;
                    cmd = new OracleCommand(procedure, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _entidad.Nombre;
                    cmd.Parameters.Add("V_DESCRIPCION", OracleDbType.NVarchar2).Value = _entidad.Descripcion;
                    cmd.Parameters.Add("V_ESTADO", OracleDbType.Char).Value = _entidad.Estado;
                    cmd.Parameters.Add("V_RUT_EMPRESA", OracleDbType.NVarchar2).Value = _entidad.Rut_empresa;

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

        public int InsertarUnidadSinEntidad(string _nombre, string _descripcion, int _estado, string _rut_empresa)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "UNIDAD_INSERTAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _nombre;
                cmd.Parameters.Add("V_DESCRIPCION", OracleDbType.NVarchar2).Value = _descripcion;
                cmd.Parameters.Add("V_ESTADO", OracleDbType.Char).Value = _estado;
                cmd.Parameters.Add("V_RUT_EMPRESA", OracleDbType.NVarchar2).Value = _rut_empresa;

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

        public int ActualizarUnidadConEntidad(Unidad _entidad)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                if (_entidad != null)
                {
                    string procedure = "UNIDAD_ACTUALIZAR";
                    OracleConnection cnx = Global.CadenaConexionGlobal;
                    cmd = new OracleCommand(procedure, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("V_ID_UNIDAD", OracleDbType.Int32).Value = _entidad.Id_unidad;
                    cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _entidad.Nombre;
                    cmd.Parameters.Add("V_DESCRIPCION", OracleDbType.NVarchar2).Value = _entidad.Descripcion;
                    cmd.Parameters.Add("V_ESTADO", OracleDbType.Char).Value = _entidad.Estado;
                    cmd.Parameters.Add("V_RUT_EMPRESA", OracleDbType.NVarchar2).Value = _entidad.Rut_empresa;

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

        public int ActualizarUnidadSinEntidad(int _id_unidad,string _nombre, string _descripcion, int _estado, string _rut_empresa)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "UNIDAD_ACTUALIZAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_UNIDAD", OracleDbType.Int32).Value = _id_unidad;
                cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _nombre;
                cmd.Parameters.Add("V_DESCRIPCION", OracleDbType.NVarchar2).Value = _descripcion;
                cmd.Parameters.Add("V_ESTADO", OracleDbType.Char).Value = _estado;
                cmd.Parameters.Add("V_RUT_EMPRESA", OracleDbType.NVarchar2).Value = _rut_empresa;

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

        public DataSet TraerUnidadSinEntidad(int _id_unidad, string _rut_empresa)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "UNIDAD_TRAER_UNIDAD";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_UNIDAD", OracleDbType.Int32).Value = _id_unidad;
                cmd.Parameters.Add("V_RUT_EMPRESA", OracleDbType.NVarchar2).Value = _rut_empresa;

                OracleParameter retorno = cmd.Parameters.Add("C_UNIDAD", OracleDbType.RefCursor);
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

        public Unidad TraerUnidadConEntidad(int _id_unidad, string _rut_empresa)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            Unidad unidad = new Unidad();
            try
            {
                string procedure = "UNIDAD_TRAER_UNIDAD";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_UNIDAD", OracleDbType.Int32).Value = _id_unidad;
                cmd.Parameters.Add("V_RUT_EMPRESA", OracleDbType.NVarchar2).Value = _rut_empresa;

                OracleParameter retorno = cmd.Parameters.Add("C_UNIDAD", OracleDbType.RefCursor);
                retorno.Direction = ParameterDirection.Output;

                cmd.Connection.Open();

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    datos.Tables.Add(dt);
                    unidad.FillFromDataSet(datos);
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

            return unidad;
        }

        public DataSet TraerTodasUnidades(string _rut_empresa)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "UNIDAD_TRAER_TODAS_UNIDADES";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_RUT_EMPRESA", OracleDbType.NVarchar2).Value = _rut_empresa;

                OracleParameter retorno = cmd.Parameters.Add("C_UNIDADES", OracleDbType.RefCursor);
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
