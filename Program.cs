using System;
using System.Linq;
using CardGame.Components;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // create new card game object
            DrawCardGame game = new DrawCardGame{};
            // create new validator obj to validate user input
            InputValidator validator = new InputValidator{};

            // set up the deck
            game.deck.setDeck();
            
            System.Console.WriteLine("Welcome To The Quick Draw Card Game");
            System.Console.WriteLine("This is a 2-4 player game. Please Enter the Number of Players Participating.");
           
            // get the number of players and validate this input
            int numberOfPlayers;
            try
            {
                numberOfPlayers = validator.numberOfPlayersValidation(Convert.ToInt32(Console.ReadLine()));
            }
            catch(SystemException)
            {
                numberOfPlayers = validator.numberOfPlayersValidation(100);
            }

            game.Users.Participants = new Player[numberOfPlayers];
            game.ScoreBoard.Participants = new Player[numberOfPlayers];
            
            // set up each player and validate username input
            for (int i=1; i<=numberOfPlayers; i++)
            {
                System.Console.WriteLine("Player " + i + " please enter a username.");
                string username = validator.usernameValidation(Console.ReadLine());
                game.setPlayer(i-1,username);
            }

            // game instructions
            System.Console.WriteLine("\nGame Overview:");
            System.Console.WriteLine("How to Play: Each player will take turns drawing a card each round.");
            System.Console.WriteLine("Scoring: If you draw the highest card that round, you will be rewarded 2 points. \n         If you draw a penalty card that round, you will lose 1 point. [Lowest Possible Score:0]");
            System.Console.WriteLine("To Win: You need a score of at least 21 where you lead by a minimum 2 points.");
            System.Console.WriteLine("Good Luck! \n");

            // round loop
            int round =1;
            while (true)
            {
                System.Console.WriteLine("Round " + round);

                // shuffle the deck
                game.deck.shuffle();

                // each player draws a card
                for (int j=0; j<game.Users.arrayLen(); j++)
                {
                    System.Console.WriteLine("\n" + game.Users[j].username + " press the [Enter] key to draw a card.");
                    Console.ReadLine();

                    Card cardDrawn = game.deck.chooseCard();
                    game.Users[j].currentCardValue = cardDrawn.cardValue;
                    System.Console.WriteLine("  You drew the " + cardDrawn.cardName + " card.");
                }

                // update and display the score based on drawn cards
                string[] roundResults = game.updateScoreBoard();
                System.Console.WriteLine("\nRound " + round + " Results:");
                System.Console.WriteLine(roundResults[0] + " won the round.");
                System.Console.WriteLine(roundResults[1] + " got a penalty card.\n");
                System.Console.WriteLine("The ScoreBoard:");
                game.ScoreBoard.print();
                System.Console.WriteLine("\n");

                // determine if a winner can be announced
                if (game.winnerDetermined())
                {
                    // end the game if there is a winner
                    Player winner = game.Winner;
                    System.Console.WriteLine("\n" + winner.username + " won the game with a score of " + winner.score + ".");
                    break;
                }

                // continue the game if there is no winner yet
                round = round +1;
            }
        }
    }
}