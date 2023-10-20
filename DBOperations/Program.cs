// See https://aka.ms/new-console-template for more information
using System;

namespace DBOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string cs = "Server = (localdb)\\MSSQLLocalDB; Database= HumberDB; Integrated security = true";
            int id;

            PersonRepository repo = new PersonRepository(cs);

            repo.DeleteAll();

            repo.Add("Test", "User", "a@a.com");
            repo.Add("O", "R", "a@a.com");

            Console.Write("Enter id to UPDATE");
            id = Convert.ToInt32(Console.ReadLine());
            repo.Update(id,"f_____n","l_____n","e@e.com");

            Console.Write("Enter id to DELETE");
            id = Convert.ToInt32(Console.ReadLine());
            repo.Delete(id);
            /*var d = repo.GetAll();
            foreach (var item in d)
            {
                Console.WriteLine(item);
            }*/

        }


    }

}