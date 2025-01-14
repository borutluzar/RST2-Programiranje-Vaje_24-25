using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RST2_Programiranje_Vaje
{
    public enum Vaje_14_Naloge
    {
        Naloga731 = 1,
        Naloga732 = 2,
        Naloga741 = 3
    }

    /// <summary>
    /// Rešitve vaj - 9. januar 2025
    /// </summary>
    public class Vaje_14
    {
        /// <summary>
        ///  Pripravite zbirko 1000 seznamov, kjer imate v vsakem od seznamov 10 000
        ///  naključno izbranih celih števil iz intervala od 1 do 100 000. 
        ///  Za vsakega od seznamov poiščite število praštevil, ki jih vsebuje, 
        ///  in izpišite maksimalno število praštevil v seznamih. 
        ///  Primerjajte čas izvajanja z zaporednim in vzporednim izračunom.
        /// </summary>
        public static void Naloga731()
        {
            int numLists = 1000;
            int numElements = 20_000;
            int intervalSize = 100_000;

            List<List<int>> lstAllLists = new List<List<int>>();
            Random rnd = new Random();

            // Pripravimo sezname
            for (int i = 0; i < numLists; i++)
            {
                lstAllLists.Add(new List<int>());
                for (int j = 0; j < numElements; j++)
                {
                    lstAllLists[i].Add(rnd.Next(1, intervalSize + 1));
                }
            }

            // Poiščimo seznam z maksimalnim številom praštevil 
            // Zaporedno
            Stopwatch sw = Stopwatch.StartNew();
            int maxSerial = lstAllLists.Max(x => x.Count(IsPrime));
            Console.WriteLine($"Največje število praštevil v enem seznamu je: {maxSerial}, " +
                $"izračunano zaporedno v {sw.Elapsed.TotalSeconds:0.00} sekundah.");

            // Paralelno - nad seznami samo pokličemo funkcijo AsParallel!
            sw.Restart();
            int maxParallel = lstAllLists.AsParallel().Max(x => x.Count(IsPrime));
            Console.WriteLine($"Največje število praštevil v enem seznamu je: {maxParallel}, " +
                $"izračunano paralelno v {sw.Elapsed.TotalSeconds:0.00} sekundah.");
        }

        /// <summary>
        /// Napišite funkcijo, ki poišče najmanjše število z natanko 200 delitelji. 
        /// Implementirajte jo zaporedno in vzporedno in primerjajte čas izvajanja.
        /// </summary>
        public static void Naloga732()
        {
            int listSize = int.MaxValue; //1_000_000; //10_000_000;
            int numDivs = 200;

            var lstNums = Enumerable.Range(1, listSize);

            // Zaporedno
            Stopwatch sw = Stopwatch.StartNew();
            // First najde prvi element in zaključi funkcijo
            int minSerial = lstNums.First(x => NumDivisors(x) == numDivs);

            /* Ali ekvivalentno:
            int minSerial = 0;
            foreach (int num in lstNums)
            {
                if(NumDivisors(num) == numDivs)
                {
                    minSerial = num;
                    break;
                }
            }
            */
            Console.WriteLine($"Zaporedno: prvo število s {numDivs} delitelji je {minSerial}. Čas: {sw.Elapsed.TotalSeconds:0.00}");

            // Paralelno
            sw.Restart();

            // Uporaba == je bistveno počasnejša od >=, razloga še ne poznam
            // Sta pa v primerih numDivs = 100 in numDivs = 200 rezultata enaka, ampak v splošnem to ne bo nujno res.
            //int minParallel = lstNums.AsParallel().AsOrdered().First(x => NumDivisors(x) == numDivs);
            int minParallel = lstNums.AsParallel().AsOrdered().First(x => NumDivisors(x) >= numDivs);
            Console.WriteLine($"Paralelno: prvo število s {numDivs} delitelji je {minParallel}. " +
                    $"Čas: {sw.Elapsed.TotalSeconds:0.00}");
        }

        /// <summary>
        /// Napišite program, ki za danih pet spletnih strani 
        /// (njihove naslove podajte v eni datoteki) 
        /// prebere izvorno kodo, poišče vse vložene povezave (v atributih href) 
        /// in odpre ter prebere spletne strani na teh povezavah.
        /// Za vsako od prebranih strani preveri, 
        /// če katera od njih vsebuje povezavo nazaj na začetno stran. 
        /// Upoštevajte samo povezave na drugačni domeni. 
        /// Za program smiselno uporabite pristope asinhronega programiranja.
        /// </summary>
        public static void Naloga741()
        {
            // Nismo reševali.
        }

        public static bool IsPrime(int i)
        {
            for (int j = 2; j <= (int)Math.Sqrt(i); j++)
            {
                if (i % j == 0)
                    return false;
            }
            return true;
        }

        public static int NumDivisors(int n)
        {
            int count = 0;
            int sqrt = (int)Math.Sqrt(n);

            for (int i = 1; i <= sqrt; i++)
            {
                if (n % i == 0)
                {
                    count++;
                    if (i != n / i) // Prištejemo še deliteljev par 
                        count++;
                }
            }
            return count;
        }
    }
}
