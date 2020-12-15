using System;
namespace CardGame.Interfaces
{
    public interface IPlayers<T> where T:IPlayer
    {
        T[] Participants{set;}

        T this[int index]
        {
            get;
            set;
        }

        int arrayLen();
        void sortByScore();
        void print();
    }
}