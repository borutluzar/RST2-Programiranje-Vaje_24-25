namespace RST2_Programiranje_Vaje
{

    /// <summary>
    /// Razred, ki definira splošno karto
    /// </summary>
    public class Ticket
    {
        public Ticket(string id)
        {
            ID = id;
        }

        public string ID { get; }
        public string Destination { get; set; }
        public string Name { get; set; }
        public DateTime DateValidity { get; }
        public double Price { get; set; }
    }

    interface ITravelTicket
    {
        List<Ticket> Choose(DateTime startDate);

        /// <summary>
        /// Metoda kot parameter dobi id karte
        /// </summary>
        bool Reserve(string id);
    }

    interface ISeatTicket
    {
        /// <summary>
        /// Metoda kot parameter dobi id sedeža
        /// </summary>
        bool Reserve(string id);

        List<string> GetEmptySeats();
    }

    /// <summary>
    /// Razred za nakup letalskih vozovnic, ki implementira oba vmesnika
    /// </summary>
    public class PlaneTravel : ISeatTicket, ITravelTicket
    {
        public List<Ticket> Choose(DateTime startDate)
        {
            // Pripravimo tri letalske karte za testno izvedbo metode
            Ticket ticket1 = new Ticket("1A");
            ticket1.Price = 100;
            Ticket ticket2 = new Ticket("2A");
            ticket2.Price = 200;
            Ticket ticket3 = new Ticket("3A");
            ticket3.Price = 400;

            List<Ticket> list = new List<Ticket>();
            list.Add(ticket1);
            list.Add(ticket2);
            list.Add(ticket3);
            return list;
        }

        public List<string> GetEmptySeats()
        {
            // Pripravimo nek privzet seznam id-jev sedežev
            // za testno izvedbo metode
            return ["5", "8", "2", "1"];
        }

        bool ISeatTicket.Reserve(string id)
        {
            Console.WriteLine($"Sedez z id-jem: {id} je rezerviran");
            return true;
        }

        bool ITravelTicket.Reserve(string id)
        {
            Console.WriteLine($"Karta z id-jem: {id} je rezervirana");
            return true;
        }
    }
}
