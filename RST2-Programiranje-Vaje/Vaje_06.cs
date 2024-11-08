using FIS_programiranje_7_druga;
using System;

namespace RST2_Programiranje_Vaje
{
    public enum Vaje_06_Naloge
    {
        Naloga254 = 1,        
    }

    /// <summary>
    /// Rešitve vaj - 30. oktober 2024
    /// </summary>
    public class Vaje_06
    {
        /// <summary>
        /// V knjižnici so naročili izdelavo novega programskega orodja, 
        /// ki bo omogočalo izposojo knjižničnega gradiva na več načinov: 
        /// preko mobilne aplikacije, preko spletne aplikacije in preko 
        /// namizne aplikacije, ki jo bo upravljal uslužbenec knjižnice. 
        /// Pripravite razredni model z razredi, 
        /// ki bodo predstavljali različna knjižnična gradiva. 
        /// Napišite vsaj tri nivoje dedovanja, 
        /// pri čemer naj bodo vsi razredi na prvih dveh nivojih abstraktni.
        /// </summary>
        public static void Naloga254()
        {
            Kvadrat kvadratek = new(5.8);
            kvadratek.Izpis();

            Trikotnik trikotnicek = new(6.66, 5.86, 2.5);
            trikotnicek.Izpis();

            Krog krogec = new(6.66);
            krogec.Izpis();
        }
    }    
}
