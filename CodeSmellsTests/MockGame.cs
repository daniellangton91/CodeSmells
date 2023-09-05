using CodeSmells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsTests
{
    internal class MockGame : Game
    {
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
    }
}
