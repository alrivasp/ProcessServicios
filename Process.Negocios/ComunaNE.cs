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
    public class ComunaNE
    {
        private ComunaDA comunaDA = new ComunaDA();
        public DataSet TraerComunaSinEntidad(int _id_comuna)
        {

            try
            {
                DataSet retorno = new DataSet();
                retorno = comunaDA.TraerComunaSinEntidad(_id_comuna);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public Comuna TraerComunaConEntidad(int _id_comuna)
        {
            try
            {
                Comuna retorno = new Comuna();
                retorno = comunaDA.TraerComunaConEntidad(_id_comuna);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerTodasComunsPorProvincia(int _id_provincia)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = comunaDA.TraerTodasComunasPorProvincia(_id_provincia);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerTodasComunas()
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = comunaDA.TraerTodasComunas();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
