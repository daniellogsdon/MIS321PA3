using api.Models.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;



namespace api.Models
{
    public class EditDriver : IEditDriver
    {
        public void EditTheDriver(Driver value)
        {
             ConnectionString connectionString = new ConnectionString();
            string cs = connectionString.cs;

            MySqlConnection con = new MySqlConnection(cs);
            if (con.State == ConnectionState.Closed){
                con.Open();
            }

            string stm = @"UPDATE drivers SET Name = @Name, Rating = @Rating, Date_Hired = @DateHired, Deleted=@Deleted WHERE Id = @Id";
            using var cmd = new MySqlCommand(stm, con);
           
            cmd.Parameters.AddWithValue("@Name", value.Name);
            cmd.Parameters.AddWithValue("@Rating",value.Rating);
            cmd.Parameters.AddWithValue("@DateHired", value.DateHired);
            cmd.Parameters.AddWithValue("@Deleted", value.Deleted);
            cmd.Parameters.AddWithValue("@ID", value.Id);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}