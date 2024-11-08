namespace FIS_programiranje_7_druga
{
    internal class Krog : GeometrijskiLik
    {
        public Krog(double polmer)
        {
            Polmer = polmer;
        }

        public double Polmer { get; set; }
        
        /// <summary>
        /// Implementacija abstraktne lastnosti
        /// </summary>
        public override double Ploscina
        {
            get
            {
                return Math.PI * Polmer * Polmer;
            }
        }

        public override double Obseg
        {
            get
            {
                return Math.PI * 2 * Polmer;
            }
        }

        public override void Izpis()
        {
            Console.WriteLine($"Krog:\t{Polmer}\t ima ploscino:\t{this.Ploscina}" +
                $"\tObseg:\t{this.Obseg}");
        }
    }
}
