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
    public class FlujoNE
    {
        private FlujoDA flujoDA = new FlujoDA();

        public int InsertarFlujo(int _id_equipo, string _rut_usuario_creador, string _nombre)
        {

            try
            {
                int retorno = 0;
                retorno = flujoDA.InsertarFlujo(_id_equipo, _rut_usuario_creador, _nombre);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarFlujo(int _id_flujo, string _modificacion_usuario, int _id_equipo, string _nombre)
        {

            try
            {
                int retorno = 0;
                retorno = flujoDA.ActualizarFlujo(_id_flujo, _modificacion_usuario, _id_equipo, _nombre);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ImplementarFlujo(int _id_flujo, string _modificacion_usuario, int _id_equipo, string _nombre)
        {

            try
            {
                int retorno = 0;
                retorno = flujoDA.ImplementarFlujo(_id_flujo, _modificacion_usuario, _id_equipo, _nombre);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public DataSet TraerTodosFlujo()
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = flujoDA.TraerTodosFlujo();
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerTodosFlujoUsuario(string _rut_usuario, string _rut_empresa)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = flujoDA.TraerTodosFlujoUsuario(_rut_usuario, _rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }

        public DataSet TraerFlujo(int _id_flujo)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = flujoDA.TraerFlujo(_id_flujo);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }


    }
}
