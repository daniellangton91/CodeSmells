namespace CodeSmells
{
    internal class GameController
    {
        private readonly IUI uI;
        private IGame game;
        private readonly IDataHandler fileStorage;
        public GameController(IUI uI, IDataHandler fileStorage) 
        {
            this.uI = uI;
            this.fileStorage = fileStorage;
        }
        private void SetGame(IGame game)
        {
            this.game = game;
        }
        public void Start()
        {
            do
            {
                uI.Clear();
                uI.PutString(
                "Choose one:\n" +
                "1: Moo\n" +
                "2: Mastermind\n" +
                "3: Exit");
                int menuChoice = NumberInput();
                switch (menuChoice)
                {
                    case 1:
                        SetGame(new Moo(uI, fileStorage));
                        game.PlayGame();
                        break;
                    case 2:
                        SetGame(new Mastermind(uI, fileStorage));
                        game.PlayGame();
                        break;
                    case 3:
                        uI.Exit();
                        break;
                    default:
                        uI.PutString("Make a correct menu choice");
                        break;
                }                
            } while (true);
        } 
        public int NumberInput()
        {
            string input = uI.GetString();
            int menuChoice;
            while(!int.TryParse(input, out menuChoice))
            {
                uI.PutString("Input must be a number");
                input = uI.GetString();
            }
            return menuChoice;
        }
    }
}
