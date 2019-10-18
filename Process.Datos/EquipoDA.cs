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
    public class EquipoDA
    {
        public int InsertarEquipoSinEntidad(string _nombre, int _id_unidad)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "EQUIPO_INSERTAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _nombre;                
                cmd.Parameters.Add("V_ID_UNIDAD", OracleDbType.Int32).Value = _id_unidad;

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

        public int ActualizarEquipoSinEntidad(int _id_equipo, string _nombre, int _id_unidad)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "EQUIPO_ACTUALIZAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_EQUIPO", OracleDbType.Int32).Value = _id_equipo;
                cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _nombre;
                cmd.Parameters.Add("V_ID_UNIDAD", OracleDbType.Int32).Value = _id_unidad;

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

        public Equipo TraerEquipoConEntidad(int _id_equipo)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            Equipo equipo = new Equipo();
            try
            {
                string procedure = "EQUIPO_TRAER_EQUIPO";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_EQUIPO", OracleDbType.Int32).Value = _id_equipo;

                OracleParameter retorno = cmd.Parameters.Add("C_EQUIPO", OracleDbType.RefCursor);
                retorno.Direction = ParameterDirection.Output;

                cmd.Connection.Open();

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    datos.Tables.Add(dt);
                    equipo.FillFromDataSet(datos);
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

            return equipo;
        }

        public DataSet TraerEquipoPorClaveSinEntidad(int _id_unidad,string _rut_empresa ,string _clave)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "EQUIPO_TRAER_POR_CLAVE";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_UNIDAD", OracleDbType.Int32).Value = _id_unidad;
                cmd.Parameters.Add("V_RUT_EMPRESA", OracleDbType.NVarchar2).Value = _rut_empresa;
                cmd.Parameters.Add("V_CLAVE", OracleDbType.NVarchar2).Value = _clave;

                OracleParameter retorno = cmd.Parameters.Add("C_EQUIPOS ", OracleDbType.RefCursor);
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

        public DataSet TraerEquipoPorEmpresaPorUnidadSinEntidad(int _id_unidad, string _rut_empresa)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "EQUIPO_TRAER_POR_EMP_UNI";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_ID_UNIDAD", OracleDbType.Int32).Value = _id_unidad;
                cmd.Parameters.Add("V_RUT_EMPRESA", OracleDbType.NVarchar2).Value = _rut_empresa;                

                OracleParameter retorno = cmd.Parameters.Add("C_EQUIPOS ", OracleDbType.RefCursor);
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


        public DataSet TraerEquipoPorNombreSinEntidad(string _nombre, int _id_unidad)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "EQUIPO_TRAER_EQUIPO_NOMBRE";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _nombre;
                cmd.Parameters.Add("V_ID_UNIDAD", OracleDbType.Int32).Value = _id_unidad;

                OracleParameter retorno = cmd.Parameters.Add("C_EQUIPO", OracleDbType.RefCursor);
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

        public Equipo TraerEquipoPorNombreConEntidad(string _nombre, int _id_unidad)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            Equipo equipo = new Equipo();
            try
            {
                string procedure = "EQUIPO_TRAER_EQUIPO_NOMBRE";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _nombre;
                cmd.Parameters.Add("V_ID_UNIDAD", OracleDbType.Int32).Value = _id_unidad;

                OracleParameter retorno = cmd.Parameters.Add("C_EQUIPO", OracleDbType.RefCursor);
                retorno.Direction = ParameterDirection.Output;

                cmd.Connection.Open();

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    datos.Tables.Add(dt);
                    equipo.FillFromDataSet(datos);
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

            return equipo;
        }
    }
}
