using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq;

namespace PhoneBookTestApp
{
    public class PhoneBook: IPhoneBook
    {
        private readonly IDalService _dalService;
        public PhoneBook(IDalService dalService)
        {
            _dalService = dalService;
        }

        public void addPerson(Person person)
        {
            try
            {
                if (person.IsValid)
                {
                    var dataTable = _dalService.InsertRecord(person).GetAwaiter().GetResult();
                }
                else
                {
                    throw new ArgumentNullException(nameof(person));
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Some error occurred while saving  the data = ", ex.Message);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Some error occurred while saving the data = ", ex.Message);
            }
        }

        public async Task<Person> findPerson(string firstName, string lastName)
        {
            Person personEntity = new Person();
            try
            {
                var dataTable = await _dalService.GetRecord(firstName, lastName);
                personEntity = (from DataRow row in dataTable.Rows
                                                    select new Person
                                                    {
                                                        name = row["NAME"].ToString(),
                                                        address = row["ADDRESS"].ToString(),
                                                        phoneNumber = row["PHONENUMBER"].ToString()

                                                    }).FirstOrDefault();

                return personEntity;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Some error occurred while fetching the data = ", ex.Message);
            }
            return personEntity;
        }
    }
}