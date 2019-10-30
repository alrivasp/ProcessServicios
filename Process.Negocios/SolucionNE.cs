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
    public class SolucionNE
    {
        private SolucionDA solucionDA = new SolucionDA();

        public int InsertarSolucion(string _descripcion, int _id_tipo_solucion, int _id_problema)
        {

            try
            {
                int retorno = 0;
                retorno = solucionDA.InsertarSolucion(_descripcion, _id_tipo_solucion, _id_problema);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarSolucion(int _id_solucion ,string _descripcion, int _id_tipo_solucion, int _id_problema)
        {

            try
            {
                int retorno = 0;
                retorno = solucionDA.ActualizarSolucion(_id_solucion, _descripcion, _id_tipo_solucion, _id_problema);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public DataSet TraerTodosSolucion()
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = solucionDA.TraerTodosSolucion();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
