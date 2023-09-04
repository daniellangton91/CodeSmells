namespace CodeSmells
{
    internal class Moo : Game
    {
        public Moo(IUI ui, IFileHandler storage) 
        {
            this.uI = ui;
            this.storage = storage;
            gameType = "Moo";
        }
        public override string GenerateRandomNumber()
        {
            Random randomGenerator = new Random();
            string randomNumbers = "";
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(10);
                string randomDigit = "" + random;
                while (randomNumbers.Contains(randomDigit))
                {
                    random = randomGenerator.Next(10);
                    randomDigit = "" + random;
                }
                randomNumbers = randomNumbers + randomDigit;
            }
            return randomNumbers;
        }
    }
}
