using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class Acceso
    {
        private int _id_acceso;
        private string _nombre;

        public int Id_acceso { get => _id_acceso; set => _id_acceso = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }

        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Acceso";
            dt.Columns.Add(new DataColumn("Id_acceso"));
            dt.Columns.Add(new DataColumn("Nombre"));
            dr["Id_acceso"] = Id_acceso;
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
                //Id_acceso
                try
                {
                    Id_acceso = Int32.Parse(dr["Id_acceso"].ToString());
                }
                catch (Exception ex)
                {
                    Id_acceso = 0;
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
