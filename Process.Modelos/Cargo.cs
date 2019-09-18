using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class Cargo
    {
        private int _id_cargo;
        private string _nombre;
        private string _descripcion;        
        private string _rut_empresa;

        public int Id_cargo { get => _id_cargo; set => _id_cargo = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Rut_empresa { get => _rut_empresa; set => _rut_empresa = value; }

        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Cargo";
            dt.Columns.Add(new DataColumn("Id_cargo"));
            dt.Columns.Add(new DataColumn("Nombre"));
            dt.Columns.Add(new DataColumn("Descripcion"));            
            dt.Columns.Add(new DataColumn("Rut_empresa"));
            dr["Id_cargo"] = Id_cargo;
            dr["Nombre"] = Nombre;
            dr["Descripcion"] = Descripcion;           
            dr["Rut_empresa"] = Rut_empresa;
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
                //Rut_empresa
                try
                {
                    Rut_empresa = dr["Rut_empresa"].ToString();
                }
                catch (Exception ex)
                {
                    Rut_empresa = string.Empty;
                    string MensajeError = ex.Message;
                }

            }
        }
    }
}
