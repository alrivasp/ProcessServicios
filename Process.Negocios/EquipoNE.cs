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
    public class EquipoNE
    {
        private EquipoDA equipoDA = new EquipoDA();

        public int InsertarEquipoSinEntidad(string _nombre, int _id_unidad)
        {
            try
            {
                int retorno = 0;
                retorno = equipoDA.InsertarEquipoSinEntidad(_nombre, _id_unidad);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarEquipoSinEntidad(int _id_equipo, string _nombre, int _id_unidad)
        {
            try
            {
                int retorno = 0;
                retorno = equipoDA.ActualizarEquipoSinEntidad(_id_equipo, _nombre, _id_unidad);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public Equipo TraerEquipoConEntidad(int _id_equipo)
        {
            try
            {
                Equipo retorno = new Equipo();
                retorno = equipoDA.TraerEquipoConEntidad(_id_equipo);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerEquipoPorClaveSinEntidad(int _id_unidad, string _rut_empresa, string _clave)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = equipoDA.TraerEquipoPorClaveSinEntidad(_id_unidad, _rut_empresa, _clave);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerEquipoPorEmpresaPorUnidadSinEntidad(int _id_unidad, string _rut_empresa)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = equipoDA.TraerEquipoPorEmpresaPorUnidadSinEntidad(_id_unidad, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerEquipoPorNombreSinEntidad(string _nombre, int _id_unidad)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = equipoDA.TraerEquipoPorNombreSinEntidad(_nombre, _id_unidad);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public Equipo TraerEquipoPorNombreConEntidad(string _nombre, int _id_unidad)
        {
            try
            {
                Equipo retorno = new Equipo();
                retorno = equipoDA.TraerEquipoPorNombreConEntidad(_nombre, _id_unidad);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
