using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class Provincia
    {
        private int _id_provincia;
        private string _nombre;
        private int _id_region;

        public int Id_provincia { get => _id_provincia; set => _id_provincia = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Id_region { get => _id_region; set => _id_region = value; }

        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Provincia";
            dt.Columns.Add(new DataColumn("Id_provincia"));
            dt.Columns.Add(new DataColumn("Nombre"));
            dt.Columns.Add(new DataColumn("Id_region"));
            dr["Id_provincia"] = Id_provincia;
            dr["Nombre"] = Nombre;
            dr["Id_region"] = Id_region;
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
                //Id_provincia
                try
                {
                    Id_provincia = Int32.Parse(dr["Id_provincia"].ToString());
                }
                catch (Exception ex)
                {
                    Id_provincia = 0;
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
                //Id_region
                try
                {
                    Id_region = Int32.Parse(dr["Id_region"].ToString());
                }
                catch (Exception ex)
                {
                    Id_region = 0;
                    string MensajeError = ex.Message;
                }                
            }
        }
    }
}
