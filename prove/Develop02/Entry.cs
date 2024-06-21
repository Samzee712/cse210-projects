using System;

namespace JournalApp
{
    // Declare an entry class to represent your journal
    public class Entry
    {
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string Date { get; set; }
        //Exceeding Requirements
        //I Added method to get the user mode.
        public int MoodRating { get; set; }

    //Add constructors to initialize an entry.
        public Entry(string prompt, string response, int moodRating)
        {
            Prompt = prompt;
            Response = response;
            MoodRating = moodRating;
            Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public override string ToString()
        {
            //Return the journal entry 
            return $"[{Date}] {Prompt}: {Response} \n My Mood Rate: ({MoodRating})";
        }
    }
}
