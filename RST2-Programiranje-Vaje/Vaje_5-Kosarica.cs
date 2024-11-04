using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RST2_Programiranje_Vaje
{
    public class Kosarica
    {
        // Seznam izdelkov
        public List<Izdelek> Izdelki { get; private set; } = new List<Izdelek>();

        public Kosarica()
        {
            Izdelki = new List<Izdelek>();
        }

        public void DodajIzdelek(Izdelek izdelek)
        {
            Izdelki.Add(izdelek);
        }

        public decimal CenaKosarice()
        {
            decimal skupnaCena = 0;

            foreach (var izdelek in Izdelki)
            {
                skupnaCena += izdelek.Cena;
            }

            return skupnaCena;
        }

        public override string ToString()
        {
            string izpisiKosarico = "Nakupovalna košarica:\n";
            foreach (var izdelek in Izdelki)
            {
                izpisiKosarico += izdelek.ToString() + "\n";
            }
            izpisiKosarico += $"Skupna cena: {CenaKosarice():C}";
            return izpisiKosarico;
        }
    }
}
