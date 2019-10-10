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
    public class PermisosNE
    {
        private PermisosDA permisosDA = new PermisosDA();

        public int InsertarPermisosSinEntidad(int _id_acceso, int _rol)
        {
            try
            {
                int retorno = 0;
                retorno = permisosDA.InsertarPermisosSinEntidad(_id_acceso, _rol);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarPermisosSinEntidad(int _id_acceso, int _rol)
        {
            try
            {
                int retorno = 0;
                retorno = permisosDA.ActualizarPermisosSinEntidad(_id_acceso, _rol);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public DataSet TraerPermisosPorAccesoPorRolSinEntidad(int _id_acceso, int _rol)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = permisosDA.TraerPermisosPorAccesoPorRolSinEntidad(_id_acceso, _rol);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public Permisos TraerPermisosPorRolConEntidad(int _rol)
        {
            try
            {
                Permisos retorno = new Permisos();
                retorno = permisosDA.TraerPermisosPorRolConEntidad(_rol);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerPermisosPorRolSinEntidad(int _rol)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = permisosDA.TraerPermisosPorRolSinEntidad(_rol);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
