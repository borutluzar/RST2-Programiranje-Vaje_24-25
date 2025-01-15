namespace RST2_Programiranje_Vaje
{
    public enum Vaje_15_Naloge
    {
        Naloga3 = 1,
        Naloga5 = 2,
    }

    /// <summary>
    /// Rešitve vaj - 15. januar 2025
    /// </summary>
    public class Vaje_15
    {
        /// <summary>
        /// NAVODILA
        /// </summary>
        public static void Naloga3()
        {
            Tekmovanje tekmovanje = new(1);

            int i = 0;
            while (i < 3)
            {
                Console.WriteLine("Ime ekipe: ");
                string ime = Console.ReadLine();
                Console.WriteLine("Ime mesta");
                string mesto = Console.ReadLine();
                tekmovanje.Ekipe.Add(EkipaFactory.GetEkipa(i, ime, mesto));

                i++;
            }

            tekmovanje.Ekipe.Add(EkipaFactory.GetEkipa(++i, "nevem", "novomesto", new() { "Marko", "Beno" }));
        }

        public static void Naloga5()
        {
            Tekmovanje tekmovanje = new(1);
            var ekipa1 = EkipaFactory.GetEkipa(1, "Ekipa 1", "Novo mesto");
            tekmovanje.Ekipe.Add(ekipa1);
            var ekipa2 = EkipaFactory.GetEkipa(2, "Ekipa 2", "Krško");
            tekmovanje.Ekipe.Add(ekipa2);
            var ekipa3 = EkipaFactory.GetEkipa(3, "Ekipa 3", "Kočevje");
            tekmovanje.Ekipe.Add(ekipa3);

            Statistika st1 = new Stat_Nogomet(1) { Domaci_ID = 1, Gost_ID = 2, Rezultat = (1, 2) };
            tekmovanje.Tekme.Add(new Tekma(1) { Domaci = ekipa1, Gostje = ekipa2, Statistika = st1 });

            Statistika st2 = new Stat_Nogomet(2) { Domaci_ID = 3, Gost_ID = 1, Rezultat = (2, 0) };
            tekmovanje.Tekme.Add(new Tekma(2) { Domaci = ekipa3, Gostje = ekipa1, Statistika = st2 });

            Statistika st3 = new Stat_Nogomet(3) { Domaci_ID = 2, Gost_ID = 3, Rezultat = (2, 1) };
            tekmovanje.Tekme.Add(new Tekma(3) { Domaci = ekipa2, Gostje = ekipa3, Statistika = st3 });

            Console.WriteLine($"Zmagovalec turnirja je {tekmovanje.Razvrstitev().First().Ime}");
        }
    }

    public enum TipTekmovanja
    {
        Evropsko = 1,
        Svetovno = 2,
        Drzavno = 3,
    }

    interface IRanking<T>
    {
        List<T> Razvrstitev();
    }

    public abstract class Statistika
    {
        public Statistika(int id)
        {
            ID = id;
        }
        public int ID { get; }
        public int Domaci_ID { get; set; }
        public int Gost_ID { get; set; }
        public (int RezDomaci, int RezGostje) Rezultat { get; set; }
        public abstract string Izid();
    }

    public class Stat_Nogomet : Statistika
    {
        public Stat_Nogomet(int id) : base(id) { }

        public int Kartoni;
        public override string Izid()
        {
            return "";
        }

    }
    public class Stat_Hokej : Statistika
    {
        public Stat_Hokej(int id) : base(id) { }

        public int Izkljucitve;

        public override string Izid()
        {
            return "";
        }

    }
    public class Ekipa
    {
        public Ekipa(int id)
        {
            ID = id;
            Igralci = new List<string>();
        }
        public int ID { get; }
        public string Ime { get; set; }
        public List<string> Igralci { get; }
        public string Mesto { get; set; }
        public override string ToString()
        {
            return Ime + "-" + Mesto;
        }
    }

    public static class EkipaFactory
    {
        public static Ekipa GetEkipa(int id, string ime, string mesto, List<string> igralci = null)
        {
            Ekipa novaEkipa = new Ekipa(id);
            novaEkipa.Ime = ime;
            novaEkipa.Mesto = mesto;
            if (igralci != null)
            {
                novaEkipa.Igralci.AddRange(igralci);
            }

            return novaEkipa;
        }
    }

    public class Tekma
    {
        public Tekma(int id)
        {
            ID = id;
            Sodniki = new List<string>();
        }
        public int ID { get; }
        public Ekipa Domaci { get; set; }
        public Ekipa Gostje { get; set; }
        public Statistika Statistika { get; set; }
        public List<string> Sodniki { get; }
    }

    public class Tekmovanje : IRanking<Ekipa>
    {
        public Tekmovanje(int id)
        {
            ID = id;
            Ekipe = new List<Ekipa>();
            Tekme = new List<Tekma>();

        }
        public int ID { get; }
        public TipTekmovanja TipTekmovanja { get; set; }
        public List<Ekipa> Ekipe { get; set; }
        public List<Tekma> Tekme { get; set; }
        public List<Ekipa> Razvrstitev()
        {
            Dictionary<Ekipa, int> dicEkipeTocke = new Dictionary<Ekipa, int>();

            foreach (var ekipa in Ekipe)
            {
                dicEkipeTocke.Add(ekipa, 0);
            }

            foreach (var tekma in Tekme)
            {
                // Držimo se pravila:
                // če ima ekipa 1 več točk kot ekipa 2, je zmagovalec ekipa 1
                // 3 točke za zmago, 1 točka za remi
                if (tekma.Statistika.Rezultat.RezDomaci > tekma.Statistika.Rezultat.RezGostje)
                {
                    dicEkipeTocke[tekma.Domaci] += 3;
                }
                else if (tekma.Statistika.Rezultat.RezDomaci < tekma.Statistika.Rezultat.RezGostje)
                {
                    dicEkipeTocke[tekma.Gostje] += 3;
                }
                else
                {
                    dicEkipeTocke[tekma.Domaci] += 1;
                    dicEkipeTocke[tekma.Gostje] += 1;
                }
            }

            return dicEkipeTocke.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();
        }
    }

    public static class Razsiritve
    {
        public static string IzpisiStatistiko(this Ekipa ekipa, Statistika statistika)
        {
            string returnVal = ekipa.ToString();
            if (statistika.Domaci_ID == ekipa.ID)
            {
                returnVal += " : " + statistika.Rezultat.RezDomaci;
            }
            else
            {
                returnVal += " : " + statistika.Rezultat.RezGostje;
            }
            return returnVal;
        }
    }
}
