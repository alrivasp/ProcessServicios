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
    public class CargosUsuariosNE
    {
        private CargosUsuariosDA cargosUsuariosDA = new CargosUsuariosDA();

        public int InsertarCargosUsuarioSinEntidad(string _rut_usuario, int _id_cargo, int _estado)
        {
            try
            {
                int retorno = 0;
                retorno = cargosUsuariosDA.InsertarCargosUsuarioSinEntidad(_rut_usuario, _id_cargo, _estado);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarCargosUsuarioSinEntidad(string _rut_usuario, int _id_cargo, int _estado)
        {
            try
            {
                int retorno = 0;
                retorno = cargosUsuariosDA.ActualizarCargosUsuarioSinEntidad(_rut_usuario, _id_cargo, _estado);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public DataSet TraerCargosUsuarioPorRutPorCargoSinEntidad(string _rut_usuario, int _id_cargo)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = cargosUsuariosDA.TraerCargosUsuarioPorRutPorCargoSinEntidad(_rut_usuario, _id_cargo);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerCargosUsuarioPorRutSinEntidad(string _rut_usuario)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = cargosUsuariosDA.TraerCargosUsuarioPorRutSinEntidad(_rut_usuario);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
