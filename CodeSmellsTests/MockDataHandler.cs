namespace CodeSmellsTests
{
    internal class MockDataHandler : IDataHandler
    {
        public Player CheckIfPlayerExists(string name) => throw new NotImplementedException();

        public void DisplayPlayerStatistics() => throw new NotImplementedException();

        public void LoadStatistics(string fileName) => throw new NotImplementedException();

        public void SaveStatistics(Player player, string fileName) => throw new NotImplementedException();
    }
}
