using CodeSmells;

namespace CodeSmellsTests
{
    [TestClass]
    public class GameTest
    {
        readonly MockGame mockGame = new();
        Player player = new("TestPlayer");
        [TestMethod]
        public void TestGenerateRandomNumber()
        {
            Assert.AreEqual("1234", mockGame.GenerateRandomNumber());
        }
        [TestMethod]
        public void TestCorrectGuess()
        {
            string guess = "1234";
            string goal = mockGame.GenerateRandomNumber();
            Assert.AreEqual("BBBB,", mockGame.CompareGuessToGoal(goal, guess));
        }
        [TestMethod]
        public void TestCorrectNumbersInWrongOrder()
        {
            string guess = "4321";
            string goal = mockGame.GenerateRandomNumber();
            Assert.AreEqual(",CCCC", mockGame.CompareGuessToGoal(goal, guess));
        }
        [TestMethod]
        public void TestGetGuessFromUser()
        {
            Assert.IsNotNull(MockGame.GetGuessFromUser());
        }
        [TestMethod]
        public void TestSetPlayer() 
        {
            mockGame.SetPlayer(player);
            Assert.AreEqual(player.Name, mockGame.Player.Name);
        }
    }
}