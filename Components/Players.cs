using System;
using System.Linq;
using CardGame.Interfaces;

namespace CardGame.Components
{
     class Players: IPlayers<Player>
    {
        private Player[] players;

        public Player[] Participants
        {
            set {players = value;}
        }

        public Player this[int i] 
        {
            get { return players[i]; }
            set { players[i] = value; }
        } 


        public int arrayLen()
        {
            return players.Length;
        }

        public void sortByScore()
        {
            Player[] sortedByScore = players.OrderByDescending(o => o.score).ToArray();
            players = sortedByScore;
        }

        public void print()
        {
            for (int j=0; j < players.Length; j++)
            {
                System.Console.WriteLine("Username: " + players[j].username + ", Score: " + players[j].score);
            }
        }
    }
}