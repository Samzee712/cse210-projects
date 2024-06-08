using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int percent = int.Parse(userInput);

        string letter = "";

        if (percent >= 90)
        {
            letter = "A+";

        }
        else if (percent >= 80)
        {
            letter = "B";

        }
        else if (percent >= 70)
        {
            letter = "C";

        }
        else if (percent >= 60)
        {
            letter = "D";

        }
        else 
        {
            letter = "F";

        }
        Console.WriteLine($"Your Grade is {letter}");

        if (percent >= 70)
        {
            Console.WriteLine("Congratulations, You've passed! ");

        }
        else
        {
            Console.WriteLine("Sorry, Keep Trying! ");

        }
        //To add  sign at the end of a pass grade
        string sign = "";
        int lastDigit = percent % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";

        }
        if (letter == "A" && sign == "+")
        {
            sign = "";

        }
        if (letter == "F")
        {
            sign = "";

        }
        Console.WriteLine($"Your final grade is: {letter}{sign} ");





        
    }
}