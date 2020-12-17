using System;
using System.Linq;
using CardGame.Interfaces;
using System.Collections.Generic;

namespace CardGame.Components
{
    public class DrawCardGame: IDrawCardGame<Player, Card, Players, Deck>
    {
        private Player winner = null;
        private Players users = new Players{};
        private Players scoreboard = new Players{};
        private Deck cardDeck = new Deck{};

        // gets the winner of the game
        public Player Winner
        {
            get { return winner; }
        }

        // gets the array of players
        public Players Users
        {
            get { return users; }
        }

        // gets the scoreboard
        public Players ScoreBoard
        {
            get { return scoreboard; }
        }

        // gets the deck of cards
        public Deck deck
        {
            get { return cardDeck; }
        }

        // sets up each player:
        public void setPlayer (int playerIndex, string name)
        {
            Player user = new Player {username = name, score = 0};
            users[playerIndex] = user;
            scoreboard[playerIndex] = user;
        }

        // updates the scoreboard based on the most recently drawn cards:
        // returns the round winner string[0] and those who received penalty cards string[1]
        public string[] updateScoreBoard()
        {
            int[] currCards = new int[ users.arrayLen() ];
            string[] roundResults = new string[2];
            roundResults[1]= "";

            for (int i = 0; i < users.arrayLen(); i++)
            {
                currCards[i] = users[i].currentCardValue;
                if (currCards[i] == -1)
                {
                    roundResults[1] = roundResults[1] + users[i].username + " ";
                    if (users[i].score > 0)
                    {
                        users[i].score = users[i].score -1;
                    } 
                }               
            } 

            if (roundResults[1] == "")
            {
                roundResults[1] = "No one";
            }

            int maxCardValue = currCards.Max();
            if (maxCardValue == -1)
            {
                roundResults[0] = "No one";
            }
            else
            {
               int maxCardIndex = Array.IndexOf(currCards, maxCardValue);

               roundResults[0] = users[maxCardIndex].username;
               users[maxCardIndex].score = users[maxCardIndex].score +2;
            }

            for (int i = 0; i < users.arrayLen(); i++)
            {
                scoreboard[i]=users[i];
            }
                   
            scoreboard.sortByScore();
            return roundResults;
        }

        // determines whether there is a game winner yet
        // returns true if a winner is determined and false if a winner isn't determined
        public bool winnerDetermined()
        {
            Player potentialWinner = scoreboard[0];
            Player runnerUp = scoreboard[1];

            if (potentialWinner.score >= 21 & runnerUp.score + 2 <= potentialWinner.score)
            {
                winner = potentialWinner;
                return true;
            }
            else
            {
                 return false;
            }
        }
    }
}
