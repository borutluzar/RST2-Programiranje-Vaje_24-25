using Newtonsoft.Json;
using System.Collections.Generic;

namespace RST2_Programiranje_Vaje
{
    public enum Vaje_08_Naloge
    {
        Naloga272 = 1,
        Naloga273 = 2,
        Naloga274 = 3,
        Naloga300 = 4,
    }

    /// <summary>
    /// Rešitve vaj - 15. november 2024
    /// </summary>
    public class Vaje_08
    {
        /// <summary>
        /// Zapišite razširitveno metodo, ki prešteje število samoglasnikov v danem nizu.
        /// </summary>
        public static void Naloga272()
        {
            string besedilo = "na roblek bom odsel";
            int stevec = besedilo.SteviloSamoglasnikov();
            Console.WriteLine($"Besedilo \"{besedilo}\" ima {stevec} samoglasnikov");
        }

        /// <summary>
        /// Zapišite razširitveno metodo z imenom ToString, 
        /// ki vrača natanko obrnjen niz kot navadna metoda ToString. 
        /// Obe metodi tudi pokličite in preverite pravilnost izpisa.        
        /// </summary>
        public static void Naloga273()
        {
            string beseda = "abeceda";
            Console.WriteLine(beseda.ToString());
            Console.WriteLine(RazsiritveneMetode.ToString(beseda));
        }

        /// <summary>
        /// Zapišite metodo za objekt, ki je definiran v razredu, do katerega nimate dostopa. 
        /// Objekt predstavlja poročilo o poslovnem obisku, kar želimo, pa je enotna metoda, 
        /// ki iz poročila samodejno izračuna dnevnice.
        /// </summary>
        public static void Naloga274()
        {
            Porocilo porocilo = new Porocilo() { Potrjevalec = "Enej", StDni = 3, Tujina = false };
            Console.WriteLine(porocilo.IzracunDnevnic(25));
        }

        /// <summary>
        /// V mapi Vaje_08_Tweets imate datoteke s tviti v JSON obliki.
        /// Pripravite funkcijo, ki prebere vse tvite avtorja z danim ID-jem.
        /// </summary>
        public static void Naloga330()
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

        public static double IzracunDnevnic(this Porocilo porocilo, double visinaDnevnice)
        {
            return visinaDnevnice * porocilo.StDni;
        }
    }

    public class Porocilo
    {        
        public int StDni { get; set; }
        public Boolean Tujina { get; set; }
        public string Potrjevalec { get; set; }
    }
}
