using System;
using CardGame.Interfaces;

namespace CardGame.Components
{
    public class Player: IPlayer
    {
        private string Username;
        private int Score;
        private int CurrentCardValue;

        // player's username:
        public string username 
        {
            get {return Username;}
            set {Username = value;}
        }

        // player's score:
        public int score 
        {
            get {return Score;}
            set {Score = value;}
        }

        // the rank of the card most recently selected by the player:
        public int currentCardValue 
        {
            get {return CurrentCardValue;}
            set {CurrentCardValue = value;}
        }
    }
}