// Included dynamic filename capability for saving and loading entries.
// Used encapsulation for prompt generator and file loading.

using System;

public class Program
{
    public static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool keepGoing = true;
        while (keepGoing)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetPrompt();
                Console.WriteLine("\nPrompt: " + prompt);
                Console.Write("Your response: ");
                string response = Console.ReadLine();
                Entry entry = new Entry(prompt, response);
                journal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                Console.WriteLine("\nJournal Entries:");
                journal.ShowEntries();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename to save: ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
                Console.WriteLine("Saved.");
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to load: ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
                Console.WriteLine("Loaded.");
            }
            else if (choice == "5")
            {
                keepGoing = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }
}
