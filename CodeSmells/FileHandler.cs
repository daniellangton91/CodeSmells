using Newtonsoft.Json;

namespace CodeSmells
{
    internal class FileHandler : IDataHandler
    {
        private List<Player> Players { get; set; }
        private readonly IUI uI;
        public FileHandler(IUI uI)
        {
            this.uI = uI;
        }
        public void DisplayPlayerStatistics()
        {
            SortStatisticsByAverage();
            PrintScoreTable();
        }
        private void SortStatisticsByAverage()
        {
            Players.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
        }
        private void PrintScoreTable()
        {
            uI.PutString("Player   games   average");
            foreach (Player p in Players)
            {
                uI.PutString(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
            }
        }
        public void LoadStatistics(string fileName)
        {
            string json = "";
            try
            {
                json = File.ReadAllText(fileName);
            }
            catch (FileNotFoundException)
            {
                File.Create(fileName).Close();

            }
            Players = JsonConvert.DeserializeObject<List<Player>>(json);
        }
        public void SaveStatistics(Player player, string fileName)
        {
            string fullFileName = fileName + ".txt";
            LoadStatistics(fullFileName);
            UpdatePlayers(player);
            string newJson = JsonConvert.SerializeObject(Players, Formatting.Indented);
            File.WriteAllText(fullFileName, newJson);
        }
        private void UpdatePlayers(Player player)
        {
            if (Players != null)
            {
                var obj = Players.FirstOrDefault(x => x.Name == player.Name);
                if (obj != null)
                {
                    obj.TotalGuess = player.TotalGuess;
                    obj.NGames = player.NGames;
                }
                else
                {
                    Players.Add(player);
                }
            }
            else
            {
                Players = new List<Player> { player };
            }
        }
        public Player CheckIfPlayerExists(string name)
        {
            return Players.Find(i => i.Name == name);
        }
    }
}
