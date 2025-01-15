namespace RST2_Programiranje_Vaje
{
    public enum Vaje_15_Naloge
    {
        Naloga3 = 1,
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
    }

    public enum TipTekmovanja
    {
        Evropsko = 1,
        Svetovno = 2,
        Drzavno = 3,
    }

    interface IRanking<T>
    {
        SortedSet<T> Razvrstitev();
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
        public (int, int) Rezultat { get; set; }
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
        public int Domaci_ID { get; set; }
        public int Gost_ID { get; set; }
        public int Statistika_ID { get; set; }
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
        public SortedSet<Ekipa> Razvrstitev()
        {
            throw new NotImplementedException();
        }
    }



}
