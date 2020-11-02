using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mark_Question1_Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            //QUESTION 1
            //1. Write a program in C# Sharp to display the characters and frequency of character from giving string.
            var continueNow = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter a string you want to display its characters and frequency: ");
                var inputString = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputString))
                {
                    Console.WriteLine("\n\nString you entered is empty...Try again");
                }
                else
                {
                    var listOfCharacters = inputString.GroupBy(a => a).ToList();
                    Console.Clear();
                    Console.WriteLine("The frequency of the characters are :");
                    Console.WriteLine("--------------------------------------\n");
                    foreach (var character in listOfCharacters)
                    {
                        Console.WriteLine($"Character {character.Key}: {character.Count()} times");
                    }
                }

                Console.WriteLine("\n\nDo you want to perform another operation (invalid input other than Y or N will result to N)? (Y/N): ");
                var charInput = Console.ReadLine();
                if(charInput.Trim().ToUpper() == "Y")
                {
                    continueNow = true;
                }
                else
                {
                    continueNow = false;
                }
            }
            while (continueNow);

            Console.WriteLine("\n\nThank You for using Mark's Program...Press any key to exit");
            Console.ReadKey();
        }
    }
}
