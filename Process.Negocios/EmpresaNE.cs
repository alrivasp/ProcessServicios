using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Process.Datos;
using Process.Modelos;

namespace Process.Negocios
{
    public class EmpresaNE
    {
        private EmpresaDA empresaDA = new EmpresaDA();

        public int InsertarEmpresaConEntidad(Empresa _unidad)
        {
            try
            {
                int retorno = 0;
                retorno = empresaDA.InsertarEmpresaConEntidad(_unidad);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int InsertarEmpresaSinEntidad(string _rut_empresa, string _nombre, string _giro, string _direccion, int _estado, int _id_comuna)
        {
            try
            {
                int retorno = 0;
                retorno = empresaDA.InsertarEmpresaSinEntidad(_rut_empresa,_nombre, _giro, _direccion, _estado, _id_comuna);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarEmpresaConEntidad(Empresa _unidad)
        {
            try
            {
                int retorno = 0;
                retorno = empresaDA.ActualizarEmpresaConEntidad(_unidad);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarEmpresaSinEntidad(string _rut_empresa, string _nombre, string _giro, string _direccion, int _estado, int _id_comuna)
        {
            try
            {
                int retorno = 0;
                retorno = empresaDA.ActualizarEmpresaSinEntidad(_rut_empresa, _nombre, _giro, _direccion, _estado, _id_comuna);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public DataSet TraerEmpresaSinEntidad(string _rut_empresa)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = empresaDA.TraerEmpresaSinEntidad(_rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public Empresa TraerEmpresaConEntidad(string _rut_empresa)
        {
            try
            {
                Empresa retorno = new Empresa();
                retorno = empresaDA.TraerEmpresaConEntidad(_rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerEmpresaConClaveSinEntidad(string _palabra_clave)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = empresaDA.TraerEmpresaConClaveSinEntidad(_palabra_clave);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerTodasEmpresas()
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = empresaDA.TraerTodasEmpresas();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
