using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class Cuenta
    {
        private string _rut_usuario;
        private string _rut_empresa;
        private string _contrasena;
        private int _estado;
        private int _id_rol;
        private string _correo;

        public string Rut_usuario { get => _rut_usuario; set => _rut_usuario = value; }
        public string Rut_empresa { get => _rut_empresa; set => _rut_empresa = value; }
        public string Contrasena { get => _contrasena; set => _contrasena = value; }
        public int Estado { get => _estado; set => _estado = value; }
        public int Id_rol { get => _id_rol; set => _id_rol = value; }
        public string Correo { get => _correo; set => _correo = value; }

        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Cuenta";
            dt.Columns.Add(new DataColumn("Rut_usuario"));
            dt.Columns.Add(new DataColumn("Rut_empresa"));
            dt.Columns.Add(new DataColumn("Contrasena"));
            dt.Columns.Add(new DataColumn("Estado"));
            dt.Columns.Add(new DataColumn("Id_rol"));
            dt.Columns.Add(new DataColumn("Correo"));
            dr["Rut_usuario"] = Rut_usuario;
            dr["Rut_empresa"] = Rut_empresa;
            dr["Contrasena"] = Contrasena;
            dr["Estado"] = Estado;
            dr["Id_rol"] = Id_rol;
            dr["Correo"] = Correo;
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
                //Contrasena
                try
                {
                    Contrasena = dr["Contrasena"].ToString();
                }
                catch (Exception ex)
                {
                    Contrasena = string.Empty;
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
                //Correo
                try
                {
                    Correo = dr["Correo"].ToString();
                }
                catch (Exception ex)
                {
                    Correo = string.Empty;
                    string MensajeError = ex.Message;
                }
            }
        }
    }
}
