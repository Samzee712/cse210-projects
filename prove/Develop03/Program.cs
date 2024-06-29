using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {   
            
            //exceeding requirements
            // Load scriptures from a file
            var scriptures = LoadScripturesFromFile(@"C:\Users\hp\Desktop\C# MATERIALS\cse210-projects\prove\Develop03\scriptures.txt");

            // Check if any scriptures are loaded
            if (scriptures.Count == 0)
            {
                Console.WriteLine("No scriptures found in the file.");
                return;
            }

            // Main loop
            while (true)
            {
                // Randomly select a scripture from the library
                var random = new Random();
                var selectedScripture = scriptures[random.Next(scriptures.Count)];

                // Running the memorization process
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(selectedScripture);
                    Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
                    string input = Console.ReadLine();

                    if (input.ToLower() == "quit")
                        return;

                    if (!selectedScripture.HideRandomWords())
                    {
                        Console.WriteLine("All words are hidden. Well done!");
                        break;
                    }

                    // Providing feedback on progress
                    Console.WriteLine($"\nWords hidden: {selectedScripture.WordsHidden}/{selectedScripture.TotalWords}");
                }

                }
        }

        // Method to load scriptures from a file
        static List<Scripture> LoadScripturesFromFile(string filename)
        {
            var scriptures = new List<Scripture>();
            try
            {
                using (StreamReader file = new StreamReader(filename))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        var parts = line.Split('|');
                        if (parts.Length == 4)
                        {
                            var reference = new Reference(parts[0], parts[1], parts[2]);
                            var scripture = new Scripture(reference, parts[3]);
                            scriptures.Add(scripture);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"The file {filename} does not exist.");
            }
            return scriptures;
        }
    }
}
