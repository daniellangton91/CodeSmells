namespace CodeSmells
{
    internal class Moo : IGame
    {
        private IUI uI;
        public Moo(IUI ui) 
        {
            this.uI = ui;
        }
        public void CheckCorrectAnswer()
        {
            throw new NotImplementedException();
        }

        public string GenerateRandomNumber()
        {
            Random randomGenerator = new Random();
            string randomNumbers = "";
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(10);
                string randomDigit = "" + random;
                while (randomNumbers.Contains(randomDigit))
                {
                    random = randomGenerator.Next(10);
                    randomDigit = "" + random;
                }
                randomNumbers = randomNumbers + randomDigit;
            }
            return randomNumbers;
        }

        public void PlayGame()
        {
            bool keepPlaying = true;
            uI.PutString("Enter your user name:\n");
            string playerName = uI.GetString();

            while (keepPlaying)
            {
                string gameGoal = GenerateRandomNumber();


                uI.PutString("New game:\n");
                //comment out or remove next line to play real games!
                uI.PutString("For practice, number is: " + gameGoal + "\n");
                string playerGuess = uI.GetString();

                int numberOfPlayerGuesses = 1;
                string bullsAndCowsResult = CompareGuessToGoal(gameGoal, playerGuess);
                uI.PutString(bullsAndCowsResult + "\n");
                while (bullsAndCowsResult != "BBBB,")
                {
                    numberOfPlayerGuesses++;
                    playerGuess = uI.GetString();
                    uI.PutString(playerGuess + "\n");
                    bullsAndCowsResult = CompareGuessToGoal(gameGoal, playerGuess);
                    uI.PutString(bullsAndCowsResult + "\n");
                }
                StreamWriter output = new StreamWriter("result.txt", append: true);
                output.WriteLine(playerName + "#&#" + numberOfPlayerGuesses);
                output.Close();
                DisplayPlayerTopList();
                uI.PutString("Correct, it took " + numberOfPlayerGuesses + " guesses\nContinue?");
                string answer = uI.GetString();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    keepPlaying = false;
                }
            }
        }
        static string CompareGuessToGoal(string goal, string guess)
        {
            int cows = 0, bulls = 0;
            guess += "    ";     // if player entered less than 4 chars
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (goal[i] == guess[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }
            return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
        }
        public void DisplayPlayerTopList()
        {
            StreamReader input = new StreamReader("result.txt");
            List<Player> playerResults = new List<Player>();
            string line;
            while ((line = input.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                Player player = new Player(name, guesses);
                int pos = playerResults.IndexOf(player);
                if (pos < 0)
                {
                    playerResults.Add(player);
                }
                else
                {
                    playerResults[pos].Update(guesses);
                }


            }
            playerResults.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            uI.PutString("Player   games average");
            foreach (Player p in playerResults)
            {
                uI.PutString(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
            }
            input.Close();
        }
    }
}
