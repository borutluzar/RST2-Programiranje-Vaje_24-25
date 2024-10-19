using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;

namespace RST2_Programiranje_Vaje
{
    public enum Vaje3
    {
        Naloga182 = 1,
        Naloga211 = 2,
        Naloga212 = 3,
        Naloga213 = 4
    }

    /// <summary>
    /// Rešitve vaj - 9. oktober 2024
    /// </summary>
    public class Vaje_3
    {
        /// <summary>
        /// Zapišite funkcijo, ki za dano število poskusov simulira met igralne kocke (števila med 1 in 6).
        /// Beležite, kolikokrat padejo posamezna števila in ugotovite, 
        /// če se njihova frekvenca s povečevanjem števila poskusov ujema 
        /// oziroma približuje verjetnosti padca posameznega števila.
        /// </summary>
        public static void Naloga182(int stMetov)
        {
            // Objekt za pridobitev naključne vrednosti
            Random rnd = new Random();
            
            // Slovar, v katerega shranjujemo frekvenco padcev posameznih pik
            Dictionary<int, int> dictCount = new Dictionary<int, int>();
            for (int i = 1; i <= 6; i++)
            {
                dictCount.Add(i, 0);
            }

            int stevec = 0;
            while (stevec < stMetov)
            {
                int stPik = rnd.Next(1, 7);
                dictCount[stPik] += 1;
                stevec++;
            }

            // Izpis frekvenc
            foreach (int st in dictCount.Keys)
            {
                Console.WriteLine($"{st}:\t{(double)dictCount[st] / stMetov:0.0000}");
            }
        }


        /// <summary>
        /// Ustvarite razred Zapiski in mu dodajte prazen konstruktor, 
        /// polje seznamPoglavij ter nekaj metod.
        /// Nato ustvarite instanco tega razreda, ji napolnite polje ter pokličite eno od metod.
        /// </summary>
        public static void Naloga211()
        {
            Zapiski zapiski = new Zapiski();

            zapiski.DodajPoglavje("Prvo");
            string smth = "Drugo";
            zapiski.DodajPoglavje(smth);

            Console.WriteLine($"Stevilo je:\t{zapiski.SteviloPoglavij()}");            
        }


        /// <summary>
        /// Razredu naloge 2.1.1 dodajte še tri konstruktorje 
        /// in ustvarite po eno instanco z vsakim izmed njih.
        /// </summary>
        public static void Naloga212()
        {
            // Kreiramo tri instance s tremi različnimi konstruktorji
            Zapiski zapiski1 = new Zapiski();
            Zapiski zapiski2 = new Zapiski(new List<string>() { "Uvod", "Zaključek" });
            Zapiski zapiski3 = new Zapiski("Uvod");

            Console.WriteLine($"1. instanca ima {zapiski1.SteviloPoglavij()} poglavij.");
            Console.WriteLine($"2. instanca ima {zapiski2.SteviloPoglavij()} poglavij.");
            Console.WriteLine($"3. instanca ima {zapiski3.SteviloPoglavij()} poglavij.");
        }


        /// <summary>
        /// Zgornji nalogi dopolnite z razredom Poglavje, 
        /// ki nosi podatke o posameznem poglavju, npr.naslov, seznam razdelkov itd.
        /// </summary>
        public static void Naloga213()
        {
            Poglavje uvod = new Poglavje("Uvod", 1);
            Poglavje zakljucek = new Poglavje("Zaključek", 2);

            Zapiski2 zapiski = new Zapiski2(new List<Poglavje>() { uvod, zakljucek });

            Console.WriteLine($"Instanca {nameof(zapiski)} ima {zapiski.SteviloPoglavij()} poglavij.");
        }
    }
}
