using System;

namespace CardGame.Interfaces
{
    public interface ICard
    {
       string cardName {get; set;} 
       int cardValue {get; set;}
    }
}