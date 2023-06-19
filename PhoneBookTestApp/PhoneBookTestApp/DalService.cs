using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
  public  class DalService: BaseRepository, IDalService
    {
        public Task<DataTable> GetRecord(string firstName,string lastName)
        {

            var parameters = new SQLiteParameter[]
            {
                   new SQLiteParameter("@name", $"%{firstName} {lastName}%")
             };

            string commandText = "SELECT * FROM PHONEBOOK  WHERE NAME LIKE @name LIMIT 1";
            var response = GetRecordAsync( commandText,  parameters);
            return response;
        }
        public Task<int> InsertRecord(Person person)
        {
            string commandText = "INSERT INTO  PHONEBOOK (" +
                            "NAME, PHONENUMBER, ADDRESS" +
                            ") SELECT '" +
                            person.name + "'" +
                            ",'" + person.phoneNumber + "'" +
                            ",'" + person.address + "" +
                            "'" +
                            " WHERE NOT EXISTS ( SELECT * FROM PHONEBOOK WHERE NAME = '" + person.name + "')";
            var parameters = new SQLiteParameter[]
              {
                            new SQLiteParameter("@name", person.name),
                            new SQLiteParameter("@phoneNumber", person.phoneNumber),
                            new SQLiteParameter("@address", person.address),
              };
            var response = ExecuteDataFromQuery(commandText, parameters);
            return response;
        }
    }
}
