namespace CodeSmellsTests
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void TestGenerateRandomNumber()
        {
            MockGame mockGame = new MockGame();
            Assert.AreEqual("1234", mockGame.GenerateRandomNumber());
        }
        [TestMethod]
        public void TestCorrectGuess()
        {
            MockGame mockGame = new MockGame();
            string guess = "1234";
            string goal = mockGame.GenerateRandomNumber();
            Assert.AreEqual("BBBB,", mockGame.CompareGuessToGoal(goal, guess));
        }
        [TestMethod]
        public void TestCorrectNumbersInWrongOrder()
        {
            MockGame mockGame = new MockGame();
            string guess = "4321";
            string goal = mockGame.GenerateRandomNumber();
            Assert.AreEqual(",CCCC", mockGame.CompareGuessToGoal(goal, guess));
        }
    }
}