namespace CodeSmells
{
    internal class Mastermind : Game
    {
        public Mastermind(IUI ui, IDataHandler dataHandler, string gameType) : base(ui, dataHandler, gameType) { }
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
            string correctNumberWrongPlace = "";
            string correctNumberCorrectPlace = "";
            var goalAsCharArray = goal.AsEnumerable();
            for (int i = 0; i < goal.Length; i++)
            {
                if (guess[i] == goal[i])
                {
                    correctNumberCorrectPlace += "B";
                }
                else
                {
                    correctNumberWrongPlace += goalAsCharArray.Contains(guess[i]) ? "C" : "";
                }
            }
            return $"{correctNumberCorrectPlace},{correctNumberWrongPlace}";
        }
    }
}
