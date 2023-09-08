namespace CodeSmells
{
    public interface IDataHandler
    {
        void SaveStatistics(Player player, string fileName);
        void LoadStatistics(string fileName);
        void DisplayPlayerStatistics();
        public Player CheckIfPlayerExists(string name);
    }
}
