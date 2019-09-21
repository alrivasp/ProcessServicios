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
    public class RegionNE
    {
        private RegionDA regionDA = new RegionDA();
        public DataSet TraerRegionSinEntidad(int _id_region)
        {            

            try
            {
                DataSet retorno = new DataSet();               
                retorno = regionDA.TraerRegionSinEntidad(_id_region);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public Region TraerRegionConEntidad(int _id_region)
        {
            try
            {
                Region retorno = new Region();                
                retorno = regionDA.TraerRegionConEntidad(_id_region);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerTodasRegiones()
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = regionDA.TraerTodasRegiones();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
