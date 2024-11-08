namespace FIS_programiranje_7_druga
{
    internal class Kvadrat : GeometrijskiLik
    {
        public Kvadrat(double stranica)
        {
            Stranica = stranica;
        }

        public double Stranica { get; set; }
                
        public override double Ploscina
        {
            get
            {
                return Stranica * Stranica;
            }
        }

        public override double Obseg
        {
            get
            {
                return 4 * Stranica;
            }
        }

        public override void Izpis()
        {
            Console.WriteLine($"Kvadrat:\t{Stranica}\t ima ploscino:\t{this.Ploscina}" +
                $"\tObseg:\t{this.Obseg}");
        }
    }
}
