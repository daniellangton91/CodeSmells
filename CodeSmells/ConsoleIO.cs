namespace CodeSmells
{
    internal class ConsoleIO : IUI
    {
        public void PutString(string input)
        {
            Console.WriteLine(input);
        }
        public string GetString()
        {
            return Console.ReadLine();
        }
        public void Clear()
        {
            Console.Clear();
        }
        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
