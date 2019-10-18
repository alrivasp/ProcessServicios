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
    public class CuentaNE
    {
        private CuentaDA cuentaDA = new CuentaDA();
        private Global global = new Global();

        public int InsertarCuentaConEntidad(Cuenta _unidad)
        {
            try
            {
                int retorno = 0;
                _unidad.Contrasena = global.Encriptar(_unidad.Contrasena);
                retorno = cuentaDA.InsertarCuentaConEntidad(_unidad);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int InsertarCuentaSinEntidad(string _rut_usuario, string _rut_empresa, string _contrasena, int _estado, int _id_rol, string _correo)
        {
            try
            {
                int retorno = 0;
                _contrasena = global.Encriptar(_contrasena);
                retorno = cuentaDA.InsertarCuentaSinEntidad(_rut_usuario, _rut_empresa, _contrasena, _estado, _id_rol, _correo);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarCuentaConEntidad(Cuenta _unidad)
        {
            try
            {
                int retorno = 0;
                retorno = cuentaDA.ActualizarCuentaConEntidad(_unidad);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarCuentaSinEntidad(string _rut_usuario, string _rut_empresa, int _estado, int _id_rol, string _correo)
        {
            try
            {
                int retorno = 0;                
                retorno = cuentaDA.ActualizarCuentaSinEntidad(_rut_usuario, _rut_empresa, _estado, _id_rol, _correo);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarCuentaSoloContrasenaSinEntidad(string _rut_usuario, string _rut_empresa, string _contrasena)
        {
            try
            {
                int retorno = 0;
                _contrasena = global.Encriptar(_contrasena);
                retorno = cuentaDA.ActualizarCuentaSoloContrasenaSinEntidad(_rut_usuario, _rut_empresa, _contrasena);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public DataSet TraerCuentaSinEntidad(string _rut_usuario)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = cuentaDA.TraerCuentaSinEntidad(_rut_usuario);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public Cuenta TraerCuentaConEntidad(string _rut_usuario)
        {
            try
            {
                Cuenta retorno = new Cuenta();
                retorno = cuentaDA.TraerCuentaConEntidad(_rut_usuario);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerCuentaConEmpresaSinEntidad(string _rut_usuario, string _rut_empresa)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = cuentaDA.TraerCuentaConEmpresaSinEntidad(_rut_usuario, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public Cuenta TraerCuentaConEmpresaConEntidad(string _rut_usuario, string _rut_empresa)
        {
            try
            {
                Cuenta retorno = new Cuenta();
                retorno = cuentaDA.TraerCuentaaConEmpresaConEntidad(_rut_usuario, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerTodasCuentas()
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = cuentaDA.TraerTodasCuentas();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerCuentaConClaveSinEntidad(string _palabra_clave)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = cuentaDA.TraerCuentaConClaveSinEntidad(_palabra_clave);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
