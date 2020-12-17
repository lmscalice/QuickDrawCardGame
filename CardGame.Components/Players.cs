using System;
using System.Linq;
using CardGame.Interfaces;

namespace CardGame.Components
{
    public class Players: IPlayers<Player>
    {
        private Player[] players;

        // initializes the player array:
        public Player[] Participants
        {
            set {players = value;}
        }

        // sets and gets each player:
        public Player this[int i] 
        {
            get { return players[i]; }
            set { players[i] = value; }
        } 

        // returns number of players:
        public int arrayLen()
        {
            return players.Length;
        }

        // sorts the players by their score in descending order:
        public void sortByScore()
        {
            Player[] sortedByScore = players.OrderByDescending(o => o.score).ToArray();
            players = sortedByScore;
        }

        // prints the players' usernames and scores:
        public void print()
        {
            for (int j=0; j < players.Length; j++)
            {
                System.Console.WriteLine("Username: " + players[j].username + ", Score: " + players[j].score);
            }
        }
    }
}