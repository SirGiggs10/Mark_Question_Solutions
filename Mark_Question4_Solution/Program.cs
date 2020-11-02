using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mark_Question4_Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            //QUESTION 4
            //4. Write a C# Sharp program to check whether an alphabet is a vowel or consonant.
            var continueNow = false;
            do
            {
                Console.Clear();
                var allAlphabetsInEnglishLanguage = new List<char>()
                {
                    'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
                };

                var allVowelsInEnglishLanguage = new List<char>()
                {
                    'A','E','I','O','U'
                };

                Console.WriteLine("Enter an alphabet in the english language (will pick the first alphabet when more than one alphabets is entered): ");
                var alphabetStringEntered = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(alphabetStringEntered))
                {
                    Console.WriteLine("\n\nThe character you entered is empty...Try again");
                }
                else
                {
                    var alphabetEntered = alphabetStringEntered.First();
                    if (allAlphabetsInEnglishLanguage.Contains(char.ToUpper(alphabetEntered)))
                    {
                        Console.Clear();
                        if (allVowelsInEnglishLanguage.Contains(char.ToUpper(alphabetEntered)))
                        {
                            Console.WriteLine($"The alphabet '{alphabetEntered}' is a vowel");
                        }
                        else
                        {
                            Console.WriteLine($"The alphabet '{alphabetEntered}' is a consonant");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\nThe character you entered is not an alphabet in the english language");
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
