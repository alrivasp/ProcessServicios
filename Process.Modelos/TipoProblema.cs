using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class TipoProblema
    {
        private int _id_tipo_problema;
        private string _descripcion;

        public int Id_tipo_problema { get => _id_tipo_problema; set => _id_tipo_problema = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }


        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Tipo_Problema";
            dt.Columns.Add(new DataColumn("Id_tipo_problema"));
            dt.Columns.Add(new DataColumn("Descripcion"));
            dr["Id_tipo_problema"] = Id_tipo_problema;
            dr["Descripcion"] = Descripcion;
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
            }
        }

    }
}
