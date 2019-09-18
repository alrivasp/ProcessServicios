using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class Region
    {
        private int _id_region;
        private string _nombre;
        private string _numero;

        public int Id_region { get => _id_region; set => _id_region = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Numero { get => _numero; set => _numero = value; }

        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Region";
            dt.Columns.Add(new DataColumn("Id_region"));
            dt.Columns.Add(new DataColumn("Nombre"));
            dt.Columns.Add(new DataColumn("Numero"));      
            dr["Id_region"] = Id_region;
            dr["Nombre"] = Nombre;
            dr["Numero"] = Numero;
            ds.Tables.Add(dt);
            return ds;
        }

        public void FillFromDataSet(DataSet ds)
        {
            DataRow dr;
            if (ds != null && ds.Tables.Count == 1 && (ds.Tables[0].Rows.Count >= 0))
            {
                dr = ds.Tables[0].Rows[0];
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
                //Numero
                try
                {
                    Numero = dr["Numero"].ToString();
                }
                catch (Exception ex)
                {
                    Numero = string.Empty;
                    string MensajeError = ex.Message;
                }               

            }
        }
    }
}
