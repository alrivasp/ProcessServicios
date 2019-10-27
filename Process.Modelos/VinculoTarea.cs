using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class VinculoTarea
    {
        private int _id_tarea_hijo;
        private int _id_tarea_padre;
        private int _tipo;

        public int Id_tarea_hijo { get => _id_tarea_hijo; set => _id_tarea_hijo = value; }
        public int Id_tarea_padre { get => _id_tarea_padre; set => _id_tarea_padre = value; }
        public int Tipo { get => _tipo; set => _tipo = value; }


        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Flujo";
            dt.Columns.Add(new DataColumn("Id_tarea_hijo"));
            dt.Columns.Add(new DataColumn("Id_tarea_padre"));
            dt.Columns.Add(new DataColumn("Tipo"));
            dr["Id_tarea_hijo"] = Id_tarea_hijo;
            dr["Id_tarea_padre"] = Id_tarea_padre;
            dr["Tipo"] = Tipo;
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
                //Id_tarea_hijo
                try
                {
                    Id_tarea_hijo = Int32.Parse(dr["Id_tarea_hijo"].ToString());
                }
                catch (Exception ex)
                {
                    Id_tarea_hijo = 0;
                    string MensajeError = ex.Message;
                }
                //Id_tarea_padre
                try
                {
                    Id_tarea_padre = Int32.Parse(dr["Id_tarea_padre"].ToString());
                }
                catch (Exception ex)
                {
                    Id_tarea_padre = 0;
                    string MensajeError = ex.Message;
                }
                //Tipo
                try
                {
                    Tipo = Int32.Parse(dr["Tipo"].ToString());
                }
                catch (Exception ex)
                {
                    Tipo = 0;
                    string MensajeError = ex.Message;
                }
            }
        }
    }
}
