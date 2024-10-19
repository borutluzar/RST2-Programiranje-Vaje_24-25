using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RST2_Programiranje_Vaje
{
    internal class Avto
    {
        private const double MAXMOCMOTORJA = 450;
        private int letnicaIzdelave;
        private double mocMotorja;

        /// <summary>
        /// Konstruktor za številko šasije
        /// </summary>
        /// <param name="stSasije"></param>
        public Avto(string stSasije)
        {
            this.StSasije = stSasije;
        }

        public Avto()
        {
            this.StSasije = "00000000";
            this.StPotnikov = 5;
            this.StVrat = 4;
            this.MocMotorja = 0;
            this.LetnicaIzdelave = DateTime.Now.Year;
        }

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
                    throw new ArgumentException($"Letnica izdelave {value} je napačna.");
                }
                // throw vrne return, tako da else {} ni potreben, lahko bi napisali le: letnicaIzdelave = value;
                else letnicaIzdelave = value;
            }
        }

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
                    throw new ArgumentException($"Moč motorja {value} kW je previsoka za registracijo v Sloveniji, ki je {MAXMOCMOTORJA} kW. \n");
                }
                mocMotorja = value;
            }
        }
        /// <summary>
        /// Lastnost vrača število potnikov
        /// </summary>
        public int StPotnikov { get; set; }

        public int StVrat { get; set; }

        public string StSasije { get; }

        /// <summary>
        /// Lastnost vrača konjske moči
        /// </summary>
        public int Hp
        {
            get
            {
                return (int)Math.Round(this.MocMotorja * 1.341, MidpointRounding.AwayFromZero);
            }
        }
    }
}
