namespace CodeSmells
{
    internal class Mastermind : Game
    {
        public Mastermind(IUI ui, IDataHandler storage)
        {
            this.UI = ui;
            this.Storage = storage;
            GameType = "Mastermind";
        }
        public override string GenerateRandomNumber()
        {
            Random randomGenerator = new();
            string randomNumbersAsString = "";
            for (int i = 0; i < 4; i++)
            {
                int randomNumber = randomGenerator.Next(7);
                randomNumbersAsString += randomNumber;
            }
            return randomNumbersAsString;
        }
        public override string CompareGuessToGoal(string goal, string guess)
        {
            string cows = "", bulls = "";
            var goalAsChars = goal.AsEnumerable();
            for (int i = 0; i < goal.Length; i++)
            {
                if (guess[i] == goal[i])
                {
                    bulls += "B";
                }
                else
                {
                    cows += goalAsChars.Contains(guess[i]) ? "C" : "";
                }
            }
            return $"{bulls},{cows}";
        }
    }
}
