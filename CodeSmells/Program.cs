namespace CodeSmells
{
    class Program
    {

        public static void Main(string[] args)
        {
            IUI ui = new ConsoleIO();
            GameController controller = new GameController(ui);
            controller.StartGame();
        }
        
    }    
}