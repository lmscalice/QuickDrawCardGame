using System;
using CardGame.Interfaces;

namespace CardGame.Components
{
     class Player: IPlayer
    {
        private string Username;
        private int Score;
        private int CurrentCardValue;

        public string username 
        {
            get {return Username;}
            set {Username = value;}
        }

        public int score 
        {
            get {return Score;}
            set {Score = value;}
        }

        public int currentCardValue 
        {
            get {return CurrentCardValue;}
            set {CurrentCardValue = value;}
        }
    }
}