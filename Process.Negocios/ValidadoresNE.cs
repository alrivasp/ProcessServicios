using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Process.Negocios
{
    public class ValidadoresNE
    {
        public bool IsNumeric(string num)
        {
            try
            {
                double x = Convert.ToDouble(num);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }//fin Validar de numero


        //public bool validarRut(string rut)
        //{

        //    bool validacion = false;
        //    try
        //    {
        //        rut = rut.ToUpper();
        //        rut = rut.Replace(".", "");
        //        rut = rut.Replace("-", "");
        //        int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

        //        char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

        //        int m = 0, s = 1;
        //        for (; rutAux != 0; rutAux /= 10)
        //        {
        //            s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
        //        }
        //        if (dv == (char)(s != 0 ? s + 47 : 75))
        //        {
        //            validacion = true;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    return validacion;
        //}//fin Validar rut

        public bool validarRut(string rut)
        {
            rut = rut.Replace(".", "").ToUpper();
            Regex expresion = new Regex("^([0-9]+-[0-9K])$");
            string dv = rut.Substring(rut.Length - 1, 1);
            if (!expresion.IsMatch(rut))
            {
                return false;
            }
            char[] charCorte = { '-' };
            string[] rutTemp = rut.Split(charCorte);
            if (dv != Digito(int.Parse(rutTemp[0])))
            {
                return false;
            }
            return true;
        }

        //public static bool ValidaRut(string rut, string dv)
        //{
        //    return validarRut(rut + "-" + dv);
        //}

        public static string Digito(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
            {
                return "0";
            }
            else if (suma == 10)
            {
                return "K";
            }
            else
            {
                return suma.ToString();
            }
        }
    }
}
