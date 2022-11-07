using api.Models.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;
namespace api.Models
{
    public class SaveDriver : IInsertDriver
    {
        public void InsertDriver(Driver value)
        {
            //Getting Connection string
            ConnectionString connectionString = new ConnectionString();
            string cs = connectionString.cs;

            //open
            MySqlConnection con = new MySqlConnection(cs);
            if (con.State == ConnectionState.Closed){
                con.Open();
            }

            
            string stm = @"INSERT INTO drivers(Name, Rating, Date_Hired, Deleted) VALUES(@Name, @Rating, @DateHired, @Deleted)";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@Name",value.Name);
            cmd.Parameters.AddWithValue("@Rating", value.Rating);
            cmd.Parameters.AddWithValue("@DateHired",value.DateHired);
            cmd.Parameters.AddWithValue("@Deleted", value.Deleted);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

       
    }
}