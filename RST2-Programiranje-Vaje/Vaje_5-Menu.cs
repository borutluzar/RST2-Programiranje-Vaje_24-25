namespace RST2_Programiranje_Vaje
{
    public class Jed
    {
        public double Cena { get; set; }
        public string Naziv { get; }

        public Jed(string naziv)
        {
            this.Naziv = naziv;
        }

        public override string ToString()
        {
            return $"{this.Naziv}\t{this.Cena}";
        }
    }

    public class Sladica : Jed
    {
        public int Kalorije { get; set; }

        public Sladica(string naziv) : base(naziv) { }

        public override string ToString()
        {
            return $"{base.ToString()}\t{this.Kalorije} kcal";
        }
    }

    public class Menu
    {
        public DateTime Datum { get; }
        public List<Jed> Jedilnik { get; } = new List<Jed>();

        public Menu(DateTime datum)
        { this.Datum = datum; }

        public override string ToString()
        {
            string izpis = $"{Datum:d. M. yyyy}";

            foreach (Jed j in Jedilnik)
            {
                izpis += "\n" + j.ToString();
            }

            return izpis;
        }

        public double SkupnaCena(bool dajNapitnino, double odstotekNapitnine = 0.1)
        {
            double vsota = 0;
            foreach (Jed j in Jedilnik)
            {
                vsota += j.Cena;
            }

            return dajNapitnino ? vsota * (1 + odstotekNapitnine) : vsota;
        }
    }
}
