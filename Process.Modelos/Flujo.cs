using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class Flujo
    {
        private int _id_flujo;
        private DateTime _fecha_implementacion;
        private DateTime _modificacion_fecha_hora;
        private string _modificacion_usuario;
        private int _id_equipo;
        private string _rut_usuario_asignado;
        private string _rut_usuario_creador;

        public int Id_flujo { get => _id_flujo; set => _id_flujo = value; }
        public DateTime Fecha_implementacion { get => _fecha_implementacion; set => _fecha_implementacion = value; }
        public DateTime Modificacion_fecha_hora { get => _modificacion_fecha_hora; set => _modificacion_fecha_hora = value; }
        public string Modificacion_usuario { get => _modificacion_usuario; set => _modificacion_usuario = value; }
        public int Id_equipo { get => _id_equipo; set => _id_equipo = value; }
        public string Rut_usuario_asignado { get => _rut_usuario_asignado; set => _rut_usuario_asignado = value; }
        public string Rut_usuario_creador { get => _rut_usuario_creador; set => _rut_usuario_creador = value; }


        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Flujo";
            dt.Columns.Add(new DataColumn("Id_flujo"));
            dt.Columns.Add(new DataColumn("Fecha_implementacion"));
            dt.Columns.Add(new DataColumn("Modificacion_fecha_hora"));
            dt.Columns.Add(new DataColumn("Modificacion_usuario"));
            dt.Columns.Add(new DataColumn("Id_equipo"));
            dt.Columns.Add(new DataColumn("Rut_usuario_asignado"));
            dt.Columns.Add(new DataColumn("Rut_usuario_creador"));
            dr["Id_flujo"] = Id_flujo;
            dr["Fecha_implementacion"] = Fecha_implementacion;
            dr["Modificacion_fecha_hora"] = Modificacion_fecha_hora;
            dr["Modificacion_usuario"] = Modificacion_usuario;
            dr["Id_equipo"] = Id_equipo;
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
                //Fecha_implementacion
                try
                {
                    Fecha_implementacion = DateTime.Parse(dr["Fecha_implementacion"].ToString());
                }
                catch (Exception ex)
                {
                    Fecha_implementacion = DateTime.Now;
                    string MensajeError = ex.Message;
                }
                //Fecha_implementacion
                try
                {
                    Modificacion_fecha_hora = DateTime.Parse(dr["Modificacion_fecha_hora"].ToString());
                }
                catch (Exception ex)
                {
                    Modificacion_fecha_hora = DateTime.Now;
                    string MensajeError = ex.Message;
                }
                //Fecha_implementacion
                try
                {
                    Modificacion_usuario = dr["Modificacion_usuario"].ToString();
                }
                catch (Exception ex)
                {
                    Modificacion_usuario = string.Empty;
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
