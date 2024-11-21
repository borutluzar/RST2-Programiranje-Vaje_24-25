using Newtonsoft.Json;

namespace RST2_Programiranje_Vaje
{
    public enum Vaje_09_Naloge
    {
        Naloga301 = 1,
        Naloga302 = 2,
        Naloga303 = 3,
        Naloga304 = 4,
        Naloga311 = 5,
    }

    /// <summary>
    /// Rešitve vaj - 21. november 2024
    /// </summary>
    public class Vaje_09
    {
        /// <summary>
        /// NAVODILA
        /// </summary>
        public static void NalogaXY()
        {

        }

        /// <summary>
        /// V mapi Vaje_08_Tweets imate datoteke s tviti v JSON obliki.
        /// Razširite Nalogo 300 iz 8. vaj tako da: 
        /// (302) najdete vse tvite za dani seznam avtorjev
        /// (303) najdete vse uporabnike, ki so danemu uporabniku kdaj odgovorili
        /// (304) poiščete avtorja, ki ima največ objav
        /// </summary>
        public static void Naloga301()
        {
            string folderPath = $"./Vaje_08_Tweets";
            List<string> lstAuthorsTweets = new List<string>();

            // ID naključnega avtorja, za katerega izpisujemo tvite
            string authorID = "14344226";

            foreach (var file in Directory.GetFiles(folderPath))
            {
                // Izberemo datoteko
                StreamReader sr = new StreamReader($"{file}");
                // Pretvorimo JSON datoteko v objekt
                var jsonData = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(sr.ReadToEnd());

                // Vsi podatki o posameznih tvitih so v tabeli data
                var tweets = jsonData["data"];

                // Pridobimo le tiste, katerih avtor je izbran                
                lstAuthorsTweets.AddRange(
                                    tweets.Where(tweet => tweet["author_id"].ToString() == authorID)
                                        .Select(tweet => tweet["text"].ToString()));
            }

            Console.WriteLine($"Tviti avtorja {authorID} so:");
            int count = 1;
            foreach (var item in lstAuthorsTweets)
            {
                Console.WriteLine($"{count}.\t{item}");
                count++;
            }
        }

        public static void Naloga302()
        {
            string folderPath = $"./Vaje_08_Tweets";
            List<string> lstAuthorsTweets = new List<string>();

            // ID naključnega avtorja, za katerega izpisujemo tvite
            string authorID = "14344226";
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

            Console.WriteLine($"Tviti avtorja {authorID} so:");
            int count = 1;
            foreach (var item in lstAuthorsTweets)
            {
                Console.WriteLine($"{count}.\t{item}");
                count++;
            }
        }

        public static void Naloga302(List<string> authorIds)
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

        public static List<string> Naloga303()
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

        public static void Naloga311()
        {
            Naloga311Delegate mojDelegat = MetodaZa311;
            double rezultat = mojDelegat(2, 3.5);
            Console.WriteLine($"Rezulat je: {rezultat}");
        }

        public delegate double Naloga311Delegate(int x, double y);

        public static double MetodaZa311(int x, double y)
        {
            double rezultat = Math.Pow(x, y);
            return rezultat;
        }
    }
}
