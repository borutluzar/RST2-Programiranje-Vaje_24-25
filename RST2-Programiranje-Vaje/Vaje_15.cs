using System.Security.Cryptography.X509Certificates;

namespace RST2_Programiranje_Vaje
{
    public enum Vaje_15_Naloge
    {
        NalogaXY = 1,
    }

    /// <summary>
    /// Rešitve vaj - 15. januar 2025
    /// </summary>
    public class Vaje_15
    {
        /// <summary>
        /// NAVODILA
        /// </summary>
        public static void NalogaXY()
        {

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
