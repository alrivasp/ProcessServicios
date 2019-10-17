using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Process.Modelos
{
    public class Global
    {
        public static OracleConnection CadenaConexionGlobal;
        public String HASH = "Process2019";//mensaje hash de contraseña

        public string Encriptar(string Password)
        {
            System.Security.Cryptography.SHA512Managed HashTool = new System.Security.Cryptography.SHA512Managed();
            Byte[] PasswordAsByte = System.Text.Encoding.UTF8.GetBytes(string.Concat(Password, HASH));
            Byte[] EncryptedBytes = HashTool.ComputeHash(PasswordAsByte);
            HashTool.Clear();
            return Convert.ToBase64String(EncryptedBytes);
        }
    }
}
