namespace RST2_Programiranje_Vaje
{

    internal class Poglavje
    {
        public string Naslov { get; set; }

        public int StPoglavja { get; set; }
        
        public List<string> Razdelki { set; get; } = new List<string>();

        public Poglavje(string naslov, int stPoglavja)
        {
            Naslov = naslov;
            StPoglavja = stPoglavja;
        }
    }

    /// <summary>
    /// Razredu popravimo ime za potrebe naloge 2.1.3, da lahko imamo obe verziji
    /// </summary>
    internal class Zapiski2
    {
        public List<Poglavje> seznamPoglavij;

        public string? Avtor { set; get; }

        public Zapiski2()
        {
            this.seznamPoglavij = new List<Poglavje>();
        }
        public Zapiski2(List<Poglavje> poglavja)
        {
            this.seznamPoglavij = poglavja;
        }
        public Zapiski2(Poglavje poglavje)
        {
            this.seznamPoglavij = new List<Poglavje>() { poglavje };
        }

        public void DodajPoglavje(Poglavje poglavje)
        {
            seznamPoglavij.Add(poglavje);
            Console.WriteLine($"Dodano je bilo poglavje:\t {poglavje}");
        }
        public int SteviloPoglavij()
        {
            return seznamPoglavij.Count;
        }
    }
}
