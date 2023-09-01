namespace CodeSmells
{
    internal class GameController
    {
        private IUI uI;
        private IGame game;
        public GameController(IUI ui) 
        {
            this.uI = ui;
        }
        private void SetGame(IGame game)
        {
            this.game = game;
        }

        public void StartGame()
        {
            do
            {
                uI.PutString(
                "Choose one:\n" +
                "1: Moo\n" +
                "2: Mastermind\n" +
                "3: Exit");
                int gameChoice = Convert.ToInt32(uI.GetString());
                switch (gameChoice)
                {
                    case 1:
                        SetGame(new Moo(uI));
                        game.PlayGame();
                        break;
                    case 2:
                        //SetGame(new Mastermind(uI));
                        break;
                    case 3:
                        uI.Exit();
                        break;
                    default:
                        uI.PutString("Make a correct choice");
                        break;
                }                
            } while (true);
        }        
    }
}
