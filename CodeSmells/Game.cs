namespace CodeSmells
{
    public abstract class Game : IGame
    {
        public IUI UI { get; private set; }
        public IDataHandler DataHandler { get; private set; }
        private Player Player { get; set; }
        private int numberOfGuesses;
        private string goal;
        private string GameType { get; set; }

        public Game(IUI ui, IDataHandler dataHandler, string gameType)
        {
            this.UI = ui;
            this.DataHandler = dataHandler;
            this.GameType = gameType;
        }
        private void SetPlayer(Player player) => this.Player = player;
        public void PlayGame()
        {
            bool keepPlaying = true;
            UI.Clear();
            UI.PutString($"{GameType}\n");
            UI.PutString("Enter your user name:");
            string playerName = UI.GetString();
            CreateOrUseExistingPlayer(playerName);
            do
            {
                Player.UpdatePlayedGames();
                numberOfGuesses = 0;
                goal = GenerateRandomNumber();
                PracticeGame();
                UI.PutString("New game:");
                CheckCorrectAnswer();
                Player.UpdateGuesses(numberOfGuesses);
                DataHandler.SaveStatistics(Player, $"{GameType}Stats");
                DataHandler.DisplayPlayerStatistics();
                UI.PutString("Correct, it took " + numberOfGuesses + " guesses\n");
                UI.PutString("Play a new game?");
                string Answer = UI.GetString();
                if (Answer != null && Answer != "" && Answer[..1] == "n")
                {
                    keepPlaying = false;
                }
                UI.Clear();
            } while (keepPlaying == true);
        }
        private void CreateOrUseExistingPlayer(string playerName)
        {
            DataHandler.LoadStatistics($"{GameType}Stats.txt");
            var playerFromFile = DataHandler.CheckIfPlayerExists(playerName);
            if (playerFromFile != null)
            {
                SetPlayer(playerFromFile);
            }
            else
            {
                SetPlayer(new Player(playerName));
            }
        }
        public abstract string GenerateRandomNumber();
        private void PracticeGame()
        {
            UI.PutString("Do you want to practice y/n?");
            string practiceAnswer = UI.GetString();
            if (practiceAnswer[..1] == "y" || practiceAnswer[..1] == "Y")
            {
                UI.PutString("For practice, number is: " + goal + "\n");
            }
        }
        public void CheckCorrectAnswer()
        {
            string guess;
            do
            {
                guess = GetGuessFromUser();
                UI.PutString(CompareGuessToGoal(goal, guess));
                numberOfGuesses++;
            } while (guess != goal);
        }
        private string GetGuessFromUser()
        {
            string guessAsString = UI.GetString();
            while (guessAsString.Length != 4 || !int.TryParse(guessAsString, out _))
            {
                UI.PutString("Enter a 4 digit number");
                guessAsString = UI.GetString();
            }
            return guessAsString;
        }
        public abstract string CompareGuessToGoal(string goal, string guess);
    }
}
