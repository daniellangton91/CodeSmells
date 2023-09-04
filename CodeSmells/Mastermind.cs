namespace CodeSmells
{
    internal class Mastermind : Game
    {
        public Mastermind(IUI ui, IFileHandler storage)
        {
            this.uI = ui;
            this.storage = storage;
            gameType = "Mastermind";
        }
        public override string GenerateRandomNumber()
        {
            Random randomGenerator = new Random();
            string goal = "";
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(7);
                goal = goal + random;
            }
            return goal;
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
