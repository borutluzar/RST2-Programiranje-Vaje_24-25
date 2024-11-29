using System.Diagnostics;
using System.Text;

namespace RST2_Programiranje_Vaje
{
    public enum Vaje_10_Naloge
    {
        Naloga421 = 1,        
    }

    /// <summary>
    /// Rešitve vaj - 29. november 2024
    /// </summary>
    public class Vaje_10
    {
        public static void Naloga421()
        {
            Console.WriteLine("Navedite ime: ");
            var ime = Console.ReadLine();
            ResultSaver rs = ResultSaver.GetInstance(ime!);
            Random r = new Random();
            Stopwatch sw;
            var counter = 0;
            while (true)
            {
                counter++;
                var firstNr = r.Next(1, 21);
                var secondNr = r.Next(1, 21);

                var question = $"{counter}. Vnesi produkt {firstNr} * {secondNr}: ";

                Console.Write(question);
                sw = Stopwatch.StartNew();
                var answer = Convert.ToInt32(Console.ReadLine());
                var correctAnswer = firstNr * secondNr;
                sw.Stop();

                rs.WriteResult(question, answer.ToString(), sw.Elapsed.TotalSeconds.ToString("0.00"));
                if (answer == correctAnswer)
                {
                    Console.WriteLine("Odgovor je pravilen!");
                }
                else
                {
                    Console.WriteLine($"Odgovor je napačen! Pravilen odgovor je {correctAnswer}!");
                    break;
                }
            }
        }
    }

    public sealed class ResultSaver
    {
        private static ResultSaver? _instance = null;
        private string _fileName = "";
        public string SolverName { get; }

        private ResultSaver(string name)
        {
            SolverName = name;
            _fileName = $"{name}-Result-{DateTime.Now:yyyy-MM-dd__HH-mm-ss}.txt";

            using StreamWriter sw = new StreamWriter(_fileName, true, Encoding.UTF8);
            sw.WriteLine($"Ime reševalca: {SolverName}");
        }

        public static ResultSaver GetInstance(string name)
        {
            if (_instance == null)
            {
                _instance = new ResultSaver(name);
            }

            return _instance;
        }

        public void WriteResult(string question, string answer, string time)
        {
            using StreamWriter sw = new StreamWriter(_fileName, true, Encoding.UTF8);
            sw.WriteLine($"{question} ({time}): {answer}");
        }
    }
}    

