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
    public class ProvinciaNE
    {
        private ProvinciaDA provinciaDA = new ProvinciaDA();
        public DataSet TraerProvinciaSinEntidad(int _id_provincia)
        {

            try
            {
                DataSet retorno = new DataSet();
                retorno = provinciaDA.TraerProvinciaSinEntidad(_id_provincia);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public Provincia TraerProvinciaConEntidad(int _id_provincia)
        {
            try
            {
                Provincia retorno = new Provincia();
                retorno = provinciaDA.TraerProvinciaConEntidad(_id_provincia);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerTodasProvinciasPorRegion(int _id_region)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = provinciaDA.TraerTodasProvinciasPorRegion(_id_region);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerTodasProvincias()
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = provinciaDA.TraerTodasProvincias();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
