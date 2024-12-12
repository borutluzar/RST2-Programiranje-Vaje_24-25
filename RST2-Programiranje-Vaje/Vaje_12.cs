namespace RST2_Programiranje_Vaje
{
    public enum Vaje_12_Naloge
    {
        Naloga621 = 1,
        Naloga623 = 2,
        Naloga625 = 3,
    }

    /// <summary>
    /// Rešitve vaj - 12. december 2024
    /// </summary>
    public class Vaje_12
    {
        /// <summary>
        /// Vrsta in sklad ne implementirata metode Add.  
        /// Napišite razširitveni metodi zanju.
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

        /// <summary>
        /// V mapi Vaje_12_Podatki imate datoteko s seznamom pošt in poštnih številk. 
        /// Pripravite podobno igro kot v prejšnji nalogi, 
        /// kjer mora uporabnik glede na ime pošte ugotoviti njeno poštno številko.
        /// Katera podatkovna struktura bo najbolj primerna za implementacijo?
        /// </summary>
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

        /// <summary>
        /// V mapi Vaje_12_Podatki imate tri datoteke.  
        /// V datoteki tblAuthors.txt je seznam slovenskih raziskovalcev, 
        /// v datoteki tblPubs.txt je seznam njihovih publikacij, 
        /// v datoteki tblPubsAuthors.txt pa povezava med publikacijami in avtorji. 
        /// Te podatke preberite v ustrezne podatkovne strukture in napišite funkcijo, 
        /// ki bo učinkovito izračunala povprečno število publikacij na avtorja.
        /// </summary>
        public static void Naloga625()
        {
            string authorsFile = "Vaje_12_Podatki/tblAuthors.txt";
            string pubsAuthorsFile = "Vaje_12_Podatki/tblPubsAuthors.txt";

            Dictionary<int, Author> authors = ReadAuthors(authorsFile);

            ReadPubsAuts(pubsAuthorsFile, ref authors);

            double avgResult = GetAverageOfPubs(authors);

            Console.WriteLine($"Average number of publications per author is:\t" + avgResult);
        }

        private static Dictionary<int, Author> ReadAuthors(string filePath)
        {
            var authors = new Dictionary<int, Author>();

            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split('\t');
                if (!authors.ContainsKey(int.Parse(parts[1])))
                {
                    authors.Add(int.Parse(parts[1]), new Author { Name = parts[2] + " " + parts[3] });
                }
            }

            return authors;
        }

        private static void ReadPubsAuts(string filePath, ref Dictionary<int, Author> authors)
        {

            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split('\t');
                int authorID = int.Parse(parts[1]);

                if (authors.ContainsKey(authorID))
                {
                    authors[authorID].Publications.Add(parts[0]);
                }
            }
        }

        private static double GetAverageOfPubs(Dictionary<int, Author> authors)
        {
            return authors.Average(aut => aut.Value.Publications.Count());
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

    public class Author
    {
        public string CobissID { get; set; }
        public string Name { get; set; }
        public List<string> Publications { get; set; } = new();
    }
}
