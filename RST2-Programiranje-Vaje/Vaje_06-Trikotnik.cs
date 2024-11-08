namespace FIS_programiranje_7_druga
{
    internal class Trikotnik : GeometrijskiLik
    {
        public Trikotnik(double stA, double stB, double stC)
        {
            StranicaA = stA;
            StranicaB = stB;
            StranicaC = stC;
        }

        public double StranicaA { get; set; }
        public double StranicaB { get; set; }
        public double StranicaC { get; set; }
        
        public override double Ploscina
        {
            get
            {
                double pol = Obseg / 2;
                return Math.Sqrt(pol * (pol - StranicaA) * (pol - StranicaB) * (pol - StranicaC));
            }
        }

        public override double Obseg
        {
            get
            {
                return StranicaA + StranicaB + StranicaC;
            }
        }

        public override void Izpis()
        {
            Console.WriteLine($"Trikotnik:\t{StranicaA}\t{StranicaB}\t{StranicaC}\t ima ploscino:\t{this.Ploscina}" +
                $"\tObseg:\t{this.Obseg}");
        }
    }
}
