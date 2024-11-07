namespace RST2_Programiranje_Vaje
{
    public enum Vaje_07_Naloge
    {
        Naloga261 = 1,        
    }

    /// <summary>
    /// Rešitve vaj - 7. november 2024
    /// </summary>
    public class Vaje_07
    {
        /// <summary>
        /// NAVODILA
        /// </summary>
        public static void Naloga261()
        {
            Report report = new Report("Porocilo o programiranju", DateTime.Now);
            report.Author = "Leon";
            report.Save();
            SystemUser user = new SystemUser(12);
            user.Name = "Enej";
            report.Validator = user;
            DateTime deadline = DateTime.Now.AddDays(10);
            report.SendToNextStage(deadline);
        }
    }    
}
