using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class Equipo
    {
        private int _id_equipo;
        private string _nombre;
        private int _id_unidad;

        public int Id_equipo { get => _id_equipo; set => _id_equipo = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Id_unidad { get => _id_unidad; set => _id_unidad = value; }


        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Equipo";
            dt.Columns.Add(new DataColumn("Id_equipo"));
            dt.Columns.Add(new DataColumn("Nombre"));
            dt.Columns.Add(new DataColumn("Id_unidad"));

            dr["Id_equipo"] = Id_equipo;
            dr["Nombre"] = Nombre;
            dr["Id_unidad"] = Id_unidad;
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
                //Id_equipo
                try
                {
                    Id_equipo = Int32.Parse(dr["Id_equipo"].ToString());
                }
                catch (Exception ex)
                {
                    Id_equipo = 0;
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
                //Id_unidad
                try
                {
                    Id_unidad = Int32.Parse(dr["Id_unidad"].ToString());
                }
                catch (Exception ex)
                {
                    Id_unidad = 0;
                    string MensajeError = ex.Message;
                }               
            }
        }
    }
}
