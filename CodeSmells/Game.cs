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
                guess = GetGuess();
                uI.PutString(CompareGuessToGoal(goal, guess));
                numberOfGuesses++;
            } while (guess != goal);
        }
        public string GetGuess()
        {
            string guessAsString = uI.GetString();
            while(guessAsString.Length != 4 || !int.TryParse(guessAsString, out int guessAsInt))
            {
                uI.PutString("Enter a 4 digit number");
                guessAsString = uI.GetString();
            }
            return guessAsString;
        }
        static string CompareGuessToGoal(string goal, string guess)
        {       
            string cows = "", bulls = "";
            var goalAsChars = goal.AsEnumerable();
            for(int i= 0; i < goal.Length; i++)
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
