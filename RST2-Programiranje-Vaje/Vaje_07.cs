namespace RST2_Programiranje_Vaje
{
    public enum Vaje_07_Naloge
    {
        Naloga261 = 1,
        Naloga266 = 2,
    }

    /// <summary>
    /// Rešitve vaj - 7. november 2024
    /// </summary>
    public class Vaje_07
    {
        /// <summary>
        /// Definirajte razred Porocilo in vmesnik Dokument, 
        /// ki ga Porocilo implementira. 
        /// V vmesniku določite nujne (meta)lastnosti, 
        /// ki jih običajno mora imeti vsak dokument, 
        /// v razredu Porocilo pa jih ustrezno implementirajte.
        /// 
        /// (Dodana navodila za nalogo 262):
        /// Definirajte še vmesnik Workflow, ki določa lastnosti in metode 
        /// za pošiljanje poročila po delovnem toku, 
        /// in ga implementirajte razredu Porocilo iz prejšnje naloge. 
        /// Pri tem dodajte še razred SystemUser, 
        /// ki bo predstavljal uporabnika delovnega toka v vmesniku Workflow.
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

        /// <summary>
        /// Pripravite dva vmesnika.  Prvi naj definira metode, 
        /// ki jih potrebuje razred, kateri omogoča nakup oziroma rezervacijo vozne karte 
        /// za poljuben tip prevoza. 
        /// Drugi vmesnik naj vsebuje metode, ki omogočajo rezervacijo ustreznega sedišča 
        /// na prevoznem sredstvu. Oba vmesnika naj vsebujeta metodo Reserve, 
        /// ki kot parameter dobi identifikacijsko številko karte oziroma sedeža.
        /// Nato implementirajte razred, npr. PlaneTravel, 
        /// ki bo poskrbel za funkcionalnosti, 
        /// ki jih mora imeti sistem za rezervacijo vozne karte in ustreznega sedišča.
        /// Za potrebe naloge definirajte tudi razred Ticket, 
        /// ki predstavlja vozno karto. 
        /// Na koncu še kreirajte instanco tega objekta in pokličite vse njegove metode.
        /// </summary>
        public static void Naloga266()
        {
            PlaneTravel travel = new PlaneTravel();
            List<Ticket> tickets = travel.Choose(DateTime.Now);
            string? id = tickets.MinBy(x => x.Price)?.ID;
            if(id != null)
                ((ITravelTicket)travel).Reserve(id);
        }
    }    
}
