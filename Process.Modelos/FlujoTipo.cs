using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class FlujoTipo
    {
        private int _id_flujo_tipo;
        private string _nombre;
        private string _descripcion;
        private int _estado;
        private DateTime fecha_hora;
        private string _usuario;

        public int Id_flujo_tipo { get => _id_flujo_tipo; set => _id_flujo_tipo = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public int Estado { get => _estado; set => _estado = value; }
        public DateTime Fecha_hora { get => fecha_hora; set => fecha_hora = value; }
        public string Usuario { get => _usuario; set => _usuario = value; }


        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Flujo_Tipo";
            dt.Columns.Add(new DataColumn("Id_flujo_tipo"));
            dt.Columns.Add(new DataColumn("Nombre"));
            dt.Columns.Add(new DataColumn("Descripcion"));
            dt.Columns.Add(new DataColumn("Estado"));
            dt.Columns.Add(new DataColumn("Fecha_hora"));
            dt.Columns.Add(new DataColumn("Usuario"));            
            dr["Id_flujo_tipo"] = Id_flujo_tipo;
            dr["Nombre"] = Nombre;
            dr["Descripcion"] = Descripcion;
            dr["Estado"] = Estado;
            dr["Fecha_hora"] = Fecha_hora;
            dr["Usuario"] = Usuario;            
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
                //Flujo_Tipo
                try
                {
                    Id_flujo_tipo = Int32.Parse(dr["Id_flujo_tipo"].ToString());
                }
                catch (Exception ex)
                {
                    Id_flujo_tipo = 0;
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
                //Fecha_hora
                try
                {
                    Fecha_hora = DateTime.Parse(dr["Fecha_hora"].ToString());
                }
                catch (Exception ex)
                {
                    Fecha_hora = DateTime.Now;
                    string MensajeError = ex.Message;
                }
                //Usuario
                try
                {
                    Usuario = dr["Usuario"].ToString();
                }
                catch (Exception ex)
                {
                    Usuario = string.Empty;
                    string MensajeError = ex.Message;
                }
            }
        }

    }
}
