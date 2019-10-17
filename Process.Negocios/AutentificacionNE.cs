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
    public class AutentificacionNE
    {
        private AutentificacionDA autentificacionDA = new AutentificacionDA();

        public int Login(string _rut_usuario, string _contrasena)
        {

            try
            {
                int retorno = 0;
                Global.Encriptar(_contrasena);
                retorno = autentificacionDA.Login(_rut_usuario, _contrasena);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public DataSet TraerSesionUsuario(string _rut_usuario, string _rut_empresa)
        {

            try
            {
                DataSet retorno = new DataSet();
                retorno = autentificacionDA.TraerSesionUsuario(_rut_usuario, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerPermisosUsuario(string _rut_usuario, string _rut_empresa)
        {

            try
            {
                DataSet retorno = new DataSet();
                retorno = autentificacionDA.TraerPermisosUsuario(_rut_usuario, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
