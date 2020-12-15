using System;
using CardGame.Interfaces;

namespace CardGame.Components
{
     class Card: ICard
    {
        private string CardName;
        private int CardValue;

        public string cardName 
        {
            get {return CardName;}
            set {CardName = value;}
        }

        public int cardValue 
        {
            get {return CardValue;}
            set {CardValue = value;}
        }

    }
}