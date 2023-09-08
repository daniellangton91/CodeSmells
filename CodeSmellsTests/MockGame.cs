namespace CodeSmellsTests
{
    internal class MockGame : Game
    {
        public MockGame(IUI ui, IDataHandler dataHandler, string gameType) : base(ui, dataHandler, gameType) { }

        public override string GenerateRandomNumber()
        {
            return "1234";
        }
        public override string CompareGuessToGoal(string goal, string guess) => throw new NotImplementedException();
    }
}
