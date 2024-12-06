namespace RST2_Programiranje_Vaje
{
    public enum Vaje_11_Naloge
    {
        Naloga441 = 1,
        Naloga442 = 2,
        Naloga443 = 3,
    }

    /// <summary>
    /// Rešitve vaj - 6. december 2024
    /// </summary>
    public class Vaje_11
    {
        /// <summary>
        /// NAVODILA
        /// </summary>
        public static void Naloga441()
        {
            Atlet joze = new SkakalecVDaljino();
            joze.MocOdskoka();
            Atlet luka = new Maratonec();
            luka.MocOdskoka();
            luka.ReakciskiCasZacetka();

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
}
