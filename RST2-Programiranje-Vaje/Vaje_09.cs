using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace RST2_Programiranje_Vaje
{
    public enum Vaje_09_Naloge
    {
        Naloga301 = 1,
        Naloga302 = 2,
        Naloga304 = 3,
        Naloga311 = 4,
        Naloga312 = 5,
    }

    /// <summary>
    /// Rešitve vaj - 21. november 2024
    /// </summary>
    public class Vaje_09
    {
        /// <summary>
        /// V mapi Vaje_08_Tweets imate datoteke s tviti v JSON obliki.
        /// Razširite Nalogo 300 iz 8. vaj tako da: 
        /// (301) najdete vse tvite za dani seznam avtorjev
        /// (302) najdete vse uporabnike, ki so danemu uporabniku kdaj odgovorili
        /// (303) poiščete avtorja, ki ima največ objav
        /// </summary>
        public static List<string> Naloga301()
        {
            string folderPath = $"./Vaje_08_Tweets";
            List<string> lstAuthorsTweets = new List<string>();

            List<string> authorIds = new();

            var prvaDat = Directory.GetFiles(folderPath).First();
            StreamReader sr_first = new StreamReader(prvaDat.ToString());
            var jsonData_first = (Newtonsoft.Json.Linq.JObject?)JsonConvert.DeserializeObject(sr_first.ReadToEnd());

            // Vsi podatki o posameznih tvitih so v tabeli data
            var tweets_first = jsonData_first!["data"];

            IEnumerable<string> avtorji = tweets_first!.Select(x => x["author_id"]!.ToString()).Distinct();
            authorIds.AddRange(avtorji);

            var counter = 0;
            var allFiles = Directory.GetFiles(folderPath).Count();
            foreach (var file in Directory.GetFiles(folderPath))
            {
                counter++;
                Console.WriteLine($"\rObdelujem datoteko št. {counter}/{allFiles}");
                // Izberemo datoteko
                StreamReader sr = new StreamReader($"{file}");
                // Pretvorimo JSON datoteko v objekt
                var jsonData = (Newtonsoft.Json.Linq.JObject?)JsonConvert.DeserializeObject(sr.ReadToEnd());

                // Vsi podatki o posameznih tvitih so v tabeli data
                var tweets = jsonData!["data"];

                // Pridobimo le tiste, katerih avtor je izbran                
                lstAuthorsTweets.AddRange(
                                    tweets!.Where(tweet => authorIds.Contains(tweet["author_id"]!.ToString()))
                                        .Select(tweet => tweet["text"]!.ToString()));
            }
            return authorIds;
        }

        /// <summary>
        /// V mapi Vaje_08_Tweets imate datoteke s tviti v JSON obliki.
        /// Razširite Nalogo 300 iz 8. vaj tako da: 
        /// (301) najdete vse tvite za dani seznam avtorjev
        /// (302) najdete vse uporabnike, ki so danemu uporabniku kdaj odgovorili
        /// (303) poiščete avtorja, ki ima največ objav
        /// </summary>
        public static void Naloga301(List<string> authorIds)
        {
            string folderPath = $"./Vaje_08_Tweets";
            List<string> lstAuthorsTweets = new List<string>();

            var counter = 0;
            var allFiles = Directory.GetFiles(folderPath).Count();
            foreach (var file in Directory.GetFiles(folderPath))
            {
                counter++;
                Console.WriteLine($"\rObdelujem datoteko št. {counter}/{allFiles}");
                // Izberemo datoteko
                StreamReader sr = new StreamReader($"{file}");
                // Pretvorimo JSON datoteko v objekt
                var jsonData = (Newtonsoft.Json.Linq.JObject?)JsonConvert.DeserializeObject(sr.ReadToEnd());

                // Vsi podatki o posameznih tvitih so v tabeli data
                var tweets = jsonData!["data"];

                // Pridobimo le tiste, katerih avtor je izbran                
                lstAuthorsTweets.AddRange(
                                    tweets!.Where(tweet => authorIds.Contains(tweet["author_id"]!.ToString()))
                                        .Select(tweet => tweet["text"]!.ToString()));
            }

            int count = 1;
            foreach (var item in lstAuthorsTweets)
            {
                Console.WriteLine($"{count}.\t{item}");
                count++;
            }
        }

        /// <summary>
        /// V mapi Vaje_08_Tweets imate datoteke s tviti v JSON obliki.
        /// Razširite Nalogo 300 iz 8. vaj tako da: 
        /// (301) najdete vse tvite za dani seznam avtorjev
        /// (302) najdete vse uporabnike, ki so danemu uporabniku kdaj odgovorili
        /// (303) poiščete avtorja, ki ima največ objav
        /// </summary>
        public static List<string> Naloga302()
        {
            string folderPath = $"./Vaje_08_Tweets";
            List<string> lstAuthorsTweets = new List<string>();

            // ID naključnega avtorja, za katerega izpisujemo tvite
            string authorID = "15559155";

            List<string> listRepliers = new List<string>();

            foreach (var file in Directory.GetFiles(folderPath))
            {
                // Izberemo datoteko
                StreamReader sr = new StreamReader($"{file}");
                // Pretvorimo JSON datoteko v objekt
                var jsonData = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(sr.ReadToEnd());

                // Vsi podatki o posameznih tvitih so v tabeli data
                var tweets = jsonData["data"];

                // Pridobimo le tiste, katerih avtor je izbran                
                listRepliers.AddRange(
                                    tweets.Where(tweet => tweet["in_reply_to_user_id"]?.ToString() == authorID)
                                        .Select(tweet => tweet["author_id"].ToString()));
            }

            return listRepliers.Distinct().ToList();
        }

        /// <summary>
        /// Definirajte nov tip delegata, ki se sklicuje na funkcije, 
        /// ki imajo dva vhodna parametra tipov double in int, 
        /// vrnejo pa rezultat tipa double. 
        /// Ustvarite instanco definiranega tipa (delegata) in mu podajte neko vrednost (funkcijo), 
        /// nato pa izvedite klic delegata.
        /// </summary>
        public static void Naloga311()
        {
            Naloga311Delegate mojDelegat = MetodaZa311;
            double rezultat = mojDelegat(2, 3.5);
            Console.WriteLine($"Rezulat je: {rezultat}");
        }

        /// <summary>
        /// Ustvarite funkcijo, ki kot parameter dobi seznam celih števil in dva različna tipa delegatov. 
        /// Določite ji smiselno delovanje in jo izvedite.
        /// </summary>
        public static void Naloga312(List<int> lst,Naloga311Delegate del1, Naloga312KvantificirajSeznam del2)
        {
            List<int> seznamKvadratov = new List<int>();
            foreach (int x in lst)
            {
                seznamKvadratov.Add((int)del1(x, 2));
            }

            int steviloKvadratov = del2(seznamKvadratov);

            Console.WriteLine($"Vseh stevilk v seznamu je {lst.Count}, stevilo kvadratov pa je {steviloKvadratov}");
        }


        public delegate double Naloga311Delegate(int x, double y);

        public delegate int Naloga312KvantificirajSeznam(List<int> lst);

        public static double MetodaZa311(int x, double y)
        {
            double rezultat = Math.Pow(x, y);
            return rezultat;
        }

        public static int Metoda312PrestejKvadrate(List<int> lst)
        {
            int stevec = 0;
            foreach (int x in lst)
            {
                if(Math.Sqrt(x) % 1 <= double.Epsilon)
                {
                    stevec++;
                }
            }
            return stevec;
        }
    }
}
