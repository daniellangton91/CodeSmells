namespace CodeSmells
{
    class Program
    {
        public static void Main()
        {
            IUI uI = new ConsoleIO();
            IDataHandler fileStorage = new FileHandler(uI);
            GameController controller = new(uI, fileStorage);
            controller.StartGame();
        }        
    }    
}