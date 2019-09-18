using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class Comuna
    {
        private int _id_comuna;
        private string _nombre;
        private int _id_provincia;

        public int Id_comuna { get => _id_comuna; set => _id_comuna = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Id_provincia { get => _id_provincia; set => _id_provincia = value; }

        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Comuna";
            dt.Columns.Add(new DataColumn("Id_comuna"));
            dt.Columns.Add(new DataColumn("Nombre"));
            dt.Columns.Add(new DataColumn("Id_provincia"));
            dr["Id_comuna"] = Id_comuna;
            dr["Nombre"] = Nombre;
            dr["Id_provincia"] = Id_provincia;
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
                //Id_comuna
                try
                {
                    Id_comuna = Int32.Parse(dr["Id_comuna"].ToString());
                }
                catch (Exception ex)
                {
                    Id_comuna = 0;
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
            }
        }
    }
}
