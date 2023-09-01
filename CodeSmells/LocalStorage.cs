using Newtonsoft.Json;

namespace CodeSmells
{
    internal class LocalStorage : IFileHandler
    {
        protected List<Player> Players;
        private IUI ui;
        public LocalStorage(IUI ui)
        {
            this.ui = ui;
        }
        public void DisplayPlayerStatistics()
        {
            SortStatisticsByAverage();
            PrintScoreTable();
        }
        private void PrintScoreTable()
        {
            ui.PutString("Player   games   average");
            foreach (Player p in Players)
            {
                ui.PutString(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
            }
        }
        public void GetStatisticsFromFile(string fileName)
        {
            string json = "";
            try
            {
                json = File.ReadAllText(fileName);
            }
            catch (FileNotFoundException e)
            {
                File.Create(fileName).Close();

            }
            Players = JsonConvert.DeserializeObject<List<Player>>(json);
        }
        private void SortStatisticsByAverage()
        {
            Players.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
        }

        public void PutStatisticsToFile(Player player, string fileName)
        {
            string fullFileName = fileName + ".txt";
            GetStatisticsFromFile(fullFileName);
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
                    obj.totalGuess = player.totalGuess;
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
    }
}
