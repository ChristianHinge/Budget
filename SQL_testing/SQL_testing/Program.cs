using System;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace SQL_testing
{
    class Program
    {
        static void Main(string[] args)
        {   //Connecting to DB
            string connectionString = "Server=192.168.0.101;User=Christian;Password=Liparis4;Database=BudgetDB;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            //Creating Query command
            string commandTxt = "SELECT * FROM Posteringer;";
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = commandTxt;

            //Executing Query command
            MySqlDataReader reader = cmd.ExecuteReader();

            //Diplaying Query result
            int i = 0;
            while(reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
                Console.WriteLine(reader.GetString(1));
                Console.WriteLine(reader.GetString(2));
                Console.WriteLine(reader.GetString(3));
                Console.WriteLine("-------");
                i++;
            }
            reader.Close();
            cmd.CommandText = "INSERT INTO Posteringer VALUES (\"c\",\"er\",5,6);";
            reader = cmd.ExecuteReader();
            Console.ReadLine();
        }
    }
}
