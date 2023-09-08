namespace CodeSmells
{
    public class Player
    {
        public string Name { get; set; }
        public int NumberOfPlayedGames { get; set; }
        public int TotalGuesses { get; set; }

        public Player(string name)
        {
            this.Name = name;
            NumberOfPlayedGames = 0;
        }
        public void UpdatePlayedGames() => NumberOfPlayedGames++;
        public void UpdateGuesses(int guesses) => TotalGuesses += guesses;
        public double CalculateAverageScore()
        {
            return (double)TotalGuesses / NumberOfPlayedGames;
        }
    }
}
