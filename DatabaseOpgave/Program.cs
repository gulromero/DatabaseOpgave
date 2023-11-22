namespace DatabaseOpgave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // connectionstring (connection til database Hotel) 
            string connectionString = "Server=LAPTOP-MGLN9LNS;Database=Hotel;Trusted_Connection=True;Encrypt=False";
            
            // Laver instance af DBClient
            DBClient dbClient = new DBClient(connectionString);

            //Caller Start method
            dbClient.Start();

            //Specifik Hotel
            Console.WriteLine();
            dbClient.GetSpecificHotel(8);

            //Adder et ny hotel: 
            Console.WriteLine();
            Console.WriteLine("Det nye hotel (Opgave 6.3)");
            dbClient.InsertNewHotel(9, "Det Nye Hotel", "Den nye adresse 232");

           // Sletter det nyligt addede hotel
             dbClient.DeleteHotel(9);

            //Opdaterer hotel: 

            dbClient.UpdateHotel(9, "Det nye hotel med nyt navn", "Den helt nye adresse");


        }
    }
}