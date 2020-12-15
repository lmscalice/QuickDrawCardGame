namespace CardGame.Interfaces
{
    public interface IDrawCardGame<C,D,T,U> where C:IPlayer where D:ICard where T:IPlayers<C> where U: IDeck<D>
    {
        C Winner {get;}
        T Users{get;}
        T ScoreBoard{get;}
        U deck{get;}
        
        void setPlayer (int playerIndex, string name);
        string[] updateScoreBoard();     
        void determineWinner();
    }
}