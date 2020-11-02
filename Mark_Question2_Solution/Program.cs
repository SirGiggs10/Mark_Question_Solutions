using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mark_Question2_Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            //QUESTION 2
            //Write a program in C# Sharp to display the list of items in the array according to the length of the string then by name in ascending order.
            var continueNow = true;
            var arrayContinue = true;
            var listOfItems = new List<string>();
            do
            {
                listOfItems.Clear();
                arrayContinue = true;
                while(arrayContinue)
                {
                    Console.Clear();
                    Console.WriteLine("Enter a string you want to add to the array: ");
                    var inputString = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(inputString))
                    {
                        Console.WriteLine("\n\nString you entered is empty...Try again");
                    }
                    else
                    {
                        listOfItems.Add(inputString);
                    }

                    Console.WriteLine("\n\nDo you want to add another string to the array (invalid input other than Y or N will result to N)? (Y/N): ");
                    var charInputt = Console.ReadLine();
                    if (charInputt.Trim().ToUpper() == "Y")
                    {
                        arrayContinue = true;
                    }
                    else
                    {
                        arrayContinue = false;
                    }
                }

                Console.Clear();
                Console.WriteLine("The Ordered List Of Items");
                Console.WriteLine("--------------------------\n");
                var orderedListOfStrings = listOfItems.OrderBy(a => a.Length).ThenBy(b => b).ToList();
                foreach (var item in orderedListOfStrings)
                {
                    Console.WriteLine($"{item}");
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
