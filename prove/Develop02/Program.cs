using System;
 
 namespace JournalApp
 {
    class Program
    {
        private static Timer reminderTimer;
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        setDailyReminder(() => Console.WriteLine(" Hello, don't forget to write in your journal today!"));
        while (true)
        {
            //display the menu
            Console.WriteLine("\n WELCOME TO MY JOURNAL! ");

            Console.WriteLine("\n Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.WriteLine("What would you like to do today?");
            Console.Write("Please SEELECT an option: ");
            string userChoice = Console.ReadLine();
            //Handled user choice
            switch (userChoice)
            {
                case "1":
                        journal.AddEntry();
                        break;
                    case "2":
                        journal.DisplayEntries();
                        break;
                    case "3":
                        Console.Write("Enter filename to save: ");
                        string saveFilename = Console.ReadLine();
                        journal.SaveToFile(saveFilename);
                        break;
                    case "4":
                        Console.Write("Enter filename to load: ");
                        string loadFilename = Console.ReadLine();
                        journal.LoadFromFile(loadFilename);
                        break;
                    case "5":
                        Console.WriteLine("Goodbye! Have a Nice Day!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
            }

            }
        }
        //Exceeding Requirement. 
        //I added method to set daily reminder at 9 am every day.
        static void setDailyReminder(Action reminderAction)
        {
            TimeSpan timeToGo = DateTime.Today.AddDays(1).AddHours(9) - DateTime.Now;
            if (timeToGo < TimeSpan.Zero)
            {
                timeToGo = TimeSpan.Zero;
            }
            reminderTimer = new Timer(x =>
            {
                reminderAction.Invoke();

            }, null, timeToGo, TimeSpan.FromHours(24));
        }
    }
}  


            

        
    
