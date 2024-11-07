using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RST2_Programiranje_Vaje
{
    public class Izdelek
    {

        public string Naziv { get; set; }
        public string Proizvajalec { get; set; }
        public decimal Cena { get; set; }

        public Izdelek(string naziv, string proizvajalec, decimal cena)
        {
            Proizvajalec = proizvajalec;
            Naziv = naziv;
            Cena = cena;
        }

        public Izdelek()
        {
            Proizvajalec = "";
            Naziv = "";
            Cena = 0;
        }

        public override string ToString()
        {
            return $"{Naziv} ({Proizvajalec}) - Cena: {Cena} €";
        }
    }  
}
