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
        public int InsertarTipoProblema(string _descripcion)
        {

            try
            {
                int retorno = 0;
                retorno = tipoProblemaDA.InsertarTipoProblema(_descripcion);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }
    }
}
