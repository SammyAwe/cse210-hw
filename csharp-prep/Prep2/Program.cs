using System;

class Program
{
    static void Main()
    {
        
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();

        
        int gradePercentage;
        bool isValid = int.TryParse(input, out gradePercentage);

        
        if (!isValid || gradePercentage < 0 || gradePercentage > 100)
        {
            Console.WriteLine("Please enter a valid grade percentage between 0 and 100.");
        }
        else
        {
            
            string letter;

            if (gradePercentage >= 90)
            {
                letter = "A";
            }
            else if (gradePercentage >= 80)
            {
                letter = "B";
            }
            else if (gradePercentage >= 70)
            {
                letter = "C";
            }
            else if (gradePercentage >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            
            Console.WriteLine($"Your letter grade is {letter}.");

            
            if (gradePercentage >= 70)
            {
                Console.WriteLine("Congratulations! You passed the course.");
            }
            else
            {
                Console.WriteLine("Unfortunately, you did not pass the course. Better luck next time!");
            }
        }
    }
}