using MojaKnjiznica;
using System.Runtime.ConstrainedExecution;

namespace RST2_Programiranje_Vaje
{
    public enum Vaje1
    {
        Naloga112 = 1,
        Naloga123 = 2,
        Naloga131 = 3,
        Naloga141 = 4,
    }

    /// <summary>
    /// Rešitve vaj - 3. oktober 2024
    /// </summary>
    public class Vaje_1
    {
        /// <summary>
        /// V rešitev iz prejšnje naloge dodajte še en projekt tipa Class Library, 
        /// vanj dodajte razred z neko metodo.
        /// Nato novi projekt dodajte kot referenco v prvega 
        /// ter v programu HelloWorld pokličite metodo iz drugega projekta.
        /// </summary>
        public static void Naloga112()
        {
            int rezultat = AuxilliaryFunctions.Vsota(4, 6);
            Console.WriteLine($"Vsota števil 4 in 6 je {rezultat}");
        }

        /// <summary>
        /// Zapišite funkcijo, ki uporablja stavek switch, da se odloči 
        /// za izpis števila dni v danem mesecu. 
        /// Predpostavite lahko, da nismo v prestopnem letu. 
        /// Možnosti, ki vrnejo enako vrednost, združite.
        /// </summary>
        public static int Naloga123(int mesec)
        {
            switch (mesec)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    return 28;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                default: // Če številka meseca ni na interalu med 1 in 12, vrnemo 0
                    return 0;
            }
        }

        /// <summary>
        /// Zapišite metodo, ki izpisuje trenutni čas,  
        /// dokler produkt ur, minut in sekund ni deljiv s 17.
        /// Uporabite lastnost Now razreda DateTime.
        /// </summary>
        public static void Naloga131()
        {
            // Pridobimo trenutni čas
            DateTime trenutniCas = DateTime.Now;

            // Ponavljamo, dokler produkt ni deljiv s 17
            while ((trenutniCas.Hour * trenutniCas.Minute * trenutniCas.Second) % 17 != 0)
            {
                // Uporabimo formatiranje v interpolaciji
                Console.WriteLine($"{trenutniCas:HH:mm:ss}");

                // Po vsakem izpisu počakamo 900 ms
                Thread.Sleep(900);
                
                trenutniCas = DateTime.Now;
            }
            Console.WriteLine($"{trenutniCas:HH:mm:ss} je deljivo s 17.");
        }

        /// <summary>
        /// Zapišite metodo, ki kot parameter dobi dve celi števili 
        /// in vrne njun najmanjši skupni večkratnik ter največji skupni delitelj.
        /// </summary>
        public static (int, int) Naloga141(int x, int y)
        {
            int nsv = AuxilliaryFunctions.LCM(x, y);
            int nsd = AuxilliaryFunctions.GCD(x, y);

            // Vračamo dve (enakovredni) vrednosti, zato uporabimo 'tuple'
            return (nsv, nsd);
        }
    }
}
