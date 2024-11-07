namespace RST2_Programiranje_Vaje
{

    /// <summary>
    /// Rešitve vaj - 7. november 2024
    /// </summary>
    /// 
    interface IDocument 
    {
        string Title { get; }
        DateTime DateCreated { get; }
        string Author { get; set; }

        void Save(); 
    }


    public class Report : IDocument
    {

        public Report(string title, DateTime date) 
        { 
            Title = title;
            DateCreated = date;
        }
        public string Title { get; }

        public DateTime DateCreated { get; }

        public string Author { get; set; }

        public void Save()
        {
            Console.WriteLine("Porocilo je bilo uspešno shranjeno.");
        }
    }
}
