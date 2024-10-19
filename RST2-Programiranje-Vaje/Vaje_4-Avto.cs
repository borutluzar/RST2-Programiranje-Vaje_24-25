namespace RST2_Programiranje_Vaje
{
    internal class Avto
    {
        private const double MAXMOCMOTORJA = 450;

        /// <summary>
        /// konstruktor
        /// </summary>
        /// <param name="stSasije"></param>
        public Avto(string stSasije)
        {
            this.StSasije = stSasije;
        }

        private int letnicaIzdelave;
        public int LetnicaIzdelave
        {
            get
            {
                return letnicaIzdelave;
            }
            set
            {
                if (value > DateTime.Now.Year)
                {
                    throw new ArgumentException("Letnica izdelave je napačna");
                }
                else
                {
                    letnicaIzdelave = value;
                }
            }
        }

        private double mocMotorja;

        public double MocMotorja
        {
            get
            {
                return mocMotorja;
            }
            set
            {
                if (value > MAXMOCMOTORJA)
                {
                    throw new ArgumentException("Moč je previsoka za naše ceste");
                }
                else
                {
                    mocMotorja = value;
                }
            }
        }

        /// <summary>
        /// Lastnist vrača število potnikov
        /// </summary>
        public int StPotnikov { get; set; }

        public int StVrat { get; set; }

        public string StSasije { get; }

        public int Hp
        {
            get
            {
                return (int)(this.MocMotorja * 1.341);
            }
        }
    }
}
