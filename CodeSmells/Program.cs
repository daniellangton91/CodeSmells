namespace CodeSmells
{
    class Program
    {
        public static void Main()
        {
            IUI uI = new ConsoleIO();
            IDataHandler dataHandler = new FileHandler(uI);
            GameController controller = new(uI, dataHandler);
            controller.Start();
        }
    }
}