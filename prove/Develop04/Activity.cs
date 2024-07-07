using System;
using System.Collections.Generic;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to {_name} session \n");
        Console.WriteLine(_description);
        Console.Write("\nHow many seconds would you like to spend on this activity?: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowCountDown(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Good job! You have completed this activity.");
        Console.WriteLine($"Activity: {_name}");
        Console.WriteLine($"Duration: {_duration} seconds");
        ShowCountDown(5);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            Thread.Sleep(1000);
            Console.Write("\b-");
            Thread.Sleep(1000);
            Console.Write("\b\\");
            Thread.Sleep(1000);
            Console.Write("\b|");
            Thread.Sleep(1000);
            Console.Write("\b");
        }
        Console.WriteLine();
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b ");
        }
    }

    public abstract void Run();
}
