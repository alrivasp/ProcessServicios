using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class UsuarioEquipo
    {
        private int _rut_usuario;
        private int _id_equipo;
        private int _responsable;

        public int Rut_usuario { get => _rut_usuario; set => _rut_usuario = value; }
        public int Id_equipo { get => _id_equipo; set => _id_equipo = value; }
        public int Responsable { get => _responsable; set => _responsable = value; }

        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Equipo";
            dt.Columns.Add(new DataColumn("Rut_usuario"));
            dt.Columns.Add(new DataColumn("Id_equipo"));
            dt.Columns.Add(new DataColumn("Id_unidad"));

            dr["Rut_usuario"] = Rut_usuario;
            dr["Id_equipo"] = Id_equipo;
            dr["Responsable"] = Responsable;
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
                //Rut_usuario
                try
                {
                    Rut_usuario = Int32.Parse(dr["Rut_usuario"].ToString());
                }
                catch (Exception ex)
                {
                    Rut_usuario = 0;
                    string MensajeError = ex.Message;
                }
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
                //Responsable
                try
                {
                    Responsable = Int32.Parse(dr["Responsable"].ToString());
                }
                catch (Exception ex)
                {
                    Responsable = 0;
                    string MensajeError = ex.Message;
                }
            }
        }
    }
}
