namespace CodeSmells
{
    internal class Mastermind : IGame
    {
        private IUI uI;
        public Mastermind(IUI ui)
        {
            this.uI = ui;
        }
        public void CheckCorrectAnswer()
        {
            throw new NotImplementedException();
        }

        public string GenerateRandomNumber()
        {
            throw new NotImplementedException();
        }

        public void PlayGame()
        {
            throw new NotImplementedException();
        }
    }
}
