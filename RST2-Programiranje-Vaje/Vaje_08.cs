namespace RST2_Programiranje_Vaje
{
    public enum Vaje_08_Naloge
    {
        Naloga272 = 1,
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
    }
}
