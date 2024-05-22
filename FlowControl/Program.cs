
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
                    case "1":
                        PrintPrice();
                        break;
                    case "2":
                        PrintPartyPrice();
                        break;
                    case "3":
                        PrintRepeatedText();
                        break;
                    case "4":
                        PrintThirdWordOfSentence();
                        break;
                    case "0":
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
            Console.WriteLine("1: Check price (Standard, Youth, Pensioner, Free).");
            Console.WriteLine("2: Calculate the total price of your party.");
            Console.WriteLine("3: Enter a text and see it repeated 10 times!");
            Console.WriteLine("4: Write a sentence and output the third word.");
            Console.WriteLine("0: Exit the application.");
        }

        private static string AskForString(string prompt)
        {
            bool success = false;
            string answer;

            do
            {
                Console.Write($"{prompt}: ");
                answer = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(answer))
                {
                    Console.WriteLine($"You must enter a valid {prompt.ToLower()}.");
                    Console.WriteLine();
                }
                else
                    success = true;

            } while (!success);

            return answer;
        }

        private static uint AskForUInt(string prompt)
        {
            do
            {
                string input = AskForString(prompt);

                if (!uint.TryParse(input, out uint result))
                {
                    Console.WriteLine($"You must enter a valid {prompt.ToLower()}.");
                    Console.WriteLine();
                }
                else
                    return result;

            } while (true);            
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

            var age = AskForUInt("Age");
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

            var partySize = AskForUInt("Party size");
            var partyAges = GetPartyAges(partySize);
            var partyPrice = GetPartyPrice(partySize, partyAges);

            Console.WriteLine($"The cost for your party of {partySize} people is {partyPrice} kr.");
        }

        private static uint[] GetPartyAges(uint partySize)
        {
            uint[] ages = new uint[partySize];
            for (int i = 0; i < partySize; i++)
            {
                if (i == 0)
                    Console.WriteLine();

                Console.WriteLine($"Enter the age of person number {i + 1}.");
                var ageInput = AskForUInt("Age");
                Console.WriteLine();

                ages[i] = ageInput;
            }

            return ages;
        }

        private static uint GetPartyPrice(uint partySize, uint[] partyAges)
        {
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

        private static void PrintRepeatedText()
        {
            Console.WriteLine("Write your text.");

            var text = AskForString("Text");

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
                var sentence = AskForString(prompt);
                words = sentence!.Split(" ");

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
            int index = 0;

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
