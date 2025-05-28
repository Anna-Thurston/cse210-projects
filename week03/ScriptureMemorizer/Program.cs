// Exceeds requirements by randomly selecting a scripture from a list.
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // A list of scriptures
        List<Scripture> scriptures = new List<Scripture>();

        // Add scriptures
        scriptures.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, " +
            "that whosoever believeth in him should not perish, but have everlasting life."));

        scriptures.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
            "In all thy ways acknowledge him, and he shall direct thy paths."));

        scriptures.Add(new Scripture(
            new Reference("2 Nephi", 2, 25),
            "Adam fell that men might be; and men are, that they might have joy."));

        // Randomly select a scripture
        Random random = new Random();
        int randomIndex = random.Next(scriptures.Count);
        Scripture selectedScripture = scriptures[randomIndex];

        // Main loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            selectedScripture.HideRandomWords(1);

            if (selectedScripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(selectedScripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program will now end.");
                break;
            }
        }
    }
}
