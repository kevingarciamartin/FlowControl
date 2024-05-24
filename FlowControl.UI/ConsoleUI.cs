using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowControl.UI
{
    public class ConsoleUI
    {
        public void PrintLine(string message = "")
        {
            Console.WriteLine(message);
        }

        public void Print(string message)
        {
            Console.Write(message);
        }

        public string GetInput()
        {
            return Console.ReadLine() ?? string.Empty;
        }
    }
}
