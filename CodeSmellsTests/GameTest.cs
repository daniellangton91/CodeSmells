namespace CodeSmellsTests
{
    [TestClass]
    public class GameTest
    {
        readonly IUI uI = new MockUI();
        readonly IDataHandler dataHandler = new MockDataHandler();

        [TestMethod]
        public void TestGenerateRandomNumber()
        {
            MockGame mockGame = new(uI, dataHandler, "Mock");
            Assert.AreEqual("1234", mockGame.GenerateRandomNumber());
        }
        [TestMethod]
        public void TestCorrectGuess()
        {
            MockGame mockGame = new(uI, dataHandler, "Mock");
            Moo mooGame = new(uI, dataHandler, "Moo");
            string guess = "1234";
            string goal = mockGame.GenerateRandomNumber();
            Assert.AreEqual("BBBB,", mooGame.CompareGuessToGoal(goal, guess));
        }
        [TestMethod]
        public void TestCorrectNumbersInWrongOrder()
        {
            MockGame mockGame = new(uI, dataHandler, "Mock");
            Moo mooGame = new(uI, dataHandler, "Moo");
            string guess = "4321";
            string goal = mockGame.GenerateRandomNumber();
            Assert.AreEqual(",CCCC", mooGame.CompareGuessToGoal(goal, guess));
        }
    }
}