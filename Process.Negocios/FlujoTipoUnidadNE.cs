using Process.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Negocios
{
    public class FlujoTipoUnidadNE
    {
        private FlujoTipoUnidadDA flujoTipoUnidadDA = new FlujoTipoUnidadDA();

        public int InsertarFlujoTipoUnidad(int _id_unidad, int _id_tipo_flujo)
        {

            try
            {
                int retorno = 0;
                retorno = flujoTipoUnidadDA.InsertarFlujoTipoUnidad(_id_unidad, _id_tipo_flujo);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int EliminarFlujoTipoUnidad(int _id_tipo_flujo)
        {

            try
            {
                int retorno = 0;
                retorno = flujoTipoUnidadDA.EliminarFlujoTipoUnidad(_id_tipo_flujo);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public DataSet TraerFlujoTipoUnidades(string _id_tipo_flujo)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = flujoTipoUnidadDA.TraerFlujoTipoUnidades(_id_tipo_flujo);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
