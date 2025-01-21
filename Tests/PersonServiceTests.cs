using Jibble.Data;
using Jibble.Services;
using System.Linq;
using Xunit;

namespace Jibble.Tests
{
    public class PersonServiceTests
    {
        private readonly PersonService _service;

        public PersonServiceTests()
        {
            var client = new JibbleClient("https://services.odata.org/V4/Northwind/Northwind.svc/");
            _service = new PersonService(client);
        }

        [Fact]
        public void TestListPeople_ReturnsNonEmptyList()
        {
            var output = _service.ListPeople(null);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void TestShowPersonDetails_ReturnsCorrectPerson()
        {
            var person = _service.ShowPersonDetails(1);
            Assert.Equal(1, person.EmployeeID);
        }
    }
}
