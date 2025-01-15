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
        public int ID { get; set; }
        public int Domaci_ID { get; set; }
        public int Gost_ID { get; set; }
        public (int, int) Rezultat { get; set; }
        public abstract string Izid();
    }

    public class Stat_Nogomet : Statistika
    {
        public int Kartoni;
        public override string Izid()
        {
            return "";
        }

    }
    public class Stat_Hokej : Statistika
    {
        public int Izkljucitve;

        public override string Izid()
        {
            return "";
        }

    }
    public class Ekipa
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public List<string> Igralci { get; set; }
        public string Mesto { get; set; }
    }

    public class Tekma
    {
        public int ID { get; set; }
        public int Domaci_ID { get; set; }
        public int Gost_ID { get; set; }
        public int Statistika_ID { get; set; }
        public List<string> Sodniki { get; set; }
    }
    public class Tekomvanje : IRanking<Ekipa>
    {
        public int ID { get; set; }
        public TipTekmovanja TipTekmovanja { get; set; }
        public List<Ekipa> Ekipe { get; set; }
        public List<Tekma> Tekme { get; set; }
        public SortedSet<Ekipa> Razvrstitev()
        {
            throw new NotImplementedException();
        }
    }

}
