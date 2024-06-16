using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        int number;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        
        do
        {
            Console.Write("Enter number: ");
            if (int.TryParse(Console.ReadLine(), out number))
            {
                if (number != 0)
                {
                    numbers.Add(number);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
            }
        } while (number != 0);

        if (numbers.Count > 0)
        {
            
            int sum = numbers.Sum();
            Console.WriteLine($"The sum is: {sum}");

            
            double average = numbers.Average();
            Console.WriteLine($"The average is: {average}");

            
            int max = numbers.Max();
            Console.WriteLine($"The largest number is: {max}");
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}
