namespace CodeSmells
{
    class Program
    {

        public static void Main(string[] args)
        {
            IUI ui = new ConsoleIO();
            IFileHandler storage = new LocalStorage(ui);
            GameController controller = new GameController(ui, storage);
            controller.StartGame();
        }
        
    }    
}