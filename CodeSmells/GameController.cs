namespace CodeSmells
{
    internal class GameController
    {
        private readonly IUI uI;
        private IGame game;
        private readonly IDataHandler dataHandler;

        public GameController(IUI uI, IDataHandler dataHandler)
        {
            this.uI = uI;
            this.dataHandler = dataHandler;
        }
        private void SetGame(IGame game) => this.game = game;
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
                        SetGame(new Moo(uI, dataHandler, "Moo"));
                        game.PlayGame();
                        break;
                    case 2:
                        SetGame(new Mastermind(uI, dataHandler, "Mastermind"));
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
        private int NumberInput()
        {
            string input = uI.GetString();
            int menuChoice;
            while (!int.TryParse(input, out menuChoice))
            {
                uI.PutString("Input must be a number");
                input = uI.GetString();
            }
            return menuChoice;
        }
    }
}
