
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
    public class RolNE
    {
        private RolDA rolDA = new RolDA();

        public int InsertarRolConEntidad(Rol _unidad)
        {
            try
            {
                int retorno = 0;
                retorno = rolDA.InsertarRolConEntidad(_unidad);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int InsertarRolSinEntidad(string _nombre, int _estado)
        {
            try
            {
                int retorno = 0;
                retorno = rolDA.InsertarRolSinEntidad(_nombre, _estado);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarRolConEntidad(Rol _unidad)
        {
            try
            {
                int retorno = 0;
                retorno = rolDA.ActualizarRolConEntidad(_unidad);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarRolSinEntidad(int _id_rol, string _nombre, int _estado)
        {
            try
            {
                int retorno = 0;
                retorno = rolDA.ActualizarRolSinEntidad(_id_rol, _nombre, _estado);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public DataSet TraerRolSinEntidad(int _id_rol)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = rolDA.TraerRolSinEntidad(_id_rol);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerRolPorNombreSinEntidad(string _nombre)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = rolDA.TraerRolPorNombreSinEntidad(_nombre);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public Rol TraerRolConEntidad(int _id_rol)
        {
            try
            {
                Rol retorno = new Rol();
                retorno = rolDA.TraerRolConEntidad(_id_rol);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public Rol TraerRolPorNombreConEntidad(string _nombre)
        {
            try
            {
                Rol retorno = new Rol();
                retorno = rolDA.TraerRolPorNombreConEntidad(_nombre);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerTodasRoles()
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = rolDA.TraerTodosRoles();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerRolConClaveSinEntidad(string _palabra_clave)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = rolDA.TraerRolConClaveSinEntidad(_palabra_clave);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
