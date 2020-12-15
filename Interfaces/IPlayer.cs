using System;
namespace CardGame.Interfaces
{
    public interface IPlayer
    {
        string username {get; set;}
        int score {get; set;}
        int currentCardValue {get; set;}
    }
}