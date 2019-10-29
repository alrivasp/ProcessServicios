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
    public class VinculoTareaNE
    {
        private VinculoTareaDA vinculoTareaDA = new VinculoTareaDA();
        public int InsertarVinculoTarea(int _id_tarea_hijo, int _id_tarea_padre, int _tipo)
        {

            try
            {
                int retorno = 0;
                retorno = vinculoTareaDA.InsertarVinculoTarea(_id_tarea_hijo, _id_tarea_padre, _tipo);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }
    }
}
