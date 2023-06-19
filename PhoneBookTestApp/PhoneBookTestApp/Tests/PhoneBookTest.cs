using NUnit.Framework;
using PhoneBookTestApp;
using Moq;
using System.Threading.Tasks;
using System.Data;

namespace PhoneBookTestAppTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class PhoneBookTest
    {
        private PhoneBook _phoneBook;
        private Mock<IDalService> _dalService;
        [SetUp]
        public void Initialize()
        {
            _dalService = new Mock<IDalService>();
            _phoneBook = new PhoneBook(new DalService());
        }
        [Test]
        public void addPerson()
        {
            var newPersonEnity = new Person()
            {
                name = "Clarivate",
                address = "India",
                phoneNumber = "(111) 111-111 "
            };
            var dalRes = _dalService.Setup(x => x.InsertRecord(It.IsAny<Person>())).Returns(It.IsAny<Task<int>>());
            _phoneBook.addPerson(newPersonEnity);
            Assert.IsTrue(true);
        }

        [Test]
        public void findPerson()
        {
            var ActualResult = new Person()
            {
                name = "ftest ltest",
                address = "India",
                phoneNumber = "(111) 111-111 "
            };

            var lastName = "ftest";
            var firstName = "ltest";
            var dalRes = _dalService.Setup(x => x.GetRecord(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<Task<DataTable>>());
            var expectedResult =   _phoneBook.findPerson(firstName, lastName );
            Assert.AreSame(expectedResult, ActualResult);
        }
    }

    // ReSharper restore InconsistentNaming 
}