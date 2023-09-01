﻿using System.Xml.Linq;

namespace CodeSmells
{
    public class Player
    {
        public string Name { get; set; }
        public int NGames { get; set; }
        public int totalGuess { get; set; }

        public Player(string name)
        {
            this.Name = name;
            NGames = 0;
        }
        public Player()
        {

        }
        public void UpdatePlayedGames()
        {
            NGames++;
        }

        public void UpdateGuesses(int guesses)
        {
            totalGuess += guesses;
        }

        public double Average()
        {
            return (double)totalGuess / NGames;
        }
    }
}
