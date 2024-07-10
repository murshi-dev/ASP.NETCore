using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
}

public class Program
{
    public static void Main()
    {
        // Question 1: Create a list of people
        List<Person> people = new List<Person>
        {
            new Person { Name = "Alice", Age = 25, City = "New York" },
            new Person { Name = "Bob", Age = 30, City = "Los Angeles" },
            new Person { Name = "Charlie", Age = 28, City = "Chicago" },
            new Person { Name = "David", Age = 22, City = "New York" }
        };

        // Question 2: LINQ query to print names and cities of people older than 25
        var result = people
            .Where(person => person.Age > 25)
            .Select(person => new { person.Name, person.City });

        Console.WriteLine("People older than 25:");
        foreach (var person in result)
        {
            Console.WriteLine($"Name: {person.Name}, City: {person.City}");
        }

        // Question 3: LINQ query to sort people by age in descending order
        var peopleSortedByAgeDesc = people
            .OrderByDescending(person => person.Age)
            .ToList();

        Console.WriteLine("\nPeople sorted by age (descending):");
        foreach (var person in peopleSortedByAgeDesc)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, City: {person.City}");
        }

        // Additional Query 1: Group people by city and print the number of people in each city
        var peopleGroupedByCity = people
            .GroupBy(person => person.City)
            .Select(group => new { City = group.Key, Count = group.Count() });

        Console.WriteLine("\nNumber of people in each city:");
        foreach (var group in peopleGroupedByCity)
        {
            Console.WriteLine($"City: {group.City}, Count: {group.Count}");
        }

        // Additional Query 2: Find the person with the minimum age
        var youngestPerson = people
            .OrderBy(person => person.Age)
            .FirstOrDefault();

        if (youngestPerson != null)
        {
            Console.WriteLine($"\nYoungest person: Name: {youngestPerson.Name}, Age: {youngestPerson.Age}, City: {youngestPerson.City}");
        }
    }
}
