namespace FlowControl.Helpers
{
    public static class Util
    {
        public static string AskForString(string prompt)
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

        public static uint AskForUInt(string prompt)
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
    }
}
