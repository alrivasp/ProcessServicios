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
    public class ArchivoNE
    {
        private ArchivoDA archivoDA = new ArchivoDA();
        public int InsertarArchivo(string _ruta, string _nombre, int _id_historial_tarea)
        {

            try
            {
                int retorno = 0;
                retorno = archivoDA.InsertarArchivo(_ruta, _nombre, _id_historial_tarea);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }
    }
}
