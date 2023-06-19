using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    //class Program
    //{
    //    private static readonly PhoneBook _phonebook = new PhoneBook();
    //    static List<Person> PersonDetails()
    //    {
    //        var personEnity = new List<Person>()
    //        {
    //            new Person()
    //            {
    //              name=  "John Smith",
    //              address="1234 Sand Hill Dr, Royal Oak, MI",
    //              phoneNumber="(248) 123-4567 "
    //            },
    //             new Person()
    //            {
    //              name=  "Cynthia Smith",
    //              address="Sand Hill Dr, Royal Oak, MI",
    //              phoneNumber="875 Main St, Ann Arbor, MI"
    //            }
    //        };
    //        return personEnity;
    //    }

    //    static void Main(string[] args)
    //    {
    //        try
    //        {
    //            DatabaseUtil.CleanUp();
    //            DatabaseUtil.initializeDatabase();

    //            /* TODO: create person objects and put them in the PhoneBook and database
    //            * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
    //            * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
    //            */
    //            var personEnity = PersonDetails();
    //            foreach (var item in personEnity)
    //            {
    //                _phonebook.addPerson(item);
    //            }

    //            // TODO: print the phone book out to System.out
    //            Console.WriteLine("Phonebook  = " + _phonebook);

    //            // TODO: find Cynthia Smith and print out just her entry
    //            var person = _phonebook.findPerson("Cynthia", "Smith").GetAwaiter().GetResult();
    //            if (person != null)
    //            {
    //                Console.WriteLine("\n" + person.name);
    //                Console.WriteLine("\n" + person.phoneNumber);
    //                Console.WriteLine("\n" + person.address);
    //            }
    //            else
    //            {
    //                Console.WriteLine("\n" + "No Records found");
    //            }

    //            // TODO: insert the new person objects into the database
    //            var newPersonEnity = new Person()
    //            {
    //                name = "Clarivate",
    //                address = "India",
    //                phoneNumber = "(111) 111-111 "
    //            };
    //            _phonebook.addPerson(newPersonEnity);

    //        }
    //        finally
    //        {
    //            DatabaseUtil.CleanUp();
    //        }
    //    }
    //}

    class Program
    {
        public static void Main(string[] args)
        {
            var dalInstance = new DalService();
            var pbInstance = new PhoneBook(dalInstance);
            var program = new MyProgram(dalInstance, pbInstance);
            program.performService();
        }
    }

    public  class MyProgram
    {
        private  readonly IDalService _dalService;
        private readonly IPhoneBook _phoneBook;
        public  MyProgram(IDalService dalService, IPhoneBook phonebook)
        {
            _dalService = dalService;
            _phoneBook = phonebook;
        }
        public void performService()
        {
            try { 
                DatabaseUtil.CleanUp();
                DatabaseUtil.initializeDatabase();

                /* TODO: create person objects and put them in the PhoneBook and database
                * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                */
                var personEnity = PersonDetails();
                foreach (var item in personEnity)
                {
                    _phoneBook.addPerson(item);
                }

                // TODO: print the phone book out to System.out
                Console.WriteLine("Phonebook  = " + _phoneBook);

                // TODO: find Cynthia Smith and print out just her entry
                var person = _phoneBook.findPerson("Cynthia", "Smith").GetAwaiter().GetResult();
                if (person != null)
                {
                    Console.WriteLine("\n" + person.name);
                    Console.WriteLine("\n" + person.phoneNumber);
                    Console.WriteLine("\n" + person.address);
                }
                else
                {
                    Console.WriteLine("\n" + "No Records found");
                }

                // TODO: insert the new person objects into the database
                var newPersonEnity = new Person()
                {
                    name = "Clarivate",
                    address = "India",
                    phoneNumber = "(111) 111-111 "
                };
                _phoneBook.addPerson(newPersonEnity);

            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }
          
static List<Person> PersonDetails()
        {
            var personEnity = new List<Person>()
            {
                new Person()
                {
                  name=  "John Smith",
                  address="1234 Sand Hill Dr, Royal Oak, MI",
                  phoneNumber="(248) 123-4567 "
                },
                 new Person()
                {
                  name=  "Cynthia Smith",
                  address="Sand Hill Dr, Royal Oak, MI",
                  phoneNumber="875 Main St, Ann Arbor, MI"
                }
            };
            return personEnity;
        }
    }
}
