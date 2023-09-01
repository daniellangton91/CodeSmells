﻿using System.Xml.Linq;

namespace CodeSmells
{
    public class Player
    {
        public string Name { get; private set; }
        public int NGames { get; private set; }
        int totalGuess;


        public Player(string name, int guesses)
        {
            this.Name = name;
            NGames = 1;
            totalGuess = guesses;
        }
        public Player(string name)
        {
            this.Name = name;
            NGames = 0;
        }
        public void UpdatePlayedGames()
        {
            NGames++;
        }

        public void UpdateGuesses(int guesses)
        {
            totalGuess += guesses;
        }
        public void Update(int guesses)
        {
            totalGuess += guesses;
            NGames++;
        }

        public double Average()
        {
            return (double)totalGuess / NGames;
        }


        public override bool Equals(Object p)
        {
            return Name.Equals(((Player)p).Name);
        }


        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
