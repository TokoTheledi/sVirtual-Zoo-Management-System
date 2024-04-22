using System;
using System.Collections.Generic;

interface IFeedable
{
    string Feed(string food);
}

interface IMovable
{
    void Move();
}

class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public virtual string Eat()
    {
        return "Animal Food";
    }

    public virtual bool Sleep()
    {
        return true;
    }

    public virtual string Speak()
    {
        return "Animal Sounds";
    }
}

class Lion : Animal, IFeedable, IMovable
{
    public Lion(string name, int age) : base()
    {
        Name = name;
        Age = age;
    }

    public string Feed(string food)
    {
        return $"Eats {food}";
    }

    public void Move()
    {
        Console.WriteLine("Lion walks");
    }

    public override bool Sleep()
    {
        return true;
    }

    public override string Speak()
    {
        return "Roars";
    }
}

class Parrot : Animal, IFeedable, IMovable
{
    public Parrot(string name, int age) : base()
    {
        Name = name;
        Age = age;
    }

    public string Feed(string food)
    {
        return $"Eats {food}";
    }

    public void Move()
    {
        Console.WriteLine("Parrot flies");
    }

    public override bool Sleep()
    {
        return false;
    }

    public override string Speak()
    {
        return "Squeaks";
    }
}

class Turtle : Animal, IFeedable, IMovable
{
    public Turtle(string name, int age) : base()
    {
        Name = name;
        Age = age;
    }

    public string Feed(string food)
    {
        return $"Eats {food}";
    }

    public void Move()
    {
        Console.WriteLine("A Turtle crawls");
    }

    public override bool Sleep()
    {
        return true;
    }

    public override string Speak()
    {
        return "Chirps";
    }
}

class Zoo
{
    private List<Animal> animals = new List<Animal>();

    public void AddAnimal(Animal animal)
    {
        animals.Add(animal);
        Console.WriteLine($"{animal.Name} added to the zoo.");
    }

    public void FeedAnimals(string food)
    {
        foreach (var animal in animals)
        {
            if (animal is IFeedable feedable)
            {
                Console.WriteLine($"{animal.Name}: {feedable.Feed(food)}");
            }
        }
    }

    public void FeedAnimal(string animalName, string food)
    {
        var animal = animals.Find(a => a.Name == animalName);
        if (animal is IFeedable feedable)
        {
            Console.WriteLine($"{animal.Name}: {feedable.Feed(food)}");
        }
        else
        {
            Console.WriteLine($"Cannot feed {animalName}. Not feedable.");
        }
    }

    public void DisplayAnimals()
    {
        Console.WriteLine("All Animals in the Zoo:");
        foreach (var animal in animals)
        {
            Console.WriteLine($"Name: {animal.Name}, Age: {animal.Age}");
            Console.WriteLine($"Eating: {animal.Eat()}");
            Console.WriteLine($"Sleeping: {animal.Sleep()}");
            Console.WriteLine($"Speaking: {animal.Speak()}");
        }
    }

    public void MoveAnimal(string animalName)
    {
        var animal = animals.Find(a => a.Name == animalName);
        if (animal is IMovable movable)
        {
            movable.Move();
        }
        else
        {
            Console.WriteLine($"Cannot move {animalName}. Not movable.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Zoo zoo = new Zoo();
        string choice;

        do
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Add an animal");
            Console.WriteLine("2. Feed all animals");
            Console.WriteLine("3. Feed a specific animal");
            Console.WriteLine("4. Display all animals");
            Console.WriteLine("5. Move an animal");
            Console.WriteLine("6. Exit");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddAnimal(zoo);
                    break;
                case "2":
                    Console.Write("Enter food to feed all animals: ");
                    string food = Console.ReadLine();
                    zoo.FeedAnimals(food);
                    break;
                case "3":
                    FeedAnimal(zoo);
                    break;
                case "4":
                    zoo.DisplayAnimals();
                    break;
                case "5":
                    MoveAnimal(zoo);
                    break;
                case "6":
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (choice != "6");
    }

    static void AddAnimal(Zoo zoo)
    {
        Console.Write("Enter animal species (Lion/Parrot/Turtle): ");
        string species = Console.ReadLine();
        Console.Write("Enter animal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter animal age: ");
        int age = int.Parse(Console.ReadLine());

        switch (species.ToLower())
        {
            case "lion":
                zoo.AddAnimal(new Lion(name, age));
                break;
            case "parrot":
                zoo.AddAnimal(new Parrot(name, age));
                break;
            case "turtle":
                zoo.AddAnimal(new Turtle(name, age));
                break;
            default:
                Console.WriteLine("Invalid species.");
                break;
        }
    }

    static void FeedAnimal(Zoo zoo)
    {
        Console.Write("Enter animal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter food to feed: ");
        string food = Console.ReadLine();

        zoo.FeedAnimal(name, food);
    }

    static void MoveAnimal(Zoo zoo)
    {
        Console.Write("Enter animal name: ");
        string name = Console.ReadLine();
        zoo.MoveAnimal(name);
    }
}
