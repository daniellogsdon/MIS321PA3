using api.Models.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;
namespace api.Models
{
    public class ReadDriverData : IGetAllDrivers, IGetDriver
    {
        public List<Driver> GetAllDrivers()
        {
            List<Driver> drivers = new List<Driver>();

            //Getting Connection string
            ConnectionString connectionString = new ConnectionString();
            string cs = connectionString.cs;

            //open
            MySqlConnection con = new MySqlConnection(cs);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Step One");
            Console.ForegroundColor = ConsoleColor.White;
            if (con.State == ConnectionState.Closed){
                con.Open();
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Step Two");
            Console.ForegroundColor = ConsoleColor.White;

            //Statement
            string stm = "SELECT * from drivers order by Date_Hired desc";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Step Three");
            Console.ForegroundColor = ConsoleColor.White;

            while (rdr.Read())
            {
                Console.WriteLine(rdr.GetInt32(0) + " " + rdr.GetString(1));
                Driver newDriver = new Driver() { Id = rdr.GetInt32(0), Name = rdr.GetString(1), Rating = rdr.GetInt32(2), DateHired = rdr.GetDateTime(3), Deleted = rdr.GetBoolean(4) };
                drivers.Add(newDriver);
            }

            //Close
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Step Four");
            Console.ForegroundColor = ConsoleColor.White;
            con.Close();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Step Five");
            Console.ForegroundColor = ConsoleColor.White;
            return drivers;
        }

        public Driver GetDriver(int id)
        {
            ConnectionString connectionString = new ConnectionString();
            string cs = connectionString.cs;

            MySqlConnection con = new MySqlConnection(cs);
            if (con.State == ConnectionState.Closed){
                con.Open();
            }

            string stm = "SELECT * FROM drivers where id = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Prepare();
            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Driver() { Id = rdr.GetInt32(0), Name = rdr.GetString(1), Rating = rdr.GetInt32(2), DateHired = rdr.GetDateTime(3)};
        }
    }
}