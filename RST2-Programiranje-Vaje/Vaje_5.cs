using System.Diagnostics.Metrics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;

namespace RST2_Programiranje_Vaje
{
    public enum Vaje5
    {
        Naloga244 = 1,
        Naloga245 = 2,
    }

    /// <summary>
    /// Rešitve vaj - 26. oktober 2024
    /// </summary>
    public sealed class Vaje_5
    {
        /// <summary>
        /// Postali ste del razvojne ekipe večjega sistema. 
        /// Vaša prva naloga je, da pripravite podrazred NadzornaKomisija razreda Komisija, 
        /// ki bo vseboval metodo PreveriClana. 
        /// Metoda z enakim imenom že obstaja v nadrazredu, vendar zaradi politike podjetja, 
        /// tega razreda trenutno ne morete spreminjati, metoda pa tudi ni označena kot virtual, 
        /// se pravi, da je ne morete povoziti. 
        /// Ali lahko metodo z enakim imenom sploh dodate v podrazred? 
        /// Če da, kako in kako se razlikuje njeno obnašanje glede na metode, 
        /// ki jih povozimo z override?
        /// </summary>
        public static void Naloga244()
        {
            Komisija komisija = new();
            NadzornaKomisija nadz_komisija = new();

            Console.WriteLine(komisija.PreveriClana(1));
            Console.WriteLine(nadz_komisija.PreveriClana(1));

            Console.WriteLine((nadz_komisija as Komisija).PreveriClana(1));
            Console.WriteLine(((Komisija)nadz_komisija).PreveriClana(1));

            Console.Read();
        }

        /// <summary>
        /// Definirajte razreda Menu in Jed. 
        /// Menu naj predstavlja dnevni menu v restavraciji (glede na dan),
        /// ki ima kot lastnost tudi seznam jedi. 
        /// Posamezna jed ima lastnosti naziv in cena. 
        /// Za razred Jed naredite podrazred Sladica, ki bo imel dodatno lastnost Kalorije. 
        /// 
        /// V razredih Jed in Sladica povozite metodo ToString,  
        /// da bo ustrezno vračala vse lastnosti instanc.        
        ///  
        /// Metodo ToString povozite tudi v razredu Menu. 
        /// Vrne naj niz z dnevom in vsemi jedmi, ki so na menuju, 
        /// med seboj pa naj bodo ločene s prazno vrstico.      
        /// 
        /// V razredu Menu napišite še metodo, ki bo izpisala skupno ceno menuja. 
        /// Metoda naj ima vhodni parameter tipa bool, ki bo določal, 
        /// ali želite ob ceni plačati še 10\% napitnine ali ne. 
        /// Če je vrednost parametra true, naj se skupna cena primerno izračuna. 
        /// 
        /// Za vsaj dva dni v tednu pripravite instanci razreda Menu, 
        /// ki bosta imeli na seznamu jedi vsaj po tri jedi, 
        /// od tega vsak natanko eno jed tipa Sladica.  
        /// Na koncu oba menuja tudi izpišite. 
        /// </summary>
        public static void Naloga245()
        {
            Menu sobota = new Menu(DateTime.Now);

            Jed solata = new Jed("grška") { Cena = 8 };
            Jed testenine = new Jed("karbonara") { Cena = 9 };
            Sladica sladica = new Sladica("tiramisu") { Cena = 4, Kalorije = 350 };

            sobota.Jedilnik.Add(solata);
            sobota.Jedilnik.Add(testenine);
            sobota.Jedilnik.Add(sladica);

            Console.WriteLine("JEDILNIK");
            Console.WriteLine(sobota.ToString());
            Console.WriteLine($"Skupna cena menija je {sobota.SkupnaCena(true)}.");
        }
    }    
}
