using System;
using System.Linq;
using CardGame.Interfaces;
using System.Collections.Generic;

namespace CardGame.Components
{
    public class Deck: IDeck<Card>
    {
        private List<Card> cards = new List<Card>{};

        // initializes all the cards in the deck:
        public void setDeck()
        {
            string[] names = new string[] {"2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace"};
            string[] suits = new string[] {" of Clubs", " of Diamonds", " of Hearts", " of Spades"};

            Card card = new Card {cardName = "Penalty", cardValue = -1};
            cards.Add(card);
            cards.Add(card);
            cards.Add(card);
            cards.Add(card);

            int currValue = 0;
            for (int i =0; i < names.Length; i++)
            {
                for (int j =0; j < suits.Length; j++)
                {
                    Card newCard = new Card {cardName = names[i] + suits[j], cardValue = currValue};
                    cards.Add(newCard);

                    currValue = currValue + 1;
                }
            }
        }

        // shuffles the deck of cards:
        public void shuffle()
        {
            Random rnd=new Random();
            List<Card> MyRandomList= cards.OrderBy(x => rnd.Next()).ToList();
            cards = MyRandomList;   
        }

        // returns one card from the deck:
        public Card chooseCard()
        {
            // chooses first card
            Card chosen = cards.First();

            // once chosen, moves card to the back of the deck
            cards.RemoveAt(0);
            cards.Add(chosen);

            return chosen;
        }
    }
}