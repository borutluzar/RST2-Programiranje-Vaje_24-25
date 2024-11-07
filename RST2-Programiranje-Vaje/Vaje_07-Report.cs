namespace RST2_Programiranje_Vaje
{
    interface IDocument 
    {
        string Title { get; }
        DateTime DateCreated { get; }
        string Author { get; set; }

        void Save(); 
    }

    public class SystemUser 
    {
        public SystemUser(int id) 
        {
            ID = id;
        }
        int ID { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }

    interface IWorkflow
    {
        SystemUser Certifier { get; set; } 
        SystemUser Validator { get; set; }
        void SendToNextStage(DateTime deadline);
    }

    public class Report : IDocument, IWorkflow
    {
        public Report(string title, DateTime date) 
        { 
            Title = title;
            DateCreated = date;
        }
        public string Title { get; }

        public DateTime DateCreated { get; }

        public string Author { get; set; }
        public SystemUser Certifier { get; set; }
        public SystemUser Validator { get; set; }

        public void Save()
        {
            Console.WriteLine("Porocilo je bilo uspešno shranjeno.");
        }

        public void SendToNextStage(DateTime deadline)
        {
            if (DateTime.Now > deadline)
            {
                throw new Exception("Prekoracili ste rok.");
            }
            Console.WriteLine("Porocilo uspesno poslano v naslednji korak.");
        }
    }
}
