namespace CodeSmells
{
    public interface IFileHandler
    {
        void PutStatisticsToFile(Player player, string fileName);
        void GetStatisticsFromFile(string fileName);
        void DisplayPlayerStatistics();
    }
}
