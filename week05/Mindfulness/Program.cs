// Exceeded requirements by adding a log of how many times activities were performed.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var breathing = new BreathingActivity(
            "Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
        );

        var reflectingPrompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        var reflectingQuestions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        var reflecting = new ReflectingActivity(
            "Reflecting",
            "This activity will help you reflect on times in your life when you have shown strength and resilience.",
            reflectingPrompts,
            reflectingQuestions
        );

        var listingPrompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        var listing = new ListingActivity(
            "Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
            listingPrompts
        );

        int choice = 0;
        while (choice != 4)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        breathing.Run();
                        break;
                    case 2:
                        reflecting.Run();
                        break;
                    case 3:
                        listing.Run();
                        break;
                    case 4:
                        Console.WriteLine("\nGoodbye!");
                        Activity.ShowActivityLog(); // Show the log when quitting
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a number.");
            }

            if (choice != 4)
            {
                Console.WriteLine("\nPress Enter to return to the menu.");
                Console.ReadLine();
            }
        }
    }
}
