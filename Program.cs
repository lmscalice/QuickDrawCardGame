using System;
using System.Linq;
using CardGame.Interfaces;
using CardGame.Components;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // create new card game object
            DrawCardGame game = new DrawCardGame{};

            // set up the deck
            game.deck.setDeck();
            
            // set up players
            System.Console.WriteLine("Welcome To The Quick Draw Card Game");
            System.Console.WriteLine("This is a 2-4 player game. Please Enter the Number of Players Participating.");
            
            int numberOfPlayers = Convert.ToInt32(Console.ReadLine());
            game.Users.Participants = new Player[numberOfPlayers];
            game.ScoreBoard.Participants = new Player[numberOfPlayers];
            
            for (int i=1; i<=numberOfPlayers; i++)
            {
                System.Console.WriteLine("Player " + i + " please enter a username.");
                string username = Console.ReadLine();
                game.setPlayer(i-1,username);
            }

            // instructions
            System.Console.WriteLine("\nGame Overview:");
            System.Console.WriteLine("How to Play: Each player will take turns drawing a card each round.");
            System.Console.WriteLine("Scoring: If you draw the highest card that round, you will be rewarded 1 point, but if you draw a penalty card you will lose 2 points.");
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

                // update the score based on drawn cards
                string[] roundResults = game.updateScoreBoard();
                System.Console.WriteLine("\nRound " + round + " Results:");
                System.Console.WriteLine(roundResults[0] + " won the round.");
                System.Console.WriteLine(roundResults[1] + " got a penalty card.\n");
                System.Console.WriteLine("The ScoreBoard:");
                game.Users.print();
                System.Console.WriteLine("\n");

                game.determineWinner();
                Player winner = game.Winner;
                if (winner != null)
                {
                    System.Console.WriteLine("\n" + winner.username + " won the game with a score of " + winner.score + ".");
                    break;
                }

                round = round +1;
            }
        }
    }
}