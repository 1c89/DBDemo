using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBOperations
{
    internal interface IRepo
    {
        void Add(Person p);
        void Update(int id, Person P);
        void Delete(int id);
        void DeleteAll();

        IEnumerable<Person> GetAll();
        Person Get(int id);

    }
}
