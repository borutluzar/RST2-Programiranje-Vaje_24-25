using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RST2_Programiranje_Vaje
{
    public class Komisija
    {
        public string PreveriClana(int id)
        {
            return "Član je preverjen kader!";
        }
    }

    public class NadzornaKomisija : Komisija
    {
        new public string PreveriClana(int id)
        {
            return "Član je preverjen po liniji nadzorne komisije!";
        }
    }
}
