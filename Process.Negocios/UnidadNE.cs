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
    public class UnidadNE
    {
        private UnidadDA unidadDA = new UnidadDA();

        public int InsertarUnidadConEntidad(Unidad _unidad)
        {
            try
            {
                int retorno = 0;
                retorno = unidadDA.InsertarUnidadConEntidad(_unidad);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int InsertarUnidadSinEntidad(string _nombre, string _descripcion, int _estado, string _rut_empresa)
        {
            try
            {
                int retorno = 0;
                retorno = unidadDA.InsertarUnidadSinEntidad(_nombre,_descripcion,_estado,_rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarUnidadConEntidad(Unidad _unidad)
        {
            try
            {
                int retorno = 0;
                retorno = unidadDA.ActualizarUnidadConEntidad(_unidad);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarUnidadSinEntidad(int _id_unidad, string _nombre, string _descripcion, int _estado, string _rut_empresa)
        {
            try
            {
                int retorno = 0;
                retorno = unidadDA.ActualizarUnidadSinEntidad(_id_unidad, _nombre, _descripcion, _estado, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public DataSet TraerUnidadSinEntidad(int _id_unidad, string _rut_empresa)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = unidadDA.TraerUnidadSinEntidad(_id_unidad, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public Unidad TraerUnidadConEntidad(int _id_unidad, string _rut_empresa)
        {
            try
            {
                Unidad retorno = new Unidad();
                retorno = unidadDA.TraerUnidadConEntidad(_id_unidad, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerTodasUnidades(string _rut_empresa)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = unidadDA.TraerTodasUnidades(_rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
