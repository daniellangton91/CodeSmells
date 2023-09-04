using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells
{
    public abstract class Game : IGame
    {
        public IUI uI { get; set; }
        public IFileHandler storage { get; set; }
        public int numberOfGuesses;
        public string guess;
        public bool keepPlaying = true;
        public string goal;
        public string bullsAndCowsResult;
        public string gameType { get; set; }

        public void CheckCorrectAnswer()
        {
            do
            {
                guess = uI.GetString();
                bullsAndCowsResult = CompareGuessToGoal(goal, guess);
                uI.PutString($"{bullsAndCowsResult}");
                numberOfGuesses++;
            } while (guess != goal);
        }
        static string CompareGuessToGoal(string goal, string guess)
        {
            int cows = 0, bulls = 0;
            guess += "    ";     // if player entered less than 4 chars
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (goal[i] == guess[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }
            return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
        }
        public abstract string GenerateRandomNumber();

        public void PlayGame()
        {
            uI.Clear();
            uI.PutString($"{gameType}\n");
            uI.PutString("Enter your user name:");
            Player player = new Player(uI.GetString());
            do
            {
                player.UpdatePlayedGames();
                numberOfGuesses = 0;
                goal = GenerateRandomNumber();
                PracticeGame();
                uI.PutString("New game:");
                CheckCorrectAnswer();
                player.UpdateGuesses(numberOfGuesses);
                storage.PutStatisticsToFile(player, $"{gameType}Stats");
                storage.DisplayPlayerStatistics();
                uI.PutString("Correct, it took " + numberOfGuesses + " guesses\n");
                uI.PutString("Play a new game?");
                string Answer = uI.GetString();
                if (Answer != null && Answer != "" && Answer.Substring(0, 1) == "n")
                {
                    keepPlaying = false;
                }
                uI.Clear();
            } while (keepPlaying == true);
        }
        private void PracticeGame()
        {
            uI.PutString("Do you want to practice y/n?");
            string practiceAnswer = uI.GetString();
            if (practiceAnswer == "y")
            {
                uI.PutString("For practice, number is: " + goal + "\n");
            }
        }
    }
}
