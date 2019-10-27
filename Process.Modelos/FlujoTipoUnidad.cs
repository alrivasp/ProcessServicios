using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class FlujoTipoUnidad
    {
        private int id_unidad;
        private int id_flujo_tipo;
        private int estado;

        public int Id_unidad { get => id_unidad; set => id_unidad = value; }
        public int Id_flujo_tipo { get => id_flujo_tipo; set => id_flujo_tipo = value; }
        public int Estado { get => estado; set => estado = value; }


        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Flujo_Tipo_Unidad";
            dt.Columns.Add(new DataColumn("Id_unidad"));
            dt.Columns.Add(new DataColumn("Id_flujo_tipo"));
            dt.Columns.Add(new DataColumn("Estado"));
            dr["Id_unidad"] = Id_unidad;
            dr["Id_flujo_tipo"] = Id_flujo_tipo;
            dr["Estado"] = Estado;
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);
            return ds;
        }

        public void FillFromDataSet(DataSet ds)
        {
            DataRow dr;
            if (ds != null && ds.Tables.Count == 1 && (ds.Tables[0].Rows.Count >= 0))
            {
                dr = ds.Tables[0].Rows[0];
                //Id_unidad
                try
                {
                    Id_unidad = Int32.Parse(dr["Id_unidad"].ToString());
                }
                catch (Exception ex)
                {
                    Id_unidad = 0;
                    string MensajeError = ex.Message;
                }
                //Id_flujo_tipo
                try
                {
                    Id_unidad = Int32.Parse(dr["Id_flujo_tipo"].ToString());
                }
                catch (Exception ex)
                {
                    Id_flujo_tipo = 0;
                    string MensajeError = ex.Message;
                }
                //Id_flujo_tipo
                try
                {
                    Estado = Int32.Parse(dr["Estado"].ToString());
                }
                catch (Exception ex)
                {
                    Estado = 0;
                    string MensajeError = ex.Message;
                }
            }
        }

    }
}
