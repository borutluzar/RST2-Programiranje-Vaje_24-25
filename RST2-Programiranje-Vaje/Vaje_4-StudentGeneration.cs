namespace RST2_Programiranje_Vaje
{
    internal class StudentGeneration
    {
        public int LetoVpisa {  get; set; }
        public string StudijskiProgram {  get; set; }

        public int VelikostGeneracije { 
            get
            {
                return seznamStudentov.Count;
            } 
        }

        public Dictionary<int,Student> seznamStudentov = new();

        public Student this[int vpisnaSt]
        {
            get
            {
                if (seznamStudentov.ContainsKey(vpisnaSt))
                {
                    return seznamStudentov[vpisnaSt];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                seznamStudentov[vpisnaSt] = value;
            }
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Ime {  get; set; }
        public string Priimek {get; set; }        
        public Gender Spol {  get; set; }

        public Index Index { get; set; }

    }

    enum Gender
    {
        Moski=0,
        Zenska=1
    }
  
}
