using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class Permisos
    {
        private int _id_acceso;
        private int _id_rol;

        public int Id_acceso { get => _id_acceso; set => _id_acceso = value; }
        public int Id_rol { get => _id_rol; set => _id_rol = value; }

        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Permisos";
            dt.Columns.Add(new DataColumn("Id_acceso"));
            dt.Columns.Add(new DataColumn("Id_rol"));
            dr["Id_acceso"] = Id_acceso;
            dr["Id_rol"] = Id_rol;
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
                    Id_rol = 0;
                    string MensajeError = ex.Message;
                }
                //Id_rol
                try
                {
                    Id_rol = Int32.Parse(dr["Id_rol"].ToString());
                }
                catch (Exception ex)
                {
                    Id_rol = 0;
                    string MensajeError = ex.Message;
                }
            }

        }
    }
}
