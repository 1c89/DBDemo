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
            Person p1 = new Person()
            {
                FirstName = "Test",
                LastName = "User",
                Email = "a@a.com"
            };

            Person p2 = new Person()
            {
                FirstName = "O",
                LastName = "R",
                Email = "b@b.co"
            };

            repo.Add(p1);
            repo.Add(p2);

            var Persons = repo.GetAll();

            Display(Persons);

            Console.Write("Enter id to UPDATE:");
            id = Convert.ToInt32(Console.ReadLine());
            repo.Update(id, new Person() {Id = id, FirstName = "f_____n", LastName = "l_____n", Email = "e@e.com" });
            
            Persons = repo.GetAll();
            Display(Persons);

            Console.Write("Enter id to DELETE:");
            id = Convert.ToInt32(Console.ReadLine());
            repo.Delete(id);
            
            Persons = repo.GetAll();
            Display(Persons);

        }

        private static void Display(IEnumerable<Person> Persons)
        {
            foreach (Person item in Persons)
            {
                DisplayPerson(item);
            }
        }

        private static void DisplayPerson(Person item)
        {
            Console.WriteLine($"{item.Id} {item.FirstName} {item.LastName} {item.Email}");
        }
    }

}