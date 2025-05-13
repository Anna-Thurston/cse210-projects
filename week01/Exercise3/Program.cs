using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int magicNumber = random.Next(1, 101);

        int guess = 0;

        Console.WriteLine("I'm thinking of a number between 1 and 100.");


        while (guess != magicNumber)
        {
            Console.Write("Guess the magic number: ");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Too low! Try guessing higher.");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Too high! Try guessing lower.");
            }
            else
            {
                Console.WriteLine("You guessed it! Great job!");
            }
        }
    }
}