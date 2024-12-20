using System.Diagnostics;

namespace RST2_Programiranje_Vaje
{
    public enum Vaje_13_Naloge
    {
        Naloga711 = 1,
        Naloga721 = 2,
        Naloga722 = 3, /* Domača vaja */
    }

    /// <summary>
    /// Rešitve vaj - 20. december 2024
    /// </summary>
    public class Vaje_13
    {
        /// <summary>
        /// Napišite program, ki hkrati izvaja dva procesa. 
        /// Prvi proces vsakih 7 stotink sekunde poveča dani kot za 1 radian,
        /// drugi proces pa vsakih 11 stotink sekunde poveča dani kot za 4 radiane. 
        /// Uporabniku se prikazujeta oba kota z modulom 2 Pi, 
        /// torej na nek način kot kota dveh urinih kazalcev. 
        /// Uporabnik ima možnost prekinitve programa. 
        /// Ko ga prekine, se mu izpiše razlika med kotoma. 
        /// Cilj je, da gumb pritisne ob čim manjši razliki. 
        /// Analizirajte, kako hitro se program odziva na prekinitev.
        /// </summary>
        public static void Naloga711()
        {
            CancellationTokenSource token = new();

            // Spodnja taska prejmeta rezultat funkcije, zato moramo paziti,
            // da njunega tipa ne označimo kot Task, ampak kot Task<double> (ali samo z var)!
            Task<double> taskAlpha = Task.Run(() => PovecajRadiane(1, 70, token));
            Task<double> taskBeta = Task.Run(() => PovecajRadiane(4, 110, token));

            Console.ReadLine();
            Console.WriteLine($"Prekinitev programa: {DateTime.Now:HH:mm:ss.fff}");
            token.Cancel();
            var alpha = taskAlpha.Result;
            Console.WriteLine($"Razlika med kotoma: {Math.Abs(taskAlpha.Result - taskBeta.Result)}");

        }

        private static double PovecajRadiane(int increment, int timeout, CancellationTokenSource token)
        {
            double angle = 0;
            while (!token.IsCancellationRequested)
            {
                angle = (angle + increment) % (2 * Math.PI);
                Thread.Sleep(timeout);
            }
            Console.WriteLine($"Prekinitev metode {nameof(PovecajRadiane)}: {DateTime.Now:HH:mm:ss.fff}");
            return angle;
        }

        /// <summary>
        /// Napišite program, ki enkrat na dan zažene instanco brskalnika, 
        /// ki odpre stran z novicami. 
        /// (Pobrskajte, kako zaženemo nov proces Process).
        /// </summary>
        public static void Naloga721()
        {
            Process process = new Process();
            process.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            process.StartInfo.Arguments = "https://www.nytimes.com/";
            var timer = new Timer(
                state =>
                {
                    process.Start();
                },
                null, // Objekt, ki ga uporabimo v spremenljivki state v zgornjem lambda izrazu
                0,   // Zamik pred prvim klicem timerja
                24 * 60 * 60 * 1000    // Interval med zaporednimi klici. V tem primeru en dan.
                );
        }
    }
}
