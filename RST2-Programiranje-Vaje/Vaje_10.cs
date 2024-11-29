using System.Diagnostics;
using System.Text;

namespace RST2_Programiranje_Vaje
{
    public enum Vaje_10_Naloge
    {
        Naloga421 = 1,
        Naloga422 = 2
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

        public static void Naloga422()
        {            
            List<IVerifiable> nekSeznam = new();

            Passport pp = Passport.GetInstance();
            pp.TwoFactorAuthentificationNumber = "1234";
            nekSeznam.Add(pp);

            for (int i = 0; i < 5; i++)
            {
                nekSeznam.Add(new EmploymentContract()
                {
                    TwoFactorAuthentificationNumber = i.ToString(),
                });
            }

            foreach (IVerifiable ver in nekSeznam)
            {
                Console.WriteLine(ver.TwoFactorAuthentificationNumber);
                ver.Authenticate("3");
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

    public interface IVerifiable
    {
        string TwoFactorAuthentificationNumber { get; set; }
        void Authenticate(string pin);
    }

    public sealed class Passport : IVerifiable
    {
        private static Passport _instance;

        public string Name { get; set; }
        public string TwoFactorAuthentificationNumber { get; set; }

        private Passport() { }

        public static Passport GetInstance()
        {
            if (_instance != null) 
                return _instance;

            _instance = new Passport();
            return _instance;
        }

        public void Authenticate(string pin)
        {
            if (pin == TwoFactorAuthentificationNumber) 
                Console.WriteLine("User Authenticated");
            else 
                Console.WriteLine("Phishing attempt!");
        }
    }

    public class EmploymentContract : IVerifiable
    {
        public string TwoFactorAuthentificationNumber { get; set; }

        public void Authenticate(string pin)
        {
            if (pin == TwoFactorAuthentificationNumber) Console.WriteLine("Contract legitimate");
            else Console.WriteLine("Fraud attempt!");
        }
    }
}

