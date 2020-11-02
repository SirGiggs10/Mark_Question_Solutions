using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mark_Question3_Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            //QUESTION 3
            //3. Write a C# Sharp program to exchange the first and last characters in a given string and return the new string.
            var continueNow = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter a string you want to exchange its first and last characters: ");
                var inputString = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputString))
                {
                    Console.WriteLine("\n\nString you entered is empty...Try again");
                }
                else
                {
                    if (inputString.Trim().Length == 1)
                    {
                        Console.WriteLine(inputString.Trim());
                    }
                    else
                    {
                        var inputStringFirstCharacter = inputString.First();
                        var inputStringLastCharacter = inputString.Last();
                        var inputStringMiddleCharacter = inputString.Substring(1, (inputString.Length - 2));
                        var outputString = $"{inputStringLastCharacter}{inputStringMiddleCharacter}{inputStringFirstCharacter}";

                        Console.Clear();
                        Console.WriteLine("The new string formed by exchanging first and last characters of the input string:");
                        Console.WriteLine("-----------------------------------------------------------------------------------\n");
                        Console.WriteLine(outputString.Trim());
                    }
                }

                Console.WriteLine("\n\nDo you want to perform another operation (invalid input other than Y or N will result to N)? (Y/N): ");
                var charInput = Console.ReadLine();
                if (charInput.Trim().ToUpper() == "Y")
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
