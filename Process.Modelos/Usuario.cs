using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class Usuario
    {
        private string _rut_usuario;
        private string _primer_nombre;
        private string _segundo_nombre;
        private string _primer_apellido;
        private string _segundo_apellido;
        private string _direccion;
        private int _telefono_fijo;
        private int _telefono_movil;        
        private int _id_comuna;

        public string Rut_usuario { get => _rut_usuario; set => _rut_usuario = value; }
        public string Primer_nombre { get => _primer_nombre; set => _primer_nombre = value; }
        public string Segundo_nombre { get => _segundo_nombre; set => _segundo_nombre = value; }
        public string Primer_apellido { get => _primer_apellido; set => _primer_apellido = value; }
        public string Segundo_apellido { get => _segundo_apellido; set => _segundo_apellido = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }        
        public int Telefono_fijo { get => _telefono_fijo; set => _telefono_fijo = value; }
        public int Telefono_movil { get => _telefono_movil; set => _telefono_movil = value; }       
        public int Id_comuna { get => _id_comuna; set => _id_comuna = value; }

        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Usuario";
            dt.Columns.Add(new DataColumn("Rut_usuario"));
            dt.Columns.Add(new DataColumn("Primer_nombre"));
            dt.Columns.Add(new DataColumn("Segundo_nombre"));
            dt.Columns.Add(new DataColumn("Primer_apellido"));
            dt.Columns.Add(new DataColumn("Segundo_apellido"));
            dt.Columns.Add(new DataColumn("Direccion"));            
            dt.Columns.Add(new DataColumn("Telefono_fijo"));
            dt.Columns.Add(new DataColumn("Telefono_movil"));            
            dt.Columns.Add(new DataColumn("Id_comuna"));
            dr["Rut_usuario"] = Rut_usuario;
            dr["Primer_nombre"] = Primer_nombre;
            dr["Segundo_nombre"] = Segundo_nombre;
            dr["Primer_apellido"] = Primer_apellido;
            dr["Segundo_apellido"] = Segundo_apellido;
            dr["Direccion"] = Direccion;            
            dr["Telefono_fijo"] = Telefono_fijo;
            dr["Telefono_movil"] = Telefono_movil;            
            dr["Id_comuna"] = Id_comuna;
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
                //Primer_nombre
                try
                {
                    Primer_nombre = dr["Primer_nombre"].ToString();
                }
                catch (Exception ex)
                {
                    Primer_nombre = string.Empty;
                    string MensajeError = ex.Message;
                }
                //Segundo_nombre
                try
                {
                    Segundo_nombre = dr["Segundo_nombre"].ToString();
                }
                catch (Exception ex)
                {
                    Segundo_nombre = string.Empty;
                    string MensajeError = ex.Message;
                }
                //Primer_apellido
                try
                {
                    Primer_apellido = dr["Primer_apellido"].ToString();
                }
                catch (Exception ex)
                {
                    Primer_apellido = string.Empty;
                    string MensajeError = ex.Message;
                }
                //Segundo_apellido
                try
                {
                    Segundo_apellido = dr["Segundo_apellido"].ToString();
                }
                catch (Exception ex)
                {
                    Segundo_apellido = string.Empty;
                    string MensajeError = ex.Message;
                }
                //Direccion
                try
                {
                    Direccion = dr["Direccion"].ToString();
                }
                catch (Exception ex)
                {
                    Direccion = string.Empty;
                    string MensajeError = ex.Message;
                }               
                //Telefono_fijo
                try
                {
                    Telefono_fijo = Int32.Parse(dr["Telefono_fijo"].ToString());
                }
                catch (Exception ex)
                {
                    Telefono_fijo = 0;
                    string MensajeError = ex.Message;
                }
                //Telefono_movil
                try
                {
                    Telefono_movil = Int32.Parse(dr["Telefono_movil"].ToString());
                }
                catch (Exception ex)
                {
                    Telefono_movil = 0;
                    string MensajeError = ex.Message;
                }                     
                //Id_comuna
                try
                {
                    Id_comuna = Int32.Parse(dr["Id_comuna"].ToString());
                }
                catch (Exception ex)
                {
                    Id_comuna = 0;
                    string MensajeError = ex.Message;
                }
            }
        }
    }
}
