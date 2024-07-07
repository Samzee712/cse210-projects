using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Mindfulness Session \n ");

        bool running = true;
        while (running)
        {   
            
            Console.WriteLine("Menu Options: \n");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity");
            Console.WriteLine("5. Exit");
            
            Console.Write("Please Choose an activity to begin: ");

            int choice = int.Parse(Console.ReadLine());

            Activity activity = choice switch
            {
                1 => new BreathingActivity(),
                2 => new ReflectingActivity(),
                3 => new ListingActivity(),
                4 => new GratitudeActivity(),
                5 => null,
                _ => throw new InvalidOperationException("Invalid choice")
            };

            if (choice == 5)
            {
                running = false;
                Console.WriteLine("Goodbye!");
            }
            else
            {
                activity.Run();
            }
        }
    }
}

// Exceed requirements:
// - Added another kind of activity
// Gratitude Activity
// Make sure not to repeat any prompts until all the prompts have been used.
