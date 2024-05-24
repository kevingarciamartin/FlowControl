using FlowControl.UI;

namespace FlowControl.Helpers
{
    public static class Util
    {
        public static string AskForString(string prompt, IUI ui)
        {
            bool success = false;
            string answer;

            do
            {
                ui.Print($"{prompt}: ");
                answer = ui.GetInput();

                if (string.IsNullOrWhiteSpace(answer))
                {
                    ui.PrintLine($"You must enter a valid {prompt.ToLower()}.");
                    ui.PrintLine();
                }
                else
                    success = true;

            } while (!success);

            return answer;
        }

        public static uint AskForUInt(string prompt, IUI ui)
        {
            do
            {
                string input = AskForString(prompt, ui);

                if (!uint.TryParse(input, out uint result))
                {
                    ui.PrintLine($"You must enter a valid {prompt.ToLower()}.");
                    ui.PrintLine();
                }
                else
                    return result;

            } while (true);
        }
    }
}
