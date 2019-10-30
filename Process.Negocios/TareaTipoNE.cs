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
    public class TareaTipoNE
    {
        private TareaTipoDA tareaTipoDA = new TareaTipoDA();
        public int InsertarTareaTipo(string _nombre, string _descripcion, int _cantidad_dias, int _id_flujo_tipo)
        {

            try
            {
                int retorno = 0;
                retorno = tareaTipoDA.InsertarTareaTipo(_nombre, _descripcion, _cantidad_dias, _id_flujo_tipo);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarTareaTipo(int _id_tarea_tipo, string _nombre, string _descripcion, int _cantidad_dias, int _id_flujo_tipo)
        {

            try
            {
                int retorno = 0;
                retorno = tareaTipoDA.ActualizarTareaTipo(_id_tarea_tipo, _nombre, _descripcion, _cantidad_dias, _id_flujo_tipo);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }
    }
}
