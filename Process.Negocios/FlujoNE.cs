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

        public int InsertarFlujo( string _modificacion_usuario, int _id_equipo, string _rut_usuario_equipo, string _rut_usuario_creador)
        {

            try
            {
                int retorno = 0;
                retorno = flujoDA.InsertarFlujo( _modificacion_usuario, _id_equipo, _rut_usuario_equipo, _rut_usuario_creador);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }
    }
}
