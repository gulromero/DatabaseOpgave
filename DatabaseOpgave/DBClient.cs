using System.Data.SqlClient;
using System.Data;

namespace DatabaseOpgave
{
    internal class DBClient
    {
        private readonly string connectionString;

        // Konstruktør:
        public DBClient(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Start()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine("Database connection is open! Opgave 6.1:");

                    // Indhenter alle hoteller (Opgave 6.1)
                    AllHotels(connection);
                }
                else
                {
                    Console.WriteLine("Connection failed");
                }
            }
        }

        // Henter alle hoteller (Opgave 6.1)
        private void AllHotels(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM DemoHotel", connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int Hotel_No = reader.GetInt32(reader.GetOrdinal("Hotel_No"));
                    string Name = reader.GetString(reader.GetOrdinal("Name"));
                    string Address = reader.GetString(reader.GetOrdinal("Address"));
                    Console.WriteLine($"Hotel_No: {Hotel_No}, Name: {Name}, Address: {Address}");
                }
            }
        }

        // Henter specifikt hotel (Opgave 6.2)
        public void GetSpecificHotel(int hotelId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine("Database connection is open! Opgave 6.2:");

                    // SQL query  for at finde et specifikt hotel 
                    string specificHotelQuery = $"SELECT * FROM DemoHotel WHERE Hotel_No = {hotelId}";

                    using (SqlCommand command = new SqlCommand(specificHotelQuery, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int Hotel_No = reader.GetInt32(reader.GetOrdinal("Hotel_No"));
                            string Name = reader.GetString(reader.GetOrdinal("Name"));
                            string Address = reader.GetString(reader.GetOrdinal("Address"));
                            Console.WriteLine($"Hotel_No: {Hotel_No}, Name: {Name}, Address: {Address}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Connection failed");
                }
            }
        }

        //Laver en metode til insertnewhotel, opgave 6.3
        public void InsertNewHotel(int hotelNo, string name, string address)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine("Database connection is open yay");

                    // SQL query  for at tilføje et nyt hotel
                    string insertQuery = $"INSERT INTO DemoHotel (Hotel_No, Name, Address) VALUES ('{hotelNo}','{name}', '{address}')";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"New hotel has been added.");
                        }
                        else
                        {
                            Console.WriteLine($"Failed to add new hotel.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Connection failed");
                }
            }
        }


        // Opgave 6.4 - slet et hotel
        public void DeleteHotel(int hotelNo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine("Database connection works still! Now lets delete the hotel you'd like..");

                    // SQL query, for at slette et hotel
                    string deleteQuery = $"DELETE FROM DemoHotel WHERE Hotel_No = {hotelNo}";

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Hotel w/ Hotel_No {hotelNo} is now completely gonee.");
                        }
                        else
                        {
                            Console.WriteLine($"What? Couldn't find that hotel with that hotel number. {hotelNo}.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Connection failed");
                }
            }
        }

        public void UpdateHotel(int hotelNo, string newName, string newAddress)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine("Database connection is open yay");

                    // SQL query to update a hotel
                    string updateQuery = $"UPDATE DemoHotel SET Name = '{newName}', Address = '{newAddress}' WHERE Hotel_No = {hotelNo}";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Hotel with Hotel_No {hotelNo} has been updated.");
                        }
                        else
                        {
                            Console.WriteLine($"No hotel found with Hotel_No {hotelNo}.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Connection failed");
                }
            }
        }

    }

}
    

