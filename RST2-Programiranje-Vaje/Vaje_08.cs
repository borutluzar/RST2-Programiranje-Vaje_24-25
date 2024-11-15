namespace RST2_Programiranje_Vaje
{
    public enum Vaje_08_Naloge
    {
        Naloga272 = 1,
        Naloga273 = 2,
    }

    /// <summary>
    /// Rešitve vaj - 15. november 2024
    /// </summary>
    public class Vaje_08
    {
        /// <summary>
        /// NAVODILA
        /// </summary>
        public static void Naloga272()
        {
            string besedilo = "na roblek bom odsel";
            int stevec = besedilo.SteviloSamoglasnikov();
            Console.WriteLine("Besedilo ima " + stevec + " samoglasnikov");
        }

        public static void Naloga273()
        {
            string beseda = "abeceda";
            Console.WriteLine(beseda.ToString());
            Console.WriteLine(RazsiritveneMetode.ToString(beseda));
        }
    }

    public static class RazsiritveneMetode
    {
        public static int SteviloSamoglasnikov(this string besedilo)
        {
            int stevec = 0;
            besedilo = besedilo.ToLower();
            foreach (var c in besedilo)
            {
                switch (c)
                {
                    case 'a' or 'e' or 'i' or 'o' or 'u':
                        stevec++;
                        break;
                }
            }
            return stevec;
        }

        public static string ToString(this string niz)
        {
            return new String(niz.Reverse().ToArray());
        }
    }
}
