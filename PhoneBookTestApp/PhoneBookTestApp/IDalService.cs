using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
   public interface IDalService
    {
        Task<DataTable> GetRecord(string firstName, string lastName);
        Task<int> InsertRecord(Person person);
    }
}
