namespace RST2_Programiranje_Vaje
{
    /// <summary>
    /// Razred za nalogi 2.1.1 in 2.1.2
    /// </summary>
    internal class Zapiski
    {
        private List<string> seznamPoglavij;
        
        /// <summary>
        /// Prazen konstruktor.
        /// </summary>
        public Zapiski()
        {
            seznamPoglavij = new List<string>();
        }

        /// <summary>
        /// Konstruktor k nalogi 2.1.2
        /// </summary>
        public Zapiski(List<string> poglavja)
        {
            // Dva načina prirejanja seznama:
            //seznamPoglavij = new List<string>(poglavja);
            this.seznamPoglavij = poglavja;
        }

        /// <summary>
        /// Konstruktor k nalogi 2.1.2
        /// </summary>
        public Zapiski(string poglavje)
        {
            this.seznamPoglavij = new List<string>() { poglavje };
        }

        public void DodajPoglavje(string poglavje)
        {
            seznamPoglavij.Add(poglavje);
            Console.WriteLine($"Dodano je bilo poglavje:\t{poglavje}");
        }

        public int SteviloPoglavij()
        {
            return seznamPoglavij.Count;
        }
    }
}
