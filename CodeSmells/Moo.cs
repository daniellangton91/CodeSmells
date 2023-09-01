namespace CodeSmells
{
    internal class Moo : IGame
    {
        private IUI uI;
        private IFileHandler storage;
        private int numberOfGuesses;
        private string guess;
        private bool keepPlaying = true;
        private string goal;
        private string bullsAndCowsResult;
        public Moo(IUI ui, IFileHandler storage) 
        {
            this.uI = ui;
            this.storage = storage;
        }
        public void PlayGame()
        {
            uI.Clear();
            uI.PutString("MooGame\n");
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
                storage.PutStatisticsToFile(player, "MooStats");
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
        private void PracticeGame()
        {
            uI.PutString("Do you want to practice y/n?");
            string practiceAnswer = uI.GetString();
            if (practiceAnswer == "y")
            {
                uI.PutString("For practice, number is: " + goal + "\n");
            }
        }

        public string GenerateRandomNumber()
        {
            Random randomGenerator = new Random();
            string randomNumbers = "";
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(10);
                string randomDigit = "" + random;
                while (randomNumbers.Contains(randomDigit))
                {
                    random = randomGenerator.Next(10);
                    randomDigit = "" + random;
                }
                randomNumbers = randomNumbers + randomDigit;
            }
            return randomNumbers;
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
    }
}
