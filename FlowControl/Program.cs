﻿
namespace FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string selectedAction;
            do
            {
                ShowMainMenu();
                selectedAction = Console.ReadLine()!;
                Console.WriteLine();

                switch (selectedAction)
                {
                    case "0":
                        break;
                    case "1":
                        Console.WriteLine("Enter your age.");
                        var age = GetAge();
                        PrintPrice(age);
                        break;
                    case "2":
                        Console.WriteLine("How many are in your party?");
                        var partySize = GetPartySize();
                        var partyAges = GetPartyAges(partySize);
                        PrintPartyPrice(partySize, partyAges);
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            } while (selectedAction != "0");
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("** MAIN MENU **");
            Console.WriteLine("Navigate by entering the corresponding number.");
            Console.WriteLine("-------------");
            Console.WriteLine("0: Exit the application.");
            Console.WriteLine("1: Check price (Youth, Standard, Pensioner).");
            Console.WriteLine("2: Calculate the total price of your party.");
        }

        private static int GetAge()
        {
            var ageInput = Console.ReadLine();
            Console.WriteLine();
            int age = ConvertToInt(ageInput!);
            
            return age;
        }

        private static int ConvertToInt(string input)
        {
            int output = Convert.ToInt32(input);

            return output;
        }

        private static void PrintPrice(int age)
        {
            if (age < 20) 
                Console.WriteLine("Youth price: 80 kr");
            else if (age > 64) 
                Console.WriteLine("Pensioner price: 90 kr");
            else 
                Console.WriteLine("Standard price: 120 kr");
        }

        private static int GetPartySize()
        {
            var sizeInput = Console.ReadLine();
            Console.WriteLine();
            int size = ConvertToInt(sizeInput!);

            return size;
        }

        private static int[] GetPartyAges(int partySize)
        {
            int[] ages = new int[partySize];
            for (int i = 0; i < partySize; i++)
            {
                Console.WriteLine($"Enter the age of person number {i + 1}.");
                var ageInput = Console.ReadLine();
                Console.WriteLine();

                ages[i] = ConvertToInt(ageInput!);
            }

            return ages;
        }

        private static void PrintPartyPrice(int partySize, int[] partyAges)
        {
            int partyPrice = GetPartyPrice(partySize, partyAges);
            Console.WriteLine($"The cost for your party of {partySize} people is {partyPrice} kr.");
        }

        private static int GetPartyPrice(int partySize, int[] partyAges)
        {
            int price = 0;
            for (int i = 0; i < partySize; i++)
            {
                if (partyAges[i] < 20)
                    price += 80;
                else if (partyAges[i] > 64)
                    price += 90;
                else
                    price += 120;
            }

            return price;
        }
    }
}
