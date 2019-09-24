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
    public class CargoNE
    {
        private CargoDA cargoDA = new CargoDA();

        public int InsertarCargoConEntidad(Cargo _unidad)
        {
            try
            {
                int retorno = 0;
                retorno = cargoDA.InsertarCargoConEntidad(_unidad);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int InsertarCargoSinEntidad(string _nombre, string _descripcion, string _rut_empresa)
        {
            try
            {
                int retorno = 0;
                retorno = cargoDA.InsertarCargoSinEntidad(_nombre, _descripcion, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarCargoConEntidad(Cargo _unidad)
        {
            try
            {
                int retorno = 0;
                retorno = cargoDA.ActualizarCargoConEntidad(_unidad);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarCargoSinEntidad(int _id_cargo, string _nombre, string _descripcion, string _rut_empresa)
        {
            try
            {
                int retorno = 0;
                retorno = cargoDA.ActualizarCargoSinEntidad(_id_cargo, _nombre, _descripcion, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public DataSet TraerCargoSinEntidad(int _id_cargo)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = cargoDA.TraerCargoSinEntidad(_id_cargo);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public Cargo TraerCargoConEntidad(int _id_cargo)
        {
            try
            {
                Cargo retorno = new Cargo();
                retorno = cargoDA.TraerCargoConEntidad(_id_cargo);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerCargoConEmpresaSinEntidad(string _rut_empresa)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = cargoDA.TraerCargoConEmpresaSinEntidad(_rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public Cargo TraerCargoConEmpresaConEntidad(string _rut_empresa)
        {
            try
            {
                Cargo retorno = new Cargo();
                retorno = cargoDA.TraerCargoConEmpresaConEntidad(_rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public Cargo TraerCargoPorNombrePorEmpresaConEntidad(string _nombre, string _rut_empresa)
        {
            try
            {
                Cargo retorno = new Cargo();
                retorno = cargoDA.TraerCargoPorNombrePorEmpresaConEntidad(_nombre, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerCargoConClaveSinEntidad(string _palabra_clave)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = cargoDA.TraerCargoConClaveSinEntidad(_palabra_clave);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerTodasCargos()
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = cargoDA.TraerTodosCargos();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
