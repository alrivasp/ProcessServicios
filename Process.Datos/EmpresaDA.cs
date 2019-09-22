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
    public class EmpresaDA
    {
        public int InsertarEmpresaConEntidad(Empresa _entidad)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                if (_entidad != null)
                {
                    string procedure = "EMPRESA_INSERTAR";
                    OracleConnection cnx = Global.CadenaConexionGlobal;
                    cmd = new OracleCommand(procedure, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("V_RUT_EMPRESA", OracleDbType.NVarchar2).Value = _entidad.Rut_empresa;
                    cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _entidad.Nombre;
                    cmd.Parameters.Add("V_GIRO", OracleDbType.NVarchar2).Value = _entidad.Giro;
                    cmd.Parameters.Add("V_DIRECCION", OracleDbType.NVarchar2).Value = _entidad.Direccion;
                    cmd.Parameters.Add("V_ESTADO", OracleDbType.Char).Value = _entidad.Estado;
                    cmd.Parameters.Add("V_ID_COMUNA", OracleDbType.Int32).Value = _entidad.Id_comuna;

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

        public int InsertarEmpresaSinEntidad(string _rut_empresa, string _nombre, string _giro, string _direccion, int _estado,int _id_comuna)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "EMPRESA_INSERTAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_RUT_EMPRESA", OracleDbType.NVarchar2).Value = _rut_empresa;
                cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _nombre;
                cmd.Parameters.Add("V_GIRO", OracleDbType.NVarchar2).Value = _giro;
                cmd.Parameters.Add("V_DIRECCION", OracleDbType.NVarchar2).Value = _direccion;
                cmd.Parameters.Add("V_ESTADO", OracleDbType.Char).Value = _estado;
                cmd.Parameters.Add("V_ID_COMUNA", OracleDbType.Int32).Value = _id_comuna;


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

        public int ActualizarEmpresaConEntidad(Empresa _entidad)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                if (_entidad != null)
                {
                    string procedure = "EMPRESA_ACTUALIZAR";
                    OracleConnection cnx = Global.CadenaConexionGlobal;
                    cmd = new OracleCommand(procedure, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("V_RUT_EMPRESA", OracleDbType.NVarchar2).Value = _entidad.Rut_empresa;
                    cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _entidad.Nombre;
                    cmd.Parameters.Add("V_GIRO", OracleDbType.NVarchar2).Value = _entidad.Giro;
                    cmd.Parameters.Add("V_DIRECCION", OracleDbType.NVarchar2).Value = _entidad.Direccion;
                    cmd.Parameters.Add("V_ESTADO", OracleDbType.Char).Value = _entidad.Estado;
                    cmd.Parameters.Add("V_ID_COMUNA", OracleDbType.Int32).Value = _entidad.Id_comuna;


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

        public int ActualizarEmpresaSinEntidad(string _rut_empresa, string _nombre, string _giro, string _direccion, int _estado, int _id_comuna)
        {
            OracleCommand cmd = null;
            int respuesta = 0;
            try
            {
                string procedure = "EMPRESA_ACTUALIZAR";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_RUT_EMPRESA", OracleDbType.NVarchar2).Value = _rut_empresa;
                cmd.Parameters.Add("V_NOMBRE", OracleDbType.NVarchar2).Value = _nombre;
                cmd.Parameters.Add("V_GIRO", OracleDbType.NVarchar2).Value = _giro;
                cmd.Parameters.Add("V_DIRECCION", OracleDbType.NVarchar2).Value = _direccion;
                cmd.Parameters.Add("V_ESTADO", OracleDbType.Char).Value = _estado;
                cmd.Parameters.Add("V_ID_COMUNA", OracleDbType.Int32).Value = _id_comuna;

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

        public DataSet TraerEmpresaSinEntidad(string _rut_empresa)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "EMPRESA_TRAER_EMPRESA";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add("V_RUT_EMPRESA", OracleDbType.NVarchar2).Value = _rut_empresa;

                OracleParameter retorno = cmd.Parameters.Add("C_EMPRESA", OracleDbType.RefCursor);
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

        public Empresa TraerEmpresaConEntidad(string _rut_empresa)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            Empresa empresa = new Empresa();
            try
            {
                string procedure = "EMPRESA_TRAER_EMPRESA";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
   
                cmd.Parameters.Add("V_RUT_EMPRESA", OracleDbType.NVarchar2).Value = _rut_empresa;

                OracleParameter retorno = cmd.Parameters.Add("C_EMPRESA", OracleDbType.RefCursor);
                retorno.Direction = ParameterDirection.Output;

                cmd.Connection.Open();

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    datos.Tables.Add(dt);
                    empresa.FillFromDataSet(datos);
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

            return empresa;
        }

        public DataSet TraerEmpresaConClaveSinEntidad(string _palabra_clave)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "EMPRESA_TRAER_EMPRESA_CLAVE";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("V_CLAVE", OracleDbType.NVarchar2).Value = _palabra_clave;

                OracleParameter retorno = cmd.Parameters.Add("C_EMPRESA", OracleDbType.RefCursor);
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

        public DataSet TraerTodasEmpresas()
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            DataSet datos = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                string procedure = "EMPRESA_TRAER_TODAS_EMPRESA";
                OracleConnection cnx = Global.CadenaConexionGlobal;
                cmd = new OracleCommand(procedure, cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter retorno = cmd.Parameters.Add("C_EMPRESAS", OracleDbType.RefCursor);
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
