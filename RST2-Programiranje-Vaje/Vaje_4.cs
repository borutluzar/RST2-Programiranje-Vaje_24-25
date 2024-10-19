using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;

namespace RST2_Programiranje_Vaje
{
    public enum Vaje4
    {
        Naloga221 = 1,
        Naloga222 = 2
    }

    /// <summary>
    /// Rešitve vaj - 19. oktober 2024
    /// </summary>
    public class Vaje_4
    {
        public static void Naloga221()
        {
            Avto mojAvto = new Avto("1234ABC")
            {
                LetnicaIzdelave = 2000,
                MocMotorja = 120,
                StPotnikov = 5,
                StVrat = 5
            };

            Console.WriteLine($"Moj avto ima {mojAvto.Hp} konjskih moči.");
        }

        public static void Naloga222()
        {
            Console.WriteLine($"Naloga 2.2.2");

            // Lastnostim iz zgornjega razreda vrednosti nastavite v praznem konstruktorju,
            // nato pa zapišite še metodo, ki uporabnika pozove k vnosu vrednosti za vsako izmed njih.
            // Za lastnosti, ki sta implementirani v celoti, v bloku set preverite, če so vnesene vrednosti ustrezne.

            Console.WriteLine("Vpišite podatke vašega avtomobila:");

            // Podatek o št. šasije
            Console.WriteLine("Vpišite številko šasije:");
            string stSasije = Console.ReadLine();

            // Naredimo novo instanco in ji priredimo št. šasije
            Avto mojAvto2 = new Avto(stSasije);

            // Podatek o moči motorja
            Console.WriteLine("Vpišite moč motorja v kW:");
            mojAvto2.MocMotorja = int.Parse(Console.ReadLine());

            // Podatek o številu potnikov
            Console.WriteLine("Vpišite število potnikov:");
            mojAvto2.StPotnikov = int.Parse(Console.ReadLine());

            // Podatek o številu vrat
            Console.WriteLine("Vpišite število vrat:");
            mojAvto2.StVrat = int.Parse(Console.ReadLine());

            // Podatek o številu vrat
            Console.WriteLine("Vpišite leto izdelave avtomobila:");
            mojAvto2.LetnicaIzdelave = int.Parse(Console.ReadLine());

            // Izpiši podatke na ekran
            Console.WriteLine($"Hvala za podatke. Konjske moči vašega avtomobila: {mojAvto2.Hp}");
        }
    }
}
