using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;

namespace RST2_Programiranje_Vaje
{
    public enum Vaje4
    {
        Naloga221 = 1
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

    }
}
