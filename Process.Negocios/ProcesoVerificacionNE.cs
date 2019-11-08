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
    public class ProcesoVerificacionNE
    {
        private ProcesoVerificacionDA procesoVerificacionDA = new ProcesoVerificacionDA();

        public DataSet TraerTareasVencidas()
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = procesoVerificacionDA.TraerTareasVencidas();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerTareasPorVencerHoy()
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = procesoVerificacionDA.TraerTareasPorVencerHoy();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerTareasUnDiaPorVencer()
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = procesoVerificacionDA.TraerTareasUnDiaPorVencer();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerTareasDosDiasPorVencer()
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = procesoVerificacionDA.TraerTareasDosDiasPorVencer();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerInformacionFlujoSinEntidad(int _id_flujo)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = procesoVerificacionDA.TraerInformacionFlujoSinEntidad(_id_flujo);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
