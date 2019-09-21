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
    public class AccesoNE
    {
        private AccesoDA accesoDA = new AccesoDA();
        public DataSet TraerAccesoSinEntidad(int _id_acceso)
        {

            try
            {
                DataSet retorno = new DataSet();
                retorno = accesoDA.TraerAccesoSinEntidad(_id_acceso);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public Acceso TraerAccesoConEntidad(int _id_acceso)
        {
            try
            {
                Acceso retorno = new Acceso();
                retorno = accesoDA.TraerAccesoConEntidad(_id_acceso);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerTodosAccesos()
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = accesoDA.TraerTodosAccesos();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
