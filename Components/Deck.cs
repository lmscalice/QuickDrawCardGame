using System;
using System.Linq;
using CardGame.Interfaces;
using System.Collections.Generic;

namespace CardGame.Components
{
     class Deck: IDeck<Card>
    {
        private List<Card> cards = new List<Card>{};

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

        public void shuffle()
        {
            Random rnd=new Random();
            List<Card> MyRandomList= cards.OrderBy(x => rnd.Next()).ToList();
            cards = MyRandomList;   
        }

        public Card chooseCard()
        {
            Card chosen = cards.First();
            cards.RemoveAt(0);
            cards.Add(chosen);
            return chosen;
        }

        public void print()
        {
            for (int j=0; j < cards.Count; j++)
            {
                System.Console.WriteLine("CardName: " + cards[j].cardName + ", CardValue: " + cards[j].cardValue);
            }
        }
    }
}