using CodeSmells;
namespace CodeSmellsTests
{
    internal class MockGame : Game
    {
        public Player Player = new();
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
        public override string GenerateRandomNumber()
        {
            return "1234";
        }
        public static string GetGuessFromUser()
        {
            return "1234";
        }
        public void SetPlayer(Player player)
        {
            this.Player = player;
        }
    }
}
