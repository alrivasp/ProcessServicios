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
    public class TareaNE
    {
        private TareaDA tareaDA = new TareaDA();
        public int InsertarTarea(string _nombre, string _descripcion, DateTime _fecha_inicio, DateTime _fecha_termino,
                                    string _modificacion_usuario_cambio, int _id_flujo, int _id_estado_tarea, string _rut_usuario_asignado, string _rut_usuario_creador)
        {

            try
            {
                int retorno = 0;
                retorno = tareaDA.InsertarTarea(_nombre, _descripcion, _fecha_inicio, _fecha_termino, _modificacion_usuario_cambio, _id_flujo, _id_estado_tarea, _rut_usuario_asignado, _rut_usuario_creador);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarTarea(int _id_tarea, string _nombre, string _descripcion, DateTime _fecha_inicio, DateTime _fecha_termino,
                                   string _modificacion_usuario_cambio, int _id_flujo, int _id_estado_tarea, string _rut_usuario_asignado, string _rut_usuario_creador)
        {

            try
            {
                int retorno = 0;
                retorno = tareaDA.ActualizarTarea(_id_tarea, _nombre, _descripcion, _fecha_inicio, _fecha_termino, _modificacion_usuario_cambio, _id_flujo, _id_estado_tarea, _rut_usuario_asignado, _rut_usuario_creador);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public DataSet TraerTodosTarea()
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = tareaDA.TraerTodosTarea();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
