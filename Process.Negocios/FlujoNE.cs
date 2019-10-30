﻿using System;
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

        public int ActualizarFlujo(int _id_flujo, string _modificacion_usuario, int _id_equipo, string _rut_usuario_equipo)
        {

            try
            {
                int retorno = 0;
                retorno = flujoDA.ActualizarFlujo(_id_flujo, _modificacion_usuario, _id_equipo, _rut_usuario_equipo);
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
    }
}
