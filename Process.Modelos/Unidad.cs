using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class Unidad
    {
        private int _id_unidad;
        private string _nombre;
        private string _descripcion;
        private int _estado;
        private string _rut_empresa;

        public int Id_unidad { get => _id_unidad; set => _id_unidad = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public int Estado { get => _estado; set => _estado = value; }
        public string Rut_empresa { get => _rut_empresa; set => _rut_empresa = value; }

        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Unidad";
            dt.Columns.Add(new DataColumn("Id_unidad"));
            dt.Columns.Add(new DataColumn("Nombre"));
            dt.Columns.Add(new DataColumn("Descripcion"));
            dt.Columns.Add(new DataColumn("Estado"));
            dt.Columns.Add(new DataColumn("Rut_empresa"));
            dr["Id_unidad"] = Id_unidad;
            dr["Nombre"] = Nombre;
            dr["Descripcion"] = Descripcion;
            dr["Estado"] = Estado;
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
