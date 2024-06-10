using System;

class Program
{
    static void Main(string[] args)
    {
        
        Random randomGenerator = new Random();

        bool play = true;
        while (play)
        {
        int magicNumber = randomGenerator.Next(1, 101);

        int guessCount = 0;
        
        bool correctGuessed = false;
        while (!correctGuessed)

        {
            Console.Write("What is your Guess? ");
            string input = Console.ReadLine();

            int guess;
            if (!int.TryParse(input, out guess))
            {
                Console.WriteLine("Invalid Input. Please enter a valid number. ");
                continue;
            }
            guessCount++;

            if (guess < magicNumber) 
            {
            Console.WriteLine("Higher");

            }

            else if (guess > magicNumber)
            {
            Console.WriteLine("Lower ");

            }
            else
            {
            Console.WriteLine("Congratulations! You guess it. ");
            correctGuessed = true;

            }
        }

        //Display the number of guessed count.
        Console.WriteLine($"Your guessed number is: {guessCount} guesses ");

        //Ask if the user wants to play again.
        Console.Write("Do you want to play again? ");
        string response = Console.ReadLine().ToLower();
        if (response != "yes")
        {
            play = false;
        }
        
    }
    // End the Game.
    Console.WriteLine("Thank you for playing! ");

    }
}