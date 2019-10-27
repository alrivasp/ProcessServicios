using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class EstadoTarea
    {
        private int _id_estado_tarea;
        private string _nombre;

        public int Id_estado_tarea { get => _id_estado_tarea; set => _id_estado_tarea = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }

        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Estado_Tarea";
            dt.Columns.Add(new DataColumn("Id_estado_tarea"));
            dt.Columns.Add(new DataColumn("Nombre"));
            dr["Id_estado_tarea"] = Id_estado_tarea;
            dr["Nombre"] = Nombre;
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
                //Id_estado_tarea
                try
                {
                    Id_estado_tarea = Int32.Parse(dr["Id_estado_tarea"].ToString());
                }
                catch (Exception ex)
                {
                    Id_estado_tarea = 0;
                    string MensajeError = ex.Message;
                }
                //Nombre
                try
                {
                    Nombre = dr["Nombre"].ToString();
                }
                catch (Exception ex)
                {
                    Nombre = string.Empty;
                    string MensajeError = ex.Message;
                }

            }
        }

    }
}
