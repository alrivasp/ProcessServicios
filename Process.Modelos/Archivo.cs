using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class Archivo
    {
        private int _id_archivo;
        private string _ruta;
        private string _nombre;
        private int _id_historial_tarea;

        public int Id_archivo { get => _id_archivo; set => _id_archivo = value; }
        public string Ruta { get => _ruta; set => _ruta = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Id_historial_tarea { get => _id_historial_tarea; set => _id_historial_tarea = value; }

        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Archivo";
            dt.Columns.Add(new DataColumn("Id_archivo"));
            dt.Columns.Add(new DataColumn("Ruta"));
            dt.Columns.Add(new DataColumn("Nombre"));
            dt.Columns.Add(new DataColumn("Id_historial_tarea"));
            dr["Id_archivo"] = Id_archivo;
            dr["Ruta"] = Ruta;
            dr["Nombre"] = Nombre;
            dr["Id_historial_tarea"] = Id_historial_tarea;
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
                //Id_archivo
                try
                {
                    Id_archivo = Int32.Parse(dr["Id_archivo"].ToString());
                }
                catch (Exception ex)
                {
                    Id_archivo = 0;
                    string MensajeError = ex.Message;
                }
                //Ruta
                try
                {
                    Ruta = dr["Ruta"].ToString();
                }
                catch (Exception ex)
                {
                    Ruta = string.Empty;
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
                //Id_historial_tarea
                try
                {
                    Id_historial_tarea = Int32.Parse(dr["Id_historial_tarea"].ToString());
                }
                catch (Exception ex)
                {
                    Id_historial_tarea = 0;
                    string MensajeError = ex.Message;
                }
            }
        }
    }
}
