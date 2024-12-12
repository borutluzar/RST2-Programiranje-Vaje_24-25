namespace RST2_Programiranje_Vaje
{
    public enum Vaje_12_Naloge
    {
        Naloga621 = 1,
        Naloga623 = 2,
    }

    /// <summary>
    /// Rešitve vaj - 12. december 2024
    /// </summary>
    public class Vaje_12
    {
        /// <summary>
        /// NAVODILA
        /// </summary>
        public static void Naloga621()
        {
            Queue<string> q = new Queue<string>();
            q.Add("PRVI EL VRSTE");
            q.Add("DRUGI EL VRSTE");
            q.Add("TRETJI EL VRSTE");

            foreach (var elt in q)
            {
                Console.WriteLine(elt);
            }
            //stack
            Stack<string> s = new Stack<string>();
            s.Add("PRVI EL SKLAD");
            s.Add("DRUGI EL SKLAD");
            s.Add("TRETJI EL SKLAD");

            foreach (var elt in s)
            {
                Console.WriteLine(elt);
            }
        }

        public static void Naloga623()
        {
            Dictionary<string, string> poste = new Dictionary<string, string>();
            StreamReader sw = new StreamReader(@"Vaje_12_Podatki/postnestevilke.txt");

            while (!sw.EndOfStream)
            {
                string stevilkaIme = sw.ReadLine();

                int index = stevilkaIme.IndexOf(' ');

                string postnaStevilka = stevilkaIme.Substring(0, index);

                string imePoste = stevilkaIme.Substring(index);

                poste.Add(postnaStevilka, imePoste);
            }

            sw.Close();

            Random rnd = new Random();
            int izbira = rnd.Next(0, poste.Count);
            string izbranaPostnaStevilka = poste.Keys.ToList()[izbira];
            Console.WriteLine($"Katera posta ima postno stevilko {izbranaPostnaStevilka} ");

            string odgovor = Console.ReadLine();

            if (odgovor.ToLower() == poste[izbranaPostnaStevilka].ToLower())
            {
                Console.WriteLine("Odgovor je pravilen");
            }
            else
            {
                Console.WriteLine("Odgovor je napačen! Pravilen odgovor je: " + poste[izbranaPostnaStevilka]);
            }
        }
    }

    public static class Extensions
    {
        public static void Add<T>(this Queue<T> q, T elt)
        {
            q.Enqueue(elt);
        }

        public static void Add<T>(this Stack<T> s, T elt)
        {
            s.Push(elt);
        }
    }
}
