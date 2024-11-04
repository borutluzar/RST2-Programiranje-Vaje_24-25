using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RST2_Programiranje_Vaje
{
    public class Sadje : Izdelek
    {
        public DateTime? DatumUporabe { get; set; }

        public Sadje() : base()
        {
            DatumUporabe = null;
        }

        public Sadje(string naziv, string proizvajalec, decimal cena, DateTime? datumUporabe = null)
            : base(naziv, proizvajalec, cena)
        {
            DatumUporabe = datumUporabe;
        }


        // Izpišemo - overirde ToString()
        public override string ToString()
        {
            string datum = DatumUporabe.HasValue ? DatumUporabe.Value.ToShortDateString() : "Ni podatka";
            return $"{Naziv} (Sadje) - Proizvajalec: {Proizvajalec}, Cena: {Cena:C}, Rok uporabe: {datum}";
        }

    }
}
