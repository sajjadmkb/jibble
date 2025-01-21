using Jibble.Data;
using Jibble.Data.Models;
using System;
using System.Linq;

namespace Jibble.Services
{
    public class PersonService
    {
        private readonly JibbleClient _client;

        public PersonService(JibbleClient client)
        {
            _client = client;
        }

        public IEnumerable<Person> ListPeople(string searchTerm = "")
        {
            var peopleQuery = _client.GetPeople();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                peopleQuery = peopleQuery.Where(p => p.FirstName.Contains(searchTerm) || p.LastName.Contains(searchTerm));
            }

            IEnumerable<Person> p = peopleQuery.ToList();

            foreach (var person in p)
            {
                Console.WriteLine($"{person.EmployeeID}: {person.FirstName} {person.LastName}");
            }
            return p;
        }

        public Person ShowPersonDetails(int employeeId)
        {

            var person = _client.GetPeople().Where(x => x.EmployeeID == employeeId).FirstOrDefault();

            if (person != null)
            {
                Console.WriteLine($"Employee ID: {person.EmployeeID}");
                Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
                Console.WriteLine($"Title: {person.Title}");
            }
            else
            {
                Console.WriteLine("Person not found.");
            }
            return person;
        }
    }
}
