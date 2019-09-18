using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Modelos
{
    public class Empresa
    {
        private string _rut_empresa;
        private string _nombre;
        private string _giro;
        private string _direccion;
        private int _estado;
        private int _id_comuna;

        public string Rut_empresa { get => _rut_empresa; set => _rut_empresa = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Giro { get => _giro; set => _giro = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public int Estado { get => _estado; set => _estado = value; }
        public int Id_comuna { get => _id_comuna; set => _id_comuna = value; }

        public DataSet toDataSet()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = dt.NewRow();
            dt.TableName = "Empresa";
            dt.Columns.Add(new DataColumn("Rut_empresa"));
            dt.Columns.Add(new DataColumn("Nombre"));
            dt.Columns.Add(new DataColumn("Giro"));
            dt.Columns.Add(new DataColumn("Direccion"));
            dt.Columns.Add(new DataColumn("Estado"));
            dt.Columns.Add(new DataColumn("Id_comuna"));
            dr["Rut_empresa"] = Rut_empresa;
            dr["Nombre"] = Nombre;
            dr["Giro"] = Giro;
            dr["Direccion"] = Direccion;
            dr["Estado"] = Estado;
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
                //Giro
                try
                {
                    Giro = dr["Giro"].ToString();
                }
                catch (Exception ex)
                {
                    Giro = string.Empty;
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
