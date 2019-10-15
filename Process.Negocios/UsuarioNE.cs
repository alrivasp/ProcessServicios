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
    public class UsuarioNE
    {
        private UsuarioDA usuarioDA = new UsuarioDA();

        public int InsertarUsuarioConEntidad(Usuario _unidad)
        {
            try
            {
                int retorno = 0;
                retorno = usuarioDA.InsertarUsuarioConEntidad(_unidad);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int InsertarrUsuarioSinEntidad(string _rut_usuario, string _primer_nombre, string _segundo_nombre, string _primer_apellido
                                            , string _segundo_apellido, string _direccion, int _telefono_fijp
                                            , int _telefono_movil, int _id_comuna)
        {
            try
            {
                int retorno = 0;
                retorno = usuarioDA.InsertarUsuarioSinEntidad(_rut_usuario, _primer_nombre, _segundo_nombre, _primer_apellido, _segundo_apellido
                                                              , _direccion, _telefono_fijp, _telefono_movil, _id_comuna);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarrUsuarioConEntidad(Usuario _unidad)
        {
            try
            {
                int retorno = 0;
                retorno = usuarioDA.ActualizarUsuarioConEntidad(_unidad);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarrUsuarioSinEntidad(string _rut_usuario, string _primer_nombre, string _segundo_nombre, string _primer_apellido
                                            , string _segundo_apellido, string _direccion, int _telefono_fijp
                                            , int _telefono_movil, int _id_comuna)
        {
            try
            {
                int retorno = 0;
                retorno = usuarioDA.ActualizarUsuarioSinEntidad(_rut_usuario, _primer_nombre, _segundo_nombre, _primer_apellido, _segundo_apellido
                                                              , _direccion, _telefono_fijp, _telefono_movil, _id_comuna);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public DataSet TraerrUsuarioSinEntidad(string _rut_usuario)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = usuarioDA.TraerUsuarioSinEntidad(_rut_usuario);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public Usuario TraerUsuarioConEntidad(string _rut_usuario)
        {
            try
            {
                Usuario retorno = new Usuario();
                retorno = usuarioDA.TraerUsuarioConEntidad(_rut_usuario);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerUsuarioConClaveSinEntidad(string _palabra_clave)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = usuarioDA.TraerUsuarioConClaveSinEntidad(_palabra_clave);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerUsuarioConClavePorEmpresaSinEntidad(string _rut_empresa, string _palabra_clave)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = usuarioDA.TraerUsuarioConClavePorEmpresaSinEntidad(_rut_empresa, _palabra_clave);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerUsuarioConFiltroSinEntidad(string _palabra_clave)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = usuarioDA.TraerUsuarioConFiltroSinEntidad(_palabra_clave);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerUsuarioPorRutPorEmpresaSinEntidad(string _rut_usuario, string _rut_empresa)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = usuarioDA.TraerUsuarioPorRutPorEmpresaSinEntidad(_rut_usuario, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerUsuarioPorEmpresaSinEntidad(string _rut_empresa)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = usuarioDA.TraerUsuarioPorEmpresaSinEntidad(_rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerTodasrUsuarios()
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = usuarioDA.TraerTodasUsuarios();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerTodasUsuariosJoin()
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = usuarioDA.TraerTodasUsuariosJoin();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
