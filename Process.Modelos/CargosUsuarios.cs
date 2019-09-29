using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class CargosUsuarios
    {
        private string _rut_usuario;
        private int _id_cargo;
        private int _estado;

        public string Rut_usuario { get => _rut_usuario; set => _rut_usuario = value; }
        public int Id_cargo { get => _id_cargo; set => _id_cargo = value; }
        public int Estado { get => _estado; set => _estado = value; }

        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Cargos_Usuarios";
            dt.Columns.Add(new DataColumn("Rut_usuario"));
            dt.Columns.Add(new DataColumn("Id_cargo"));
            dt.Columns.Add(new DataColumn("Estado"));            
            dr["Rut_usuario"] = Rut_usuario;
            dr["Id_cargo"] = Id_cargo;
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
                //Rut_usuario
                try
                {
                    Rut_usuario = dr["Rut_usuario"].ToString();
                }
                catch (Exception ex)
                {
                    Rut_usuario = string.Empty;
                    string MensajeError = ex.Message;
                }
                //Id_cargo
                try
                {
                    Id_cargo = Int32.Parse(dr["Id_cargo"].ToString());
                }
                catch (Exception ex)
                {
                    Id_cargo = 0;
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
