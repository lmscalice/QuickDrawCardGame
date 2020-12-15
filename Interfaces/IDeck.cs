using System;
namespace CardGame.Interfaces
{
    public interface IDeck<T> where T:ICard
    {
        void setDeck();
        void shuffle();
        T chooseCard();
        void print();

    }
}