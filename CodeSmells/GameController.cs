using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells
{
    internal class GameController
    {
        public void StartGame()
        {
            bool keepPlaying = true;
            Console.WriteLine("Enter your user name:\n");
            string playerName = Console.ReadLine();

            while (keepPlaying)
            {
                string gameGoal = GenerateRandomNumber();


                Console.WriteLine("New game:\n");
                //comment out or remove next line to play real games!
                Console.WriteLine("For practice, number is: " + gameGoal + "\n");
                string playerGuess = Console.ReadLine();

                int numberOfPlayerGuesses = 1;
                string bullsAndCowsResult = CompareGuessToGoal(gameGoal, playerGuess);
                Console.WriteLine(bullsAndCowsResult + "\n");
                while (bullsAndCowsResult != "BBBB,")
                {
                    numberOfPlayerGuesses++;
                    playerGuess = Console.ReadLine();
                    Console.WriteLine(playerGuess + "\n");
                    bullsAndCowsResult = CompareGuessToGoal(gameGoal, playerGuess);
                    Console.WriteLine(bullsAndCowsResult + "\n");
                }
                StreamWriter output = new StreamWriter("result.txt", append: true);
                output.WriteLine(playerName + "#&#" + numberOfPlayerGuesses);
                output.Close();
                DisplayPlayerTopList();
                Console.WriteLine("Correct, it took " + numberOfPlayerGuesses + " guesses\nContinue?");
                string answer = Console.ReadLine();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    keepPlaying = false;
                }
            }
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


        static void DisplayPlayerTopList()
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
            Console.WriteLine("Player   games average");
            foreach (Player p in playerResults)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
            }
            input.Close();
        }
    }
}
