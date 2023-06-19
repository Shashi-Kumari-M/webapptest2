using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    public interface IPhoneBook
    {
         Task<Person> findPerson(string firstName, string lastName);
        void addPerson(Person newPerson);
    }
}