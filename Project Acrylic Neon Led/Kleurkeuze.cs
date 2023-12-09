using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project_Acrylic_Neon_Led
{
    class Kleurkeuze
    {
        public static string Kleurnaarnummer(string gekozenkleur)
        {
            if (string.Equals(gekozenkleur, "Rood", StringComparison.OrdinalIgnoreCase))
            {
                return "1";
            }
            if (string.Equals(gekozenkleur, "Blauw", StringComparison.OrdinalIgnoreCase))
            {
                return "2";
            }
            if (string.Equals(gekozenkleur, "Groen", StringComparison.OrdinalIgnoreCase))
            {
                return "3";
            }
            if (string.Equals(gekozenkleur, "Paars", StringComparison.OrdinalIgnoreCase))
            {
                return "4";
            }
            if (string.Equals(gekozenkleur, "Cyan", StringComparison.OrdinalIgnoreCase))
            {
                return "5";
            }
            if (string.Equals(gekozenkleur, "Geel", StringComparison.OrdinalIgnoreCase))
            {
                return "6";
            }
            else
            {
                return "7"; 
            }
        }
    }
}
