using Newtonsoft.Json;

namespace RST2_Programiranje_Vaje
{
    public enum Vaje_09_Naloge
    {
        Naloga301 = 1,        
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
        /// (a) najdete vse tvite za dani seznam avtorjev
        /// (b) najdete vse uporabnike, ki so danemu uporabniku kdaj odgovorili
        /// (c) poiščete avtorja, ki ima največ objav
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
    }    
}
