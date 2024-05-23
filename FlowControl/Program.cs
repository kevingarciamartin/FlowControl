
using FlowControl.Helpers;

namespace FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                ShowMainMenu();
                string selectedAction = Console.ReadLine()!;
                Console.WriteLine();

                switch (selectedAction)
                {
                    case MenuHelpers.Price:
                        PrintPrice();
                        break;
                    case MenuHelpers.PartyPrice:
                        PrintPartyPrice();
                        break;
                    case MenuHelpers.RepeatedText:
                        PrintRepeatedText();
                        break;
                    case MenuHelpers.ThirdWordOfSentence:
                        PrintThirdWordOfSentence();
                        break;
                    case MenuHelpers.Exit:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }

            } while (true);
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("** MAIN MENU **");
            Console.WriteLine("Navigate by entering the corresponding number.");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"{MenuHelpers.Price}: Check price (Standard, Youth, Pensioner, Free).");
            Console.WriteLine($"{MenuHelpers.PartyPrice}: Calculate the total price of your party.");
            Console.WriteLine($"{MenuHelpers.RepeatedText}: Enter a text and see it repeated 10 times!");
            Console.WriteLine($"{MenuHelpers.ThirdWordOfSentence}: Write a sentence and output the third word.");
            Console.WriteLine($"{MenuHelpers.Exit}: Exit the application.");
        }

        private static string CheckAgeCategory(uint age)
        {
            if (age < 5 || age > 100)
                return "free";
            else if (age >= 5 && age < 20)
                return "youth";
            else if (age > 64 && age <= 100)
                return "pensioner";
            else
                return "standard";
        }

        private static void PrintPrice()
        {
            Console.WriteLine("Enter your age.");

            var age = Util.AskForUInt("Age");
            var category = CheckAgeCategory(age);

            if (category == "free")
                Console.WriteLine("Free entry.");
            else if (category == "youth")
                Console.WriteLine("Youth price: 80 kr.");
            else if (category == "pensioner")
                Console.WriteLine("Pensioner price: 90 kr.");
            else
                Console.WriteLine("Standard price: 120 kr.");
        }

        private static void PrintPartyPrice()
        {
            Console.WriteLine("How many are there in your party?");

            var partySize = Util.AskForUInt("Party size");
            var partyPrice = GetPartyPrice(partySize);

            Console.WriteLine($"The cost for your party of {partySize} people is {partyPrice} kr.");
        }

        private static uint GetPartyPrice(uint partySize)
        {
            var partyAges = GetPartyAges(partySize);
            uint price = 0;

            for (int i = 0; i < partySize; i++)
            {
                var category = CheckAgeCategory(partyAges[i]);

                if (category == "free")
                    price += 0;
                else if (category == "youth")
                    price += 80;
                else if (category == "pensioner")
                    price += 90;
                else
                    price += 120;
            }

            return price;
        }

        private static uint[] GetPartyAges(uint partySize)
        {
            uint[] ages = new uint[partySize];

            for (int i = 0; i < partySize; i++)
            {
                if (i == 0)
                    Console.WriteLine();

                Console.WriteLine($"Enter the age of person number {i + 1}.");

                var ageInput = Util.AskForUInt("Age");

                Console.WriteLine();

                ages[i] = ageInput;
            }

            return ages;
        }

        private static void PrintRepeatedText()
        {
            Console.WriteLine("Write your text.");

            var text = Util.AskForString("Text");

            for (int i = 0; i < 10; i++)
            {
                if (i == 9)
                    Console.Write($"{i + 1}. {text}");
                else
                    Console.Write($"{i + 1}. {text}, ");
            }

            Console.WriteLine();
        }
        private static void PrintThirdWordOfSentence()
        {
            Console.WriteLine("Write a sentence with at least 3 words.");

            var words = AskForSentence("Sentence");
            var index = GetIndexForThirdWord(words);

            Console.WriteLine(words[index]);
        }

        private static string[] AskForSentence(string prompt)
        {
            bool success = false;
            string[] words;

            do
            {
                var sentence = Util.AskForString(prompt);
                words = sentence!.Split(' ', '\t');

                if (words.Length < 3)
                {
                    Console.WriteLine("The sentence must contain at least 3 words.");
                    Console.WriteLine();
                }
                else
                    success = true;

            } while (!success);

            return words;
        }

        private static int GetIndexForThirdWord(string[] words)
        {
            int counter = 0;
            int index;

            for (index = 0; index < words.Length; index++)
            {
                if ((words[index] == ""))
                    continue;
                else
                    counter++;

                if (counter == 3)
                    break;
            }

            return index;
        }
    }
}
