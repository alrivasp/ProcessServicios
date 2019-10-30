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
    public class HistorialTareaNE
    {
        private HistorialTareaDA historialTareaDA = new HistorialTareaDA();

        public int InsertarHistorialTarea(string _descripcion, int _id_estado_tarea, int _id_tarea)
        {

            try
            {
                int retorno = 0;
                retorno = historialTareaDA.InsertarHistorialTarea(_descripcion, _id_estado_tarea, _id_tarea);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarHistorialTarea(int _id_historial_tarea, string _descripcion, int _id_estado_tarea, int _id_tarea)
        {

            try
            {
                int retorno = 0;
                retorno = historialTareaDA.ActualizarHistorialTarea(_id_historial_tarea, _descripcion, _id_estado_tarea, _id_tarea);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public DataSet TraerTodosHistorialTarea()
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = historialTareaDA.TraerTodosHistorialTarea();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

    }
}
