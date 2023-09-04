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
    }
}
