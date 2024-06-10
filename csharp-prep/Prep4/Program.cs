using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number;

        Console.WriteLine("Enter a lst of numbers, type 0 when finished. ");

        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);

            }
          
         } while (number != 0);

          int sum = numbers.Sum();
          double average = numbers.Average();
          int max = numbers.Max();

          Console.WriteLine($"The sum is: {sum} ");
          Console.WriteLine($"The average is: {average} ");
          Console.WriteLine($"The Largest number in the list is: {max} ");

          //To find the smallest number in the list
          int smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty().Min();
          Console.WriteLine($"The smallest postive number in the list is: {smallestPositive} ");

          numbers.Sort();
          Console.WriteLine("The sorted list is: ");
          foreach (int num in numbers)
          {
            Console.WriteLine(num);
          }


        
    }
}