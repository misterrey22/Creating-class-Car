using System;

public class Person
{
    // Fields
    private string name;
    private DateTime birthYear;

    // Properties
    public string Name
    {
        get { return name; }
    }

    public DateTime BirthYear
    {
        get { return birthYear; }
    }

    // Constructors
    public Person()
    {
        // Default constructor
    }

    public Person(string name, DateTime birthYear)
    {
        this.name = name;
        this.birthYear = birthYear;
    }

    // Methods
    public int Age()
    {
        return DateTime.Now.Year - birthYear.Year;
    }

    public void Input()
    {
        Console.WriteLine("Enter person details:");
        Console.Write("Name: ");
        name = Console.ReadLine();

        Console.Write("Birth Year: ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime enteredBirthYear))
        {
            birthYear = enteredBirthYear;
        }
        else
        {
            Console.WriteLine("Invalid input for birth year. Defaulting to current year.");
            birthYear = DateTime.Now;
        }
    }

    public void ChangeName(string newName)
    {
        name = newName;
    }

    public override string ToString()
    {
        return $"Name: {name}, Birth Year: {birthYear.Year}";
    }

    public void Output()
    {
        Console.WriteLine(ToString());
    }

    public static bool operator ==(Person person1, Person person2)
    {
        return person1.name == person2.name;
    }

    public static bool operator !=(Person person1, Person person2)
    {
        return person1.name != person2.name;
    }
}

class Program
{
    static void Main()
    {
        Person[] people = new Person[6];

        for (int i = 0; i < people.Length; i++)
        {
            people[i] = new Person();
            people[i].Input();
        }

        Console.WriteLine("\nName and Age of each person:");
        for (int i = 0; i < people.Length; i++)
        {
            Console.WriteLine($"{people[i].Name}: {people[i].Age()} years old");
        }

        Console.WriteLine("\nChanging names of people younger than 16 to 'Very Young':");
        for (int i = 0; i < people.Length; i++)
        {
            if (people[i].Age() < 16)
            {
                people[i].ChangeName("Very Young");
            }
        }

        Console.WriteLine("\nInformation about all people after changes:");
        for (int i = 0; i < people.Length; i++)
        {
            people[i].Output();
        }

        Console.WriteLine("\nPeople with the same names:");
        for (int i = 0; i < people.Length; i++)
        {
            for (int j = i + 1; j < people.Length; j++)
            {
                if (people[i] == people[j])
                {
                    Console.WriteLine($"{people[i].Name} has the same name as {people[j].Name}");
                }
            }
        }
    }
}