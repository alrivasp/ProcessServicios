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
    public class EstadoTareaNE
    {
        private EstadoTareaDA estadoTareaDA = new EstadoTareaDA();

        public DataSet TraerTodosEstadoTarea()
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = estadoTareaDA.TraerTodosEstadoTarea();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

    }
}
