using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

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
                        break;
                    case 2:
                        //SetGame(new Mastermind(uI));
                        break;
                    case 3:
                        uI.Exit();
                        break;

                }
                game.PlayGame();
            } while (true);
        }
        static string GenerateRandomNumber()
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
