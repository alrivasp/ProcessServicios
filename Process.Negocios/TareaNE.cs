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

        public DataSet TraerTodosTareaFlujo(int _id_flujo, string _rut_empresa)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = tareaDA.TraerTodosTareaFlujo(_id_flujo, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerTodosTareaUsuario(string _rut_usuario, string _rut_empresa)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = tareaDA.TraerTodosTareaUsuario(_rut_usuario, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerTodosTareaSubtareas(int id_tarea, string _rut_empresa)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = tareaDA.TraerTodosTareaSubtareas(id_tarea, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
        public DataSet ValidaSubordinacion(int id_tarea)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = tareaDA.ValidaSubordinacion(id_tarea);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerEstadisticasTarea(string _rut_usuario, string _rut_empresa)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = tareaDA.TraerEstadisticasTarea(_rut_usuario, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerEstadisticasTareaMes(string _rut_usuario, string _rut_empresa, int mes)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = tareaDA.TraerEstadisticasTareaMes(_rut_usuario, _rut_empresa, mes);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
