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
    public class TipoSolucionNE
    {
        private TipoSolucionDA tipoSolucionDA = new TipoSolucionDA();

        public DataSet TraerTodosTipoSolucion()
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = tipoSolucionDA.TraerTodosTipoSolucion();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

    }
}
