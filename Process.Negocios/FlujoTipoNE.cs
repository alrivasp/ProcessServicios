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
    public class FlujoTipoNE
    {
        private FlujoTipoDA flujoTipoDA = new FlujoTipoDA();

        public int InsertarFlujoTipo(string _json)
        {

            try
            {
                int retorno = 0;
                retorno = flujoTipoDA.InsertarFlujoTipo(_json);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }

        public int ActualizarFlujoTipo(string _json)
        {

            try
            {
                int retorno = 0;
                retorno = flujoTipoDA.ActualizarFlujoTipo(_json);
                return retorno;

            }
            catch (Exception)
            {
                return -1;

            }

        }


        public DataSet TraerTodosFlujosTipo(string _rut_empresa)
        {
            try
            {
                DataSet retorno = new DataSet();
                retorno = flujoTipoDA.TraerTodosFlujosTipo(_rut_empresa);
                return retorno;

            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
