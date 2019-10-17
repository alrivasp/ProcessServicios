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
    public class UsuarioEquipoNE
    {
        private UsuarioEquipoDA usuarioEquipoDA = new UsuarioEquipoDA();

        public int InsertarUsuarioEquipoSinEntidad(string _rut_usuario, int _id_equipo, int _responsable)
        {
            try
            {
                int retorno = 0;
                retorno = usuarioEquipoDA.InsertarUsuarioEquipoSinEntidad(_rut_usuario, _id_equipo, _responsable);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarUsuarioEquipoSinEntidad(string _rut_usuario, int _id_equipo, int _responsable)
        {
            try
            {
                int retorno = 0;
                retorno = usuarioEquipoDA.ActualizarUsuarioEquipoSinEntidad(_rut_usuario, _id_equipo, _responsable);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public UsuarioEquipo TraerUsuarioEquiPorEquipoPorRutConEntidad(int _id_equipo, string _rut_usuario)
        {
            try
            {
                UsuarioEquipo retorno = new UsuarioEquipo();
                retorno = usuarioEquipoDA.TraerUsuarioEquiPorEquipoPorRutConEntidad(_id_equipo, _rut_usuario);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerUsuarioEquipoSinEntidad(int _id_equipo)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = usuarioEquipoDA.TraerUsuarioEquipoSinEntidad(_id_equipo);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
