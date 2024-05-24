
using FlowControl.Helpers;
using FlowControl.UI;

namespace FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUI ui = new ConsoleUI();
            Main main = new Main(ui);
            main.Run();
        }
    }
}
