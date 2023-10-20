using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBOperations
{
    internal interface IRepo
    {
        void Add(string fn, string ln, string email);
        void Update(int id, string fn, string ln, string email);
        void Delete(int id);
        void DeleteAll();

        IEnumerable<string> GetAll();
        string GetAll(int id);

    }
}
