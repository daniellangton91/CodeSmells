namespace CodeSmellsTests
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void TestUpdatePlayedGames()
        {
            Player player = new("TestPlayer");
            player.UpdatePlayedGames();
            Assert.AreEqual(1, player.NumberOfPlayedGames);
        }
        [TestMethod]
        public void TestUpdateGuesses()
        {
            Player player = new("TestPlayer");
            int guesses = 2;
            player.UpdateGuesses(guesses);
            Assert.AreEqual(guesses, player.TotalGuesses);
        }
        [TestMethod]
        public void TestAverage()
        {
            Player player = new("TestPlayer")
            {
                NumberOfPlayedGames = 2,
                TotalGuesses = 4
            };
            double averageScore = player.CalculateAverageScore();
            Assert.AreEqual(2, averageScore);
        }
    }
}
