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
    public class ProblemaNE
    {
        private ProblemaDA problemaDA = new ProblemaDA();

        public int InsertarProblema(string _descripcion, int _id_tipo_problema, int _id_tarea)
        {

            try
            {
                int retorno = 0;
                retorno = problemaDA.InsertarProblema(_descripcion, _id_tipo_problema, _id_tarea);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarProblema(int _id_problema, string _descripcion, int _id_tipo_problema, int _id_tarea)
        {

            try
            {
                int retorno = 0;
                retorno = problemaDA.ActualizarProblema(_id_problema, _descripcion, _id_tipo_problema, _id_tarea);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }
    }
}
