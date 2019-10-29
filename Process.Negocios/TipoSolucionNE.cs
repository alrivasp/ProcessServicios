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
        public int InsertarTipoSolucion(string _descripcion)
        {

            try
            {
                int retorno = 0;
                retorno = tipoSolucionDA.InsertarTipoSolucion(_descripcion);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }
    }
}
