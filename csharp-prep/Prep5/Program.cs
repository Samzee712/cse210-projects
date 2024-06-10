using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = promptUserName();
        int userNumber = promptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);


    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program! ");

    }
    static string promptUserName()
    {
        Console.Write("Please enter name: ");
        return Console.ReadLine();

    }
    static int promptUserNumber()
    {
        Console.Write("Please enter your number: ");
        int number =  int.Parse(Console.ReadLine());

        return number;


    }
    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;

    }
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square} ");

    }
}