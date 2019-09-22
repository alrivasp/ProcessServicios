﻿using System;
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

        public int InsertarCuentaConEntidad(Cuenta _unidad)
        {
            try
            {
                int retorno = 0;
                retorno = cuentaDA.InsertarCuentaConEntidad(_unidad);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int InsertarCuentaSinEntidad(string _rut_usuario, string _rut_empresa, string _contrasena, int _estado, int _id_rol)
        {
            try
            {
                int retorno = 0;
                retorno = cuentaDA.InsertarCuentaSinEntidad(_rut_usuario, _rut_empresa, _contrasena, _estado, _id_rol);
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

        public int ActualizarCuentaSinEntidad(string _rut_usuario, string _rut_empresa, string _contrasena, int _estado, int _id_rol)
        {
            try
            {
                int retorno = 0;
                retorno = cuentaDA.ActualizarCuentaSinEntidad(_rut_usuario, _rut_empresa, _contrasena, _estado, _id_rol);
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
    }
}