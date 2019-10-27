using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class Tarea
    {
        private int _id_tarea;
        private string _nombre;
        private string _descripcion;
        private DateTime _fecha_inicio;
        private DateTime _fecha_termino;
        private DateTime _modificacion_fecha_hora;
        private string _modificacion_usuario_cambio;
        private int _id_flujo;
        private int _id_estado_tarea;
        private string _rut_usuario_asignado;
        private string _rut_usuario_creador;

        public int Id_tarea { get => _id_tarea; set => _id_tarea = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public DateTime Fecha_inicio { get => _fecha_inicio; set => _fecha_inicio = value; }
        public DateTime Fecha_termino { get => _fecha_termino; set => _fecha_termino = value; }
        public DateTime Modificacion_fecha_hora { get => _modificacion_fecha_hora; set => _modificacion_fecha_hora = value; }
        public string Modificacion_usuario_cambio { get => _modificacion_usuario_cambio; set => _modificacion_usuario_cambio = value; }
        public int Id_flujo { get => _id_flujo; set => _id_flujo = value; }
        public int Id_estado_tarea { get => _id_estado_tarea; set => _id_estado_tarea = value; }
        public string Rut_usuario_asignado { get => _rut_usuario_asignado; set => _rut_usuario_asignado = value; }
        public string Rut_usuario_creador { get => _rut_usuario_creador; set => _rut_usuario_creador = value; }

        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Flujo";
            dt.Columns.Add(new DataColumn("Id_tarea"));
            dt.Columns.Add(new DataColumn("Nombre"));
            dt.Columns.Add(new DataColumn("Descripcion"));
            dt.Columns.Add(new DataColumn("Fecha_inicio"));
            dt.Columns.Add(new DataColumn("Fecha_termino"));
            dt.Columns.Add(new DataColumn("Modificacion_fecha_hora"));
            dt.Columns.Add(new DataColumn("Modificacion_usuario_cambio"));
            dt.Columns.Add(new DataColumn("Id_flujo"));
            dt.Columns.Add(new DataColumn("Id_estado_tarea"));
            dt.Columns.Add(new DataColumn("Rut_usuario_asignado"));
            dt.Columns.Add(new DataColumn("Rut_usuario_creador"));
            dr["Id_tarea"] = Id_tarea;
            dr["Nombre"] = Nombre;
            dr["Descripcion"] = Descripcion;
            dr["Fecha_inicio"] = Fecha_inicio;
            dr["Fecha_termino"] = Fecha_termino;
            dr["Modificacion_fecha_hora"] = Modificacion_fecha_hora;
            dr["Modificacion_usuario_cambio"] = Modificacion_usuario_cambio;
            dr["Id_flujo"] = Id_flujo;
            dr["Id_estado_tarea"] = Id_estado_tarea;
            dr["Rut_usuario_asignado"] = Rut_usuario_asignado;
            dr["Rut_usuario_creador"] = Rut_usuario_creador;
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
                //Id_tarea
                try
                {
                    Id_tarea = Int32.Parse(dr["Id_tarea"].ToString());
                }
                catch (Exception ex)
                {
                    Id_tarea = 0;
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
                //Fecha_inicio
                try
                {
                    Fecha_inicio = DateTime.Parse(dr["Fecha_inicio"].ToString());
                }
                catch (Exception ex)
                {
                    Fecha_inicio = DateTime.Now;
                    string MensajeError = ex.Message;
                }
                //Fecha_termino
                try
                {
                    Fecha_termino = DateTime.Parse(dr["Fecha_termino"].ToString());
                }
                catch (Exception ex)
                {
                    Fecha_termino = DateTime.Now;
                    string MensajeError = ex.Message;
                }
                //Modificacion_fecha_hora
                try
                {
                    Modificacion_fecha_hora = DateTime.Parse(dr["Modificacion_fecha_hora"].ToString());
                }
                catch (Exception ex)
                {
                    Modificacion_fecha_hora = DateTime.Now;
                    string MensajeError = ex.Message;
                }
                //Modificacion_usuario_cambio
                try
                {
                    Modificacion_usuario_cambio = dr["Modificacion_usuario_cambio"].ToString();
                }
                catch (Exception ex)
                {
                    Modificacion_usuario_cambio = string.Empty;
                    string MensajeError = ex.Message;
                }
                //Id_flujo
                try
                {
                    Id_flujo = Int32.Parse(dr["Id_flujo"].ToString());
                }
                catch (Exception ex)
                {
                    Id_flujo = 0;
                    string MensajeError = ex.Message;
                }
                //Id_estado_tarea
                try
                {
                    Id_estado_tarea = Int32.Parse(dr["Id_estado_tarea"].ToString());
                }
                catch (Exception ex)
                {
                    Id_estado_tarea = 0;
                    string MensajeError = ex.Message;
                }
                //Rut_usuario_asignado
                try
                {
                    Rut_usuario_asignado = dr["Rut_usuario_asignado"].ToString();
                }
                catch (Exception ex)
                {
                    Rut_usuario_asignado = string.Empty;
                    string MensajeError = ex.Message;
                }
                //Rut_usuario_creador
                try
                {
                    Rut_usuario_creador = dr["Rut_usuario_creador"].ToString();
                }
                catch (Exception ex)
                {
                    Rut_usuario_creador = string.Empty;
                    string MensajeError = ex.Message;
                }
            }
        }
    }
}
