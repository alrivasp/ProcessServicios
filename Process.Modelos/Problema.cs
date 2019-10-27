using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class Problema
    {
        private int _id_problema;
        private string _descripcion;
        private DateTime _fecha_hora;
        private int _id_tipo_problema;
        private int _id_tarea;

        public int Id_problema { get => _id_problema; set => _id_problema = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public DateTime Fecha_hora { get => _fecha_hora; set => _fecha_hora = value; }
        public int Id_tipo_problema { get => _id_tipo_problema; set => _id_tipo_problema = value; }
        public int Id_tarea { get => _id_tarea; set => _id_tarea = value; }


        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Problema";
            dt.Columns.Add(new DataColumn("Id_problema"));
            dt.Columns.Add(new DataColumn("Descripcion"));
            dt.Columns.Add(new DataColumn("Fecha_hora"));
            dt.Columns.Add(new DataColumn("Id_tipo_problema"));
            dt.Columns.Add(new DataColumn("Id_tarea"));
            dr["Id_problema"] = Id_problema;
            dr["Descripcion"] = Descripcion;
            dr["Fecha_hora"] = Fecha_hora;
            dr["Id_tipo_problema"] = Id_tipo_problema;
            dr["Id_tarea"] = Id_tarea;
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
                //Id_problema
                try
                {
                    Id_problema = Int32.Parse(dr["Id_problema"].ToString());
                }
                catch (Exception ex)
                {
                    Id_problema = 0;
                    string MensajeError = ex.Message;
                }
                //Descripcion
                try
                {
                    Descripcion = dr["Descripcion"].ToString();
                }
                catch (Exception ex)
                {
                    Descripcion = string.Empty;
                    string MensajeError = ex.Message;
                }
                //Fecha_hora
                try
                {
                    Fecha_hora = DateTime.Parse(dr["Fecha_hora"].ToString());
                }
                catch (Exception ex)
                {
                    Fecha_hora = DateTime.Now;
                    string MensajeError = ex.Message;
                }
                //Id_tipo_problema
                try
                {
                    Id_tipo_problema = Int32.Parse(dr["Id_tipo_problema"].ToString());
                }
                catch (Exception ex)
                {
                    Id_tipo_problema = 0;
                    string MensajeError = ex.Message;
                }
                //Id_tarea
                try
                {
                    Id_tarea = Int32.Parse(dr["Id_tarea"].ToString());
                }
                catch (Exception ex)
                {
                    Id_tarea = 0;
                    string MensajeError = ex.Message;
                }
            }
        }

    }
}
