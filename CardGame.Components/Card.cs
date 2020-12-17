using System;
using CardGame.Interfaces;

namespace CardGame.Components
{
    public class Card: ICard
    {
        private string CardName;
        private int CardValue;

        // the face value and suit of the card 
        public string cardName 
        {
            get {return CardName;}
            set {CardName = value;}
        }

        // the ranking of the card
        public int cardValue 
        {
            get {return CardValue;}
            set {CardValue = value;}
        }

    }
}