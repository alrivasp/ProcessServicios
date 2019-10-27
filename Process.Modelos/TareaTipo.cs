using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class TareaTipo
    {
        private int _id_tarea_tipo;
        private string _nombre;
        private string _descripcion;
        private int _cantidad_dias;
        private int _id_flujo_tipo;

        public int Id_tarea_tipo { get => _id_tarea_tipo; set => _id_tarea_tipo = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public int Cantidad_dias { get => _cantidad_dias; set => _cantidad_dias = value; }
        public int Id_flujo_tipo { get => _id_flujo_tipo; set => _id_flujo_tipo = value; }


        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Tarea_Tipo";
            dt.Columns.Add(new DataColumn("Id_tarea_tipo"));
            dt.Columns.Add(new DataColumn("Nombre"));
            dt.Columns.Add(new DataColumn("Descripcion"));
            dt.Columns.Add(new DataColumn("Cantidad_dias"));
            dt.Columns.Add(new DataColumn("Id_flujo_tipo"));
            dr["Id_tarea_tipo"] = Id_tarea_tipo;
            dr["Nombre"] = Nombre;
            dr["Descripcion"] = Descripcion;
            dr["Cantidad_dias"] = Cantidad_dias;
            dr["Id_flujo_tipo"] = Id_flujo_tipo;
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
                //Id_tarea_tipo
                try
                {
                    Id_tarea_tipo = Int32.Parse(dr["Id_tarea_tipo"].ToString());
                }
                catch (Exception ex)
                {
                    Id_tarea_tipo = 0;
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
                //Cantidad_dias
                try
                {
                    Cantidad_dias = Int32.Parse(dr["Cantidad_dias"].ToString());
                }
                catch (Exception ex)
                {
                    Cantidad_dias = 0;
                    string MensajeError = ex.Message;
                }
                //Id_flujo_tipo
                try
                {
                    Id_flujo_tipo = Int32.Parse(dr["Id_flujo_tipo"].ToString());
                }
                catch (Exception ex)
                {
                    Id_flujo_tipo = 0;
                    string MensajeError = ex.Message;
                }
            }
        }

    }
}
