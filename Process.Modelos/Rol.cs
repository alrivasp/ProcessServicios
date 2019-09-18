using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class Rol
    {
        private int _id_rol;
        private string _nombre;
        private int _estado;

        public int Id_rol { get => _id_rol; set => _id_rol = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Estado { get => _estado; set => _estado = value; }

        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Rol";
            dt.Columns.Add(new DataColumn("Id_rol"));
            dt.Columns.Add(new DataColumn("Nombre"));
            dt.Columns.Add(new DataColumn("Estado"));            
            dr["Id_rol"] = Id_rol;
            dr["Nombre"] = Nombre;
            dr["Estado"] = Estado;
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
                //Estado
                try
                {
                    Estado = Int32.Parse(dr["Estado"].ToString());
                }
                catch (Exception ex)
                {
                    Estado = 0;
                    string MensajeError = ex.Message;
                }                
            }
        }
    }
}
