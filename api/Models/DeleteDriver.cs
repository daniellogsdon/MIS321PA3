using api.Models.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;

namespace api.Models
{
    public class DeleteDriver : IDeleteDriver
    {
        public void DeleteTheDriver(Driver value)
        {
            ConnectionString connectionString = new ConnectionString();
            string cs = connectionString.cs;

            MySqlConnection con = new MySqlConnection(cs);
            if (con.State == ConnectionState.Closed){
                con.Open();
            }

            string stm = @"UPDATE drivers SET Deleted = @Deleted WHERE Id = @Id";
            using var cmd = new MySqlCommand(stm, con);
           
            cmd.Parameters.AddWithValue("@Id",value.Id);
            cmd.Parameters.AddWithValue(@"Deleted", value.Deleted);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}