using System;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics.X86;

namespace RST2_Programiranje_Vaje
{
    public enum Vaje_11_Naloge
    {
        Naloga441 = 1,
        Naloga442 = 2,
        Naloga511 = 3,
    }

    /// <summary>
    /// Rešitve vaj - 6. december 2024
    /// </summary>
    public static class Vaje_11
    {
        /// <summary>
        /// Pripravite razredni model, ki bo opisoval atlete. 
        /// Atlet naj bo nadrazred, ki ima nekaj podrazredov 
        /// (npr.metalec, šprinter, skakalec, deseterobojec). 
        /// V glavnem razredu določite nekaj ustreznih funkcionalnosti(tek, met, skok), 
        /// ki jih podrazredom ločeno implementirate glede na njihove specifike. 
        /// Uporabite strateški načrtovalski vzorec.
        /// </summary>
        public static void Naloga441()
        {
            Atlet joze = new SkakalecVDaljino();
            joze.MocOdskoka();
            Atlet luka = new Maratonec();
            luka.MocOdskoka();
            luka.ReakciskiCasZacetka();
        }

        /// <summary>
        /// Pripravite abstrakten razred mobilna naprava, zanjo naredite nekaj podrazredov 	
        /// in implementirajte funkcionalnosti zanje.
        /// Npr.pošiljanje SMS-ov, telefoniranje, sprejemanje signala 4G ali celo 5G.
        /// Naprave naj bodo med seboj karseda različne, 
        /// obenem pa naj model omogoča preprosto dopolnjevanje dodatnih funkcionalnosti 
        /// in dodajanje novih podrazredov. 
        /// Uporabite strateški načrtovalski vzorec.
        /// </summary>
        public static void Naloga442()
        {
            MobilnaNaprava mojMobi = new PametniTelefon("Samsung");
            mojMobi.SprejmiKlic();
        }

        /// <summary>
        /// Pripravite generično metodo, ki za dan seznam števil tipa T 
        /// izračuna vsoto največjih k števil, 
        /// pri čemer je k tudi parameter metode. 
        /// V metodi uporabite le LINQ metode. 
        /// [Pri metodi Sum smo imeli težave, zato smo uporabili foreach zanko.]
        /// </summary>
        public static void Naloga511()
        {
            List<int> intList = [1, 2, 3, 4, 5, 6, 7, 8, 9];
            List<double> doubleList = [1.2, 2.1, 3, 4, 5, 6, 7.8, 8, 9];

            Console.WriteLine(intList.SumOfLargestKNumbers<int>(5));
            Console.WriteLine(doubleList.SumOfLargestKNumbers<double>(5));
        }


        public static T SumOfLargestKNumbers<T>(this List<T> values, int k) where T : INumber<T>
        {
            T sum = default(T);
            foreach (T value in values.OrderByDescending(x => x).Take(k).ToList())
            {
                sum += value;
            }
            return sum;
        }
    }
    public abstract class Atlet
    {
        protected IMetanje Metanje { get; set; }
        protected ITekanje Tekanje { get; set; }
        protected ISkakanje Skakanje { get; set; }

        public void MocOdskoka()
        {
            if (this.Skakanje == null)
            {
                Console.WriteLine("Ne skačem");
                return;
            }
            this.Skakanje.MocOdskoka(1500);
        }
        public void ReakciskiCasZacetka()
        {
            if (this.Tekanje == null)
            {
                Console.WriteLine("Ne tečem");
                return;
            }
            this.Tekanje.ReakciskiCasZacetka(200);

        }

    }
    public class SkakalecVDaljino : Atlet
    {
        public SkakalecVDaljino()
        {
            this.Skakanje = new SkokVDaljino();
            this.Tekanje = null;
            this.Metanje = null;
        }
    }
    public class Maratonec : Atlet
    {
        public Maratonec()
        {
            this.Skakanje = null;
            this.Tekanje = new Maraton();
            this.Metanje = null;
        }
    }

    public interface ISkakanje
    {
        public void Zalet(double dolzinaZaleta);
        public void MocOdskoka(double mocOdskoka);
    }
    public class SkokVDaljino : ISkakanje
    {
        public void MocOdskoka(double mocOdskoka)
        {
            Console.WriteLine($"moč odskoka v daljino {mocOdskoka}");
        }

        public void Zalet(double dolzinaZaleta)
        {
            Console.WriteLine($"dolžina zaleta v daljino {dolzinaZaleta}");
        }
    }
    public class SkokVVisino : ISkakanje
    {
        public void MocOdskoka(double mocOdskoka)
        {
            Console.WriteLine($"moč odskoka v višino {mocOdskoka}");
        }

        public void Zalet(double dolzinaZaleta)
        {
            Console.WriteLine($"dolžina zaleta v višino {dolzinaZaleta}");
        }
    }

    public interface ITekanje
    {
        public void ReakciskiCasZacetka(double reakcija);
        public double dolzinaKoraka { get; }
    }

    public class Maraton : ITekanje
    {
        public double dolzinaKoraka => 1.5;

        public void ReakciskiCasZacetka(double reakcija)
        {
            Console.WriteLine($"reakcijski čas na maratonu je {reakcija}");
        }
    }
    public class Sprint : ITekanje
    {
        public double dolzinaKoraka => 2;

        public void ReakciskiCasZacetka(double reakcija)
        {
            Console.WriteLine($"reakcijski čas na šprintu je {reakcija}");
        }
    }
    public interface IMetanje
    {
        public void Izmet(double kotIzmeta);
        public string ObjektMetanja { get; }
    }
    public class MetKladiva : IMetanje
    {
        public string ObjektMetanja => "kladivo";

        public void Izmet(double kotIzmeta)
        {
            Console.WriteLine($"povprečen kot izmeta kladiva je {kotIzmeta}");
        }
    }


    public abstract class MobilnaNaprava
    {
        protected ITelefoniranje Telefoniranje { get; set; }

        public void SprejmiKlic()
        {
            this.Telefoniranje.Sprejmi();
        }
    }
    public class PametniTelefon : MobilnaNaprava
    {
        public PametniTelefon(string proizvajalec)
        {
            this.Telefoniranje = new Telefoniranje();
            this.Proizvajalec = proizvajalec;
        }

        public string Proizvajalec { get; }
        public string TelefonskaStevilka { get; set; }
    }
    public interface ITelefoniranje
    {
        public void Sprejmi();
        public void Zavrni();

    }
    public class Telefoniranje : ITelefoniranje
    {
        public void Sprejmi()
        {
            Console.WriteLine("Klic je uspešno sprejet."); ;
        }

        public void Zavrni()
        {
            Console.WriteLine("Klic je uspešno zavrnjen.");
        }
    }
}
