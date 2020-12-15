using System;
using System.Linq;
using CardGame.Interfaces;
using System.Collections.Generic;

namespace CardGame.Components
{
    class DrawCardGame: IDrawCardGame<Player, Card, Players, Deck>
    {
        private Player winner = null;
        private Players users = new Players{};
        private Players scoreboard = new Players{};
        private Deck cardDeck = new Deck{};

        public Player Winner
        {
            get { return winner; }
        }

        public Players Users
        {
            get { return users; }
        }

        public Players ScoreBoard
        {
            get { return scoreboard; }
        }
        public Deck deck
        {
            get { return cardDeck; }
        }

        public void setPlayer (int playerIndex, string name)
        {
            Player user = new Player {username = name, score = 0};
            users[playerIndex] = user;
            scoreboard[playerIndex] = user;
        }

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
               users[maxCardIndex].score = users[maxCardIndex].score +1;
            }

            scoreboard = users;          
            scoreboard.sortByScore();
            return roundResults;
        }

        public void determineWinner()
        {
            Player potentialWinner = scoreboard[0];
            Player runnerUp = scoreboard[1];

            if (potentialWinner.score >= 21 & runnerUp.score + 2 <= potentialWinner.score)
            {
                winner = potentialWinner;
            }
        }

        /*void setDeck ()
        {
            string[] names = new string[] {"2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace"};
            
            Card card = new Card {cardName = "Penalty", cardValue = -1};
            deck[0] = card;

            int currValue = 0;
            for (int i =0; i < names.Length; i++)
            {
                Card newCard = new Card {cardName = names[i], cardValue = currValue};
                deck[i+1] = newCard;
                currValue = currValue + 4;
            }
        }

        string chooseCard (int playerIndex)
        {
            Random rnd = new Random();
            string[] suits = new string[] {"of Clubs", "of Diamonds", "of Hearts", "of Spades"};
            
            int cardIndex = rnd.Next( deck.arrayLen() );
            
            if (cardIndex == 0)
            {
                users[playerIndex].currentCardValue = -1;
                return "Penalty Card";
            }
            else
            {
                int suitsIndex = rnd.Next(suits.Length);
                int value = deck[cardIndex].cardValue + suitsIndex;

                users[playerIndex].currentCardValue = value;
                return deck[cardIndex].cardName + suits[suitsIndex];
            }

        }*/
    }
}
