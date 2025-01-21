using System;
using System.Linq;
using Jibble.Data.Models;
using Microsoft.OData.Client;


namespace Jibble.Data
{
    public class JibbleClient
    {
        private readonly DataServiceContext _context;

        public JibbleClient(string serviceUrl)
        {
            _context = new DataServiceContext(new Uri(serviceUrl));
        }

        
        public IQueryable<Person> GetPeople()
        {
            return _context.CreateQuery<Person>("Employees");
        }
    }
}
