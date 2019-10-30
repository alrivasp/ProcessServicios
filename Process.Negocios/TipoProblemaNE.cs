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
    public class TipoProblemaNE
    {
        private TipoProblemaDA tipoProblemaDA = new TipoProblemaDA();

        public DataSet TraerTodosTipoProblema()
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = tipoProblemaDA.TraerTodosTipoProblema();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

    }
}
