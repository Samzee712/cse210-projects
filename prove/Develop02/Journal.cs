using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{   //Journal class to manage a collection of journal entries
    public class Journal
    {
        //Create a list to store the  journal entries and prompts
        private List<Entry> entries = new List<Entry>();
        private List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "How do I feel about my day?",
            "What can I do when I feel sad?",
            "What is my best moment with my friend?"

        };
        //Creating a method to add new entry to the journal and select a random prompt from the list
        public void AddEntry()
        {
            var random = new Random();
            string prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine(prompt);
            Console.Write("Your response: ");
            string response = Console.ReadLine();
            Console.Write("Rate your mood today(1 - 10): ");
            int moodRating = int.Parse(Console.ReadLine());
            var entry = new Entry(prompt, response, moodRating);
            entries.Add(entry);
            Console.WriteLine("Entry added successfully.");
        }
//Display the journal entries 
        public void DisplayEntries()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("No entries in the journal.");
                return;
            }

            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter file = new StreamWriter(filename))
            {
                //iterate each entry in and display it
                file.WriteLine("Date, Prompt, Response, MoodRating");
                foreach (var entry in entries)
                {
                    file.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response} | {entry.MoodRating}");
                }
            }
            Console.WriteLine($"Journal saved to {filename}.");
        }
            public void LoadFromFile(string filename)
            {
        try
        {
        entries.Clear();
        using (StreamReader file = new StreamReader(filename))
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                var parts = line.Split('|');
                
                // Ensure the line has exactly 4 parts (Date, Prompt, Response, MoodRating)
                if (parts.Length == 4)
                {
                    // Parse the mood rating
                    if (int.TryParse(parts[3], out int moodRating))
                    {
                        var entry = new Entry(parts[1], parts[2], moodRating)
                        {
                            Date = parts[0]
                        };
                        entries.Add(entry);
                    }
                 }
              }
              
            }  Console.WriteLine($"Journal loaded from {filename}.");
                DisplayEntries();
            }
             catch (FileNotFoundException)
            {
        
            {
            Console.WriteLine($"The file {filename} does not exist.");
            }
       
        }    
    } 
  }

}
   
                    
                       
                
                
                
            
                
            
        


