// Exceeded requirements by adding progress and negative goals.

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine($"\nYour current score is: {manager.GetScore()}");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    manager.CreateGoal();
                    break;
                case 2:
                    manager.ListGoals();
                    break;
                case 3:
                    manager.SaveGoals();
                    break;
                case 4:
                    manager.LoadGoals();
                    break;
                case 5:
                    manager.RecordEvent();
                    Console.WriteLine($"Your updated score is: {manager.GetScore()}");
                    break;
                case 6:
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose from 1 to 6.");
                    break;
            }
        }
    }
}
