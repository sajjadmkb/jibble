using System;
using Jibble.Data;
using Jibble.Services;

namespace Jibble
{
    class Program
    {
        static void Main(string[] args)
        {
            var jibbleClient = new JibbleClient("https://services.odata.org/V4/Northwind/Northwind.svc/");
            var personService = new PersonService(jibbleClient);
            while (true)
            {
                Console.WriteLine("Enter a command:");
                var command = Console.ReadLine() ?? "";

                if (command == "list")
                {
                    personService.ListPeople();
                }
                else if (command.StartsWith("search"))
                {
                    var searchTerm = command.Split(" ")[1];
                    personService.ListPeople(searchTerm);
                }
                else if (command.StartsWith("show"))
                {
                    int.TryParse(command.Split(" ")[1], out int employeeId);
                    personService.ShowPersonDetails(employeeId);
                }
                else if(command.Contains("exit") || command.Contains("quit"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid command: " + command);
                }
            }
        }
    }
}
