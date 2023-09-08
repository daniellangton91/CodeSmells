namespace CodeSmells
{
    public class Moo : Game
    {
        public Moo(IUI ui, IDataHandler dataHandler, string gameType) : base(ui, dataHandler, gameType) { }
        public override string GenerateRandomNumber()
        {
            Random randomGenerator = new();
            string randomNumbersAsString = "";
            for (int i = 0; i < 4; i++)
            {
                int randomNumber = randomGenerator.Next(10);
                string randomDigitAsString = "" + randomNumber;
                while (randomNumbersAsString.Contains(randomDigitAsString))
                {
                    randomNumber = randomGenerator.Next(10);
                    randomDigitAsString = "" + randomNumber;
                }
                randomNumbersAsString += randomDigitAsString;
            }
            return randomNumbersAsString;
        }
        public override string CompareGuessToGoal(string goal, string guess)
        {
            string correctNumberWrongPlace = "";
            string correctNumberCorrectPlace = "";
            var goalAsCharArray = goal.AsEnumerable();
            for (int i = 0; i < guess.Length; i++)
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
