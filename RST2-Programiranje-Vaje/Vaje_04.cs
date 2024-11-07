using System;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RST2_Programiranje_Vaje
{
    public enum Vaje_04_Naloge
    {
        Naloga221 = 1,
        Naloga222 = 2,
        Naloga232 = 3,
        Naloga233 = 4
    }

    /// <summary>
    /// Rešitve vaj - 19. oktober 2024
    /// </summary>
    public class Vaje_04
    {
        /// <summary>
        /// Ustvarite razred Avto in mu dodajte nekaj ustreznih lastnosti, 
        /// dve implementirajte v celoti, dve naj bosta samodejno implementirani 
        /// in ena samodejno implementirana, vendar samo za branje.
        /// </summary>
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

        /// <summary>
        /// Lastnostim iz zgornjega razreda vrednosti nastavite v praznem konstruktorju,
        /// nato pa zapišite še metodo, ki uporabnika pozove k vnosu vrednosti za vsako izmed njih.
        /// Za lastnosti, ki sta implementirani v celoti, 
        /// v bloku set preverite, če so vnešene vrednosti ustrezne.
        /// </summary>
        public static void Naloga222()
        {
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

        /// <summary>
        /// Za razred Zapiski iz Naloge221 naredite indekser, 
        /// ki bo vračal objekt Poglavje glede na dani naslov poglavja.
        /// </summary>
        public static void Naloga232()
        {
            Index indeks = new Index()
            {
                Ime = "Leon",
                Priimek = "Priimek",
                VpisnaSt = 35420000
            };
            indeks[Predmet.Programiranje] = 10;
            indeks[Predmet.DiskretnaMatematika] = 10;
            indeks[Predmet.Algoritmi] = 10;

            Console.WriteLine($"Student z vpisno st {indeks.VpisnaSt} ima povprecno oceno {indeks.PovprecnaOcena}");
        }

        /// <summary>
        /// Napišite razred StudentGeneration, ki ima kot lastnosti leto vpisa in študijski program, 
        /// kot indekser pa množico študentov vpisanih v ta program v danem letu. 
        /// Študent naj identificira glede na njihovo vpisno številko, 
        /// shranjeni pa naj bodo kot poseben objekt tipa Student.
        /// </summary>
        public static void Naloga233()
        {
            Student student1 = new Student()
            {
                Id = 1,
                Ime = "Tone",
                Priimek = "Pavček",
                Spol = Gender.Moski
            };

            Student student2 = new Student()
            {
                Id = 2,
                Ime = "Janez",
                Priimek = "Novak",
                Spol = Gender.Moski
            };

            StudentGeneration rstMag = new StudentGeneration()
            {
                LetoVpisa = 2024,
                StudijskiProgram = "RST",
            };

            rstMag[35240001] = student1;
            rstMag[35240002] = student2;

            Console.WriteLine($"Velikost generacije {rstMag.StudijskiProgram} je {rstMag.VelikostGeneracije}");
        }
    }
}
