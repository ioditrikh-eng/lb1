using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static List<MagicalCreature> creatures = new List<MagicalCreature>();
    private static int maxCreatures = 0;

    static void Main(string[] args)
    {
        InitializeProgram();
        ShowMainMenu();
    }

    static void InitializeProgram()
    {
        Console.WriteLine("=== Magical Creatures Management System ===");
        Console.WriteLine("Welcome to the World of Magic!\n");

        maxCreatures = ReadPositiveInteger("Enter maximum number of creatures to manage (N > 0): ",
            "Invalid input! Please enter a positive integer.");

        Console.WriteLine($"Maximum creatures set to: {maxCreatures}");
    }

    static void ShowMainMenu()
    {
        while (true)
        {
            Console.WriteLine("\n=== MAIN MENU ===");
            Console.WriteLine("1 - Add magical creature");
            Console.WriteLine("2 - View all creatures");
            Console.WriteLine("3 - Find creature");
            Console.WriteLine("4 - Demonstrate magic abilities");
            Console.WriteLine("5 - Delete creature");
            Console.WriteLine("0 - Exit program");

            string choice = ReadString("Choose an option: ");

            switch (choice)
            {
                case "1": AddCreature(); break;
                case "2": ViewAllCreatures(); break;
                case "3": FindCreature(); break;
                case "4": DemonstrateAbilities(); break;
                case "5": DeleteCreature(); break;
                case "0":
                    Console.WriteLine("May the magic be with you! Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option! Choose from 0 to 5.");
                    break;
            }
        }
    }

    // Вспомогательные методы для валидации ввода
    static string ReadString(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine()!.Trim();
    }

    static int ReadInteger(string prompt, string errorMessage = "Invalid input! Please enter an integer.")
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int result))
                return result;
            Console.WriteLine(errorMessage);
        }
    }

    static int ReadPositiveInteger(string prompt, string errorMessage = "Invalid input! Please enter a positive integer.")
    {
        while (true)
        {
            int result = ReadInteger(prompt, errorMessage);
            if (result > 0)
                return result;
            Console.WriteLine(errorMessage);
        }
    }

    static double ReadDouble(string prompt, string errorMessage = "Invalid input! Please enter a number.")
    {
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out double result))
                return result;
            Console.WriteLine(errorMessage);
        }
    }

    static double ReadDoubleInRange(string prompt, double min, double max, string errorMessage = "Invalid input!")
    {
        while (true)
        {
            double result = ReadDouble(prompt, errorMessage);
            if (result >= min && result <= max)
                return result;
            Console.WriteLine($"Value must be between {min} and {max}.");
        }
    }

    static int ReadIntegerInRange(string prompt, int min, int max, string errorMessage = "Invalid input!")
    {
        while (true)
        {
            int result = ReadInteger(prompt, errorMessage);
            if (result >= min && result <= max)
                return result;
            Console.WriteLine($"Value must be between {min} and {max}.");
        }
    }

    static DateTime ReadDateTime(string prompt, string formatError = "Invalid date format! Use dd.MM.yyyy")
    {
        while (true)
        {
            Console.Write(prompt);
            if (DateTime.TryParse(Console.ReadLine(), out DateTime result))
                return result;
            Console.WriteLine(formatError);
        }
    }

    static DateTime ReadDateTimeInRange(string prompt, DateTime min, DateTime max)
    {
        while (true)
        {
            DateTime result = ReadDateTime(prompt);
            if (result >= min && result <= max)
                return result;
            Console.WriteLine($"Date must be between {min:dd.MM.yyyy} and {max:dd.MM.yyyy}.");
        }
    }

    static bool ReadYesNo(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()!.ToLower().Trim();
            if (input == "y" || input == "yes")
                return true;
            if (input == "n" || input == "no")
                return false;
            Console.WriteLine("Please enter 'y' for yes or 'n' for no.");
        }
    }

    static MagicType ReadMagicType(string prompt)
    {
        while (true)
        {
            Console.WriteLine("Available magic types: ");
            for (int i = 0; i < Enum.GetValues(typeof(MagicType)).Length; i++)
                Console.WriteLine($"- {(MagicType)i} ({i})");

            Console.Write(prompt);
            if (Enum.TryParse(Console.ReadLine(), out MagicType result) &&
                Enum.IsDefined(typeof(MagicType), result))
                return result;

            Console.WriteLine("Invalid magic type! Please enter a valid number.");
        }
    }

    static void AddCreature()
    {
        if (creatures.Count >= maxCreatures)
        {
            Console.WriteLine($"Cannot add more creatures. Maximum limit ({maxCreatures}) reached.");
            return;
        }

        Console.WriteLine("\n=== ADD NEW MAGICAL CREATURE ===");

        try
        {
           
            string name;
            while (true)
            {
                name = ReadString("Enter creature name: ");
                try
                {
                  
                    var temp = new MagicalCreature("Temp", "Temporary", 1, 1, MagicType.Fire, false, DateTime.Now, 1);
                    temp.Name = name;
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

           
            string species;
            while (true)
            {
                species = ReadString("Enter species: ");
                try
                {
                    
                    var temp = new MagicalCreature("Temp", "Temporary", 1, 1, MagicType.Fire, false, DateTime.Now, 1);
                    temp.Species = species;
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            int age = ReadIntegerInRange("Enter age (years): ", 0, 5000);
            double magicPower = ReadDoubleInRange("Enter magic power (1-1000): ", 1, 1000);
            MagicType magicType = ReadMagicType("Enter magic type number: ");
            bool canFly = ReadYesNo("Can fly? (y/n): ");
            DateTime discoveryDate = ReadDateTimeInRange(
                "Enter discovery date (dd.MM.yyyy): ",
                new DateTime(1000, 1, 1),
                DateTime.Now
            );
            int healthPoints = ReadIntegerInRange("Enter health points (1-500): ", 1, 500);

            MagicalCreature newCreature = new MagicalCreature(
                name, species, age, magicPower, magicType, canFly, discoveryDate, healthPoints);

            creatures.Add(newCreature);
            Console.WriteLine($"✨ {name} has been added to your collection! ✨");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Magic failed: {ex.Message}");
        }
    }

    static void ViewAllCreatures()
    {
        if (creatures.Count == 0)
        {
            Console.WriteLine("No magical creatures in your collection.");
            return;
        }

        Console.WriteLine("\n=== YOUR MAGICAL COLLECTION ===");
        Console.WriteLine("┌─────┬──────────────────┬──────────────────┬─────┬─────────────┬────────────┬────────┬────────────────┬──────┐");
        Console.WriteLine("│ No. │ Name             │ Species          │ Age │ Magic Power │ Magic Type │ Can Fly│ Discovery Date │ HP   │");
        Console.WriteLine("├─────┼──────────────────┼──────────────────┼─────┼─────────────┼────────────┼────────┼────────────────┼──────┤");

        for (int i = 0; i < creatures.Count; i++)
        {
            var creature = creatures[i];
            Console.WriteLine($"│ {i + 1,-3} │ {creature.Name,-16} │ {creature.Species,-16} │ {creature.Age,-3} │ {creature.MagicPower,-11:F1} │ {creature.MagicType,-10} │ {creature.CanFly,-6} │ {creature.DiscoveryDate:dd.MM.yyyy} │ {creature.HealthPoints,-4} │");
        }

        Console.WriteLine("└─────┴──────────────────┴──────────────────┴─────┴─────────────┴────────────┴────────┴────────────────┴──────┘");
    }

    static void FindCreature()
    {
        if (creatures.Count == 0)
        {
            Console.WriteLine("No creatures available for search.");
            return;
        }

        Console.WriteLine("\n=== FIND MAGICAL CREATURE ===");
        Console.WriteLine("Search by:");
        Console.WriteLine("1 - Name");
        Console.WriteLine("2 - Magic Type");
        Console.WriteLine("3 - Species");
        Console.WriteLine("4 - Flying creatures only");
        Console.WriteLine("5 - Ancient creatures (1000+ years)");

        string choice = ReadString("Choose search option: ");
        List<MagicalCreature> results = new List<MagicalCreature>();

        switch (choice)
        {
            case "1":
                string name = ReadString("Enter name to search: ");
                results = creatures.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
                break;

            case "2":
                MagicType searchType = ReadMagicType("Enter magic type number: ");
                results = creatures.Where(c => c.MagicType == searchType).ToList();
                break;

            case "3":
                string species = ReadString("Enter species to search: ");
                results = creatures.Where(c => c.Species.Contains(species, StringComparison.OrdinalIgnoreCase)).ToList();
                break;

            case "4":
                results = creatures.Where(c => c.CanFly).ToList();
                break;

            case "5":
                results = creatures.Where(c => c.IsAncient()).ToList();
                break;

            default:
                Console.WriteLine("Invalid option!");
                return;
        }

        DisplaySearchResults(results);
    }

    static void DisplaySearchResults(List<MagicalCreature> results)
    {
        if (results.Count == 0)
        {
            Console.WriteLine("No magical creatures found.");
            return;
        }

        Console.WriteLine($"\n🔮 Found {results.Count} magical creature(s):");
        Console.WriteLine("┌─────┬──────────────────┬──────────────────┬─────┬─────────────┬────────────┬────────┬────────────────┬──────┐");
        Console.WriteLine("│ No. │ Name             │ Species          │ Age │ Magic Power │ Magic Type │ Can Fly│ Discovery Date │ HP   │");
        Console.WriteLine("├─────┼──────────────────┼──────────────────┼─────┼─────────────┼────────────┼────────┼────────────────┼──────┤");

        for (int i = 0; i < results.Count; i++)
        {
            var creature = results[i];
            Console.WriteLine($"│ {i + 1,-3} │ {creature.Name,-16} │ {creature.Species,-16} │ {creature.Age,-3} │ {creature.MagicPower,-11:F1} │ {creature.MagicType,-10} │ {creature.CanFly,-6} │ {creature.DiscoveryDate:dd.MM.yyyy} │ {creature.HealthPoints,-4} │");
        }

        Console.WriteLine("└─────┴──────────────────┴──────────────────┴─────┴─────────────┴────────────┴────────┴────────────────┴──────┘");
    }

    static void DemonstrateAbilities()
    {
        if (creatures.Count == 0)
        {
            Console.WriteLine("No creatures available for demonstration.");
            return;
        }

        Console.WriteLine("\n=== DEMONSTRATE MAGIC ABILITIES ===");
        ViewAllCreatures();

        int creatureNumber = ReadIntegerInRange("Select creature number to demonstrate: ", 1, creatures.Count);
        MagicalCreature selectedCreature = creatures[creatureNumber - 1];

        Console.WriteLine($"\n✨ Magic abilities of {selectedCreature.Name} ✨");
        Console.WriteLine("1 - Calculate battle power");
        Console.WriteLine("2 - Get creature info");
        Console.WriteLine("3 - Check if ancient");
        Console.WriteLine("4 - Train creature");
        Console.WriteLine("5 - Heal creature");
        Console.WriteLine("6 - Evolve creature");

        string choice = ReadString("Choose action: ");

        try
        {
            switch (choice)
            {
                case "1":
                    int opponentLevel = ReadIntegerInRange("Enter opponent level (1-100): ", 1, 100);
                    double battlePower = selectedCreature.CalculateBattlePower(opponentLevel);
                    Console.WriteLine($"⚔️  Battle power: {battlePower:F2}");
                    break;

                case "2":
                    Console.WriteLine($"📜 Creature info: {selectedCreature.GetCreatureInfo()}");
                    break;

                case "3":
                    bool isAncient = selectedCreature.IsAncient();
                    Console.WriteLine($"🏛️  Is ancient: {isAncient}");
                    break;

                case "4":
                    double hours = ReadDoubleInRange("Enter training hours (0.5-24): ", 0.5, 24);
                    selectedCreature.Train(hours);
                    break;

                case "5":
                    int healingPoints = ReadIntegerInRange("Enter healing points (1-100): ", 1, 100);
                    selectedCreature.Heal(healingPoints);
                    break;

                case "6":
                    selectedCreature.Evolve();
                    break;

                default:
                    Console.WriteLine("Invalid action!");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Magic failed: {ex.Message}");
        }
    }

    static void DeleteCreature()
    {
        if (creatures.Count == 0)
        {
            Console.WriteLine("No creatures available to delete.");
            return;
        }

        Console.WriteLine("\n=== DELETE MAGICAL CREATURE ===");
        Console.WriteLine("Delete by:");
        Console.WriteLine("1 - Number in list");
        Console.WriteLine("2 - Name");
        Console.WriteLine("3 - Species");

        string choice = ReadString("Choose delete option: ");
        int deletedCount = 0;

        switch (choice)
        {
            case "1":
                ViewAllCreatures();
                int number = ReadIntegerInRange("Enter creature number to delete: ", 1, creatures.Count);
                string name = creatures[number - 1].Name;
                creatures.RemoveAt(number - 1);
                deletedCount = 1;
                Console.WriteLine($"✨ {name} has returned to the magical realm! ✨");
                break;

            case "2":
                string nameToDelete = ReadString("Enter name to delete: ");
                deletedCount = creatures.RemoveAll(c => c.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));
                Console.WriteLine($"✨ {deletedCount} creature(s) named '{nameToDelete}' returned to the magical realm! ✨");
                break;

            case "3":
                string species = ReadString("Enter species to delete: ");
                deletedCount = creatures.RemoveAll(c => c.Species.Equals(species, StringComparison.OrdinalIgnoreCase));
                Console.WriteLine($"✨ {deletedCount} {species} creature(s) returned to the magical realm! ✨");
                break;

            default:
                Console.WriteLine("Invalid option!");
                return;
        }

        if (deletedCount == 0)
            Console.WriteLine("No creatures were deleted.");
    }
}