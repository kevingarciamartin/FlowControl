using FlowControl.Helpers;
using FlowControl.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowControl
{
    internal class Main
    {
        private IUI _ui;

        public Main(IUI ui)
        {
            _ui = ui;
        }

        public void Run()
        {
            do
            {
                ShowMainMenu();
                string selectedAction = _ui.GetInput();
                _ui.PrintLine();

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
                        _ui.PrintLine("Invalid input!");
                        break;
                }

            } while (true);
        }

        private  void ShowMainMenu()
        {
            _ui.PrintLine();
            _ui.PrintLine("** MAIN MENU **");
            _ui.PrintLine("Navigate by entering the corresponding number.");
            _ui.PrintLine("----------------------------------------------");
            _ui.PrintLine($"{MenuHelpers.Price}: Check price (Standard, Youth, Pensioner, Free).");
            _ui.PrintLine($"{MenuHelpers.PartyPrice}: Calculate the total price of your party.");
            _ui.PrintLine($"{MenuHelpers.RepeatedText}: Enter a text and see it repeated 10 times!");
            _ui.PrintLine($"{MenuHelpers.ThirdWordOfSentence}: Write a sentence and output the third word.");
            _ui.PrintLine($"{MenuHelpers.Exit}: Exit the application.");
        }

        private  string CheckAgeCategory(uint age)
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

        private  void PrintPrice()
        {
            _ui.PrintLine("Enter your age.");

            var age = Util.AskForUInt("Age", _ui);
            var category = CheckAgeCategory(age);

            if (category == "free")
                _ui.PrintLine("Free entry.");
            else if (category == "youth")
                _ui.PrintLine("Youth price: 80 kr.");
            else if (category == "pensioner")
                _ui.PrintLine("Pensioner price: 90 kr.");
            else
                _ui.PrintLine("Standard price: 120 kr.");
        }

        private  void PrintPartyPrice()
        {
            _ui.PrintLine("How many are there in your party?");

            var partySize = Util.AskForUInt("Party size", _ui);
            var partyPrice = GetPartyPrice(partySize);

            _ui.PrintLine($"The cost for your party of {partySize} people is {partyPrice} kr.");
        }

        private  uint GetPartyPrice(uint partySize)
        {
            var partyAges = GetPartyAges(partySize);
            uint price = 0;

            foreach (var age in partyAges)
            {
                var category = CheckAgeCategory(age);

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

        private  uint[] GetPartyAges(uint partySize)
        {
            uint[] ages = new uint[partySize];

            for (int i = 0; i < partySize; i++)
            {
                if (i == 0)
                    _ui.PrintLine();

                _ui.PrintLine($"Enter the age of person number {i + 1}.");

                var ageInput = Util.AskForUInt("Age", _ui);

                _ui.PrintLine();

                ages[i] = ageInput;
            }

            return ages;
        }

        private  void PrintRepeatedText()
        {
            _ui.PrintLine("Write your text.");

            var text = Util.AskForString("Text", _ui);

            for (int i = 0; i < 10; i++)
            {
                if (i == 9)
                    Console.Write($"{i + 1}. {text}");
                else
                    Console.Write($"{i + 1}. {text}, ");
            }

            _ui.PrintLine();
        }
        private  void PrintThirdWordOfSentence()
        {
            _ui.PrintLine("Write a sentence with at least 3 words.");

            var words = AskForSentence("Sentence");
            var index = GetIndexForThirdWord(words);

            _ui.PrintLine(words[index]);
        }

        private  string[] AskForSentence(string prompt)
        {
            bool success = false;
            string[] words;

            do
            {
                var sentence = Util.AskForString(prompt, _ui);
                words = sentence!.Split(' ', '\t');

                if (words.Length < 3)
                {
                    _ui.PrintLine("The sentence must contain at least 3 words.");
                    _ui.PrintLine();
                }
                else
                    success = true;

            } while (!success);

            return words;
        }

        private int GetIndexForThirdWord(string[] words)
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
