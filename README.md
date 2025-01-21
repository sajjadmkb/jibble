# Jibble - OData People Console App

Jibble is a C# console application that interacts with an OData service to manage employee data. The app can:
- List people
- Search/Filter people by name
- Show details of a specific person

## Setup Instructions

1. Clone the repository to your local machine.
2. Open the project in Visual Studio.
3. Restore the NuGet packages.
4. Run the application.

## Commands
- `list` - Lists all people.
- `search <name>` - Lists people matching the search term in their first or last name.
- `show <employeeId>` - Shows the details of the employee with the given ID.
- `exit` - Close the application.

## Running Tests

To run the tests, use the following command:
```bash
dotnet test
