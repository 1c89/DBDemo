using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBOperations
{
    internal class PersonRepository : IRepo
    {
        private readonly string connectionString;

        public PersonRepository(string cn)
        {
            connectionString = cn;
        }

        public void Add(string fn, string ln, string email)
        {
            using (var conn = new SqlConnection(connectionString))

            {

                var cmd = new SqlCommand();
                //                cmd.CommandText = $"INSERT INTO [dbo].[Person] VALUES({fn},{ln},{email})";
                cmd.CommandText = $"INSERT INTO [dbo].[Person] VALUES(@fn,@ln,@email)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@fn", fn);
                cmd.Parameters.AddWithValue("@ln", ln);
                cmd.Parameters.AddWithValue("@email", email);
 
                conn.Open();

                //(new SqlCommand("DELETE FROM [dbo].[Person]", conn)).ExecuteNonQuery();
                cmd.ExecuteNonQuery();

                conn.Close();


            }
        }


        public void Delete(int id)
        {
            using (var conn = new SqlConnection(connectionString))

            {

                var cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM [dbo].[Person] WHERE [id]=@id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id",id); 
                cmd.Connection = conn;

                conn.Open();

                //(new SqlCommand("DELETE FROM [dbo].[Person]", conn)).ExecuteNonQuery();
                cmd.ExecuteNonQuery();

                conn.Close();


            }
        }

        public void DeleteAll()
        {
            using (var conn = new SqlConnection(connectionString))

            {

                var cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM [dbo].[Person]";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;

                conn.Open();

                //(new SqlCommand("DELETE FROM [dbo].[Person]", conn)).ExecuteNonQuery();
                cmd.ExecuteNonQuery();

                conn.Close();


            }
        }

        public IEnumerable<string> GetAll()
        {
            throw new NotImplementedException();
        }

        public string GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, string fn, string ln, string email)
        {
            using (var conn = new SqlConnection(connectionString))

            {

                var cmd = new SqlCommand();
                cmd.CommandText = "UPDATE [dbo].[Person] SET " +
                                        " FirstName = @fn," +
                                        " LastName = @ln," +
                                        " Email = @email" + 
                                        " WHERE [id]=@id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@fn", fn);
                cmd.Parameters.AddWithValue("@ln", ln);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Connection = conn;

                conn.Open();

                //(new SqlCommand("DELETE FROM [dbo].[Person]", conn)).ExecuteNonQuery();
                cmd.ExecuteNonQuery();

                conn.Close();


            }
        }
    }
}
