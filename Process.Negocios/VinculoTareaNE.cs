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

        public int ActualizarVinculoTarea(int _id_tarea_hijo, int _id_tarea_padre, int _tipo)
        {

            try
            {
                int retorno = 0;
                retorno = vinculoTareaDA.ActualizarVinculoTarea(_id_tarea_hijo, _id_tarea_padre, _tipo);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int EliminarTodosVinculosTarea(int _id_tarea)
        {

            try
            {
                int retorno = 0;
                retorno = vinculoTareaDA.EliminarTodosVinculosTarea(_id_tarea);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int EliminarVinculoTarea(int _id_tarea_padre, int _id_tarea_hijo)
        {

            try
            {
                int retorno = 0;
                retorno = vinculoTareaDA.EliminarVinculoTarea(_id_tarea_padre, _id_tarea_hijo);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public DataSet TraerTodosVinculosTarea(int _id_tarea)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = vinculoTareaDA.TraerTodosVinculosTarea(_id_tarea);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerTodosVinculosTareaHijo(int _id_tarea)
        {

            try
            {
                DataSet retorno = new DataSet();
                retorno = vinculoTareaDA.TraerTodosVinculosTareaHijo(_id_tarea);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
