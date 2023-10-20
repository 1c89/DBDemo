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

        public void Add(Person p)
        {
            using (var conn = new SqlConnection(connectionString))

            {

                var cmd = new SqlCommand();
                cmd.CommandText = $"INSERT INTO [dbo].[Person] VALUES(@fn,@ln,@email)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@fn", p.FirstName);
                cmd.Parameters.AddWithValue("@ln", p.LastName);
                cmd.Parameters.AddWithValue("@email", p.Email);
 
                conn.Open();

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

        public IEnumerable<Person> GetAll()
        {
            using (var conn = new SqlConnection(connectionString))

            {

                conn.Open();

                SqlDataReader r = new SqlCommand("SELECT * FROM[dbo].[Person]",conn).ExecuteReader();

                var persons = new List<Person>();

                while (r.Read())
                {
                    persons.Add(new Person
                    {
                        Id = (int)r["Id"],
                        FirstName = (string)r["FirstName"],
                        LastName = (string)r["LastName"],
                        Email = (string)r["Email"]
                    });
                }
                
                conn.Close();
                
                return persons;


            }
        }

        public Person Get(int id)
        {
            using (var conn = new SqlConnection(connectionString))

            {

                var cmd = new SqlCommand();
                cmd.CommandText = "SELECT ( FROM [dbo].[Person] WHERE [id]=@id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = conn;

                conn.Open();

                var r = (SqlDataReader)cmd.ExecuteReader();

                conn.Close();

                return new Person
                {
                    Id = (int)r["Id"],
                    FirstName = (string)r["FirstName"],
                    LastName = (string)r["LastName"],
                    Email = (string)r["Email"]
                };

            }
        }

        public void Update(int id, Person p)
        {
            if (p.Id != id)
                throw new Exception("Update integrity violation");

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
                cmd.Parameters.AddWithValue("@fn", p.FirstName);
                cmd.Parameters.AddWithValue("@ln", p.LastName);
                cmd.Parameters.AddWithValue("@email", p.Email);
                cmd.Connection = conn;

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();


            }
        }
    }
}
