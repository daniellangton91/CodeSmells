namespace CodeSmells
{
    internal class Moo : Game
    {
        public Moo(IUI ui, IDataHandler storage) 
        {
            this.UI = ui;
            this.Storage = storage;
            GameType = "Moo";
        }
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
            string cows = "", bulls = "";
            var goalAsChars = goal.AsEnumerable();
            for (int i = 0; i < guess.Length; i++)
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
