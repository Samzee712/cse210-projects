using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "List things you are grateful for.",
        "List people you appreciate in your life.",
        "List events that made you happy recently.",
        "List things you love about yourself."
    };

    private List<string> _usedPrompts = new List<string>();

    public GratitudeActivity(): base ("Gratitude Activity", "This activity will help you reflect on the positive aspects of your life by listing things you are grateful for.")
    {
    
    }

    public override void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);

        Console.WriteLine("You have a few seconds to think about your answers...");
        ShowSpinner(5);

        List<string> items = GetListFromUser();

        Console.WriteLine($"You listed {items.Count} items:");
        foreach (var item in items)
        {
            Console.WriteLine($"- {item}");
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        if (_usedPrompts.Count == _prompts.Count)
        {
            _usedPrompts.Clear();
        }

        List<string> availablePrompts = _prompts.FindAll(p => !_usedPrompts.Contains(p));
        Random random = new Random();
        int index = random.Next(availablePrompts.Count);
        string prompt = availablePrompts[index];
        _usedPrompts.Add(prompt);

        return prompt;
    }

    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Enter an item (or leave blank to finish):");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                break;
            }
            items.Add(input);
        }
        return items;
    }
}
