using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            else if (string.Equals(gekozenkleur, "Blauw", StringComparison.OrdinalIgnoreCase))
            {
                return "2";
            }
            else if (string.Equals(gekozenkleur, "Groen", StringComparison.OrdinalIgnoreCase))
            {
                return "3";
            }
            else
            {
                return "Ongeldige kleur";
            }
        }
    }
}
