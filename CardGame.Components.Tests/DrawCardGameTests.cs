using NUnit.Framework;
using CardGame.Components;

namespace CardGame.Components.Tests.DrawCardGameTests
{
    [TestFixture]
    public class update_scoreboard_tests
    {
        private DrawCardGame _game;

        [SetUp]
        public void SetUp()
        {
            _game = new DrawCardGame{};
            _game.Users.Participants = new Player[4];
            _game.ScoreBoard.Participants = new Player[4];
            for (int i=1; i<=4; i++)
            {
                _game.setPlayer(i-1,"user " + i);
            }
        }

        [Test]
        public void no_Penalty_Cards()
        {
            for (int i=1; i<=4; i++)
            {
                _game.Users[i-1].currentCardValue = i;
            }

            string[] results = _game.updateScoreBoard();

            bool answer1 = results[0].Equals("user 4");
            bool answer2 = results[1].Equals("No one");
            Assert.IsTrue(answer1, "round winner is user 4");
            Assert.IsTrue(answer2, "No one received penalty cards");
        }

        [Test]
        public void penalty_Card_When_Score_Greater_Than_Zero()
        {
            for (int i=1; i<=3; i++)
            {
                _game.Users[i-1].currentCardValue = i;
            }

            _game.Users[3].score = 1;
            int originalScore = _game.Users[3].score;
            _game.Users[3].currentCardValue = -1;

            string[] results = _game.updateScoreBoard();

            bool answer1 = results[0].Equals("user 3");
            bool answer2 = results[1].Equals("user 4 ");
            Assert.IsTrue(answer1, "round winner is user 3");
            Assert.IsTrue(answer2, "user 4 got a penalty card");
            Assert.AreEqual(_game.Users[3].score,0);
            Assert.Less(_game.Users[3].score,originalScore);
        }

        [Test]
        public void penalty_Card_When_Score_Equals_Zero()
        {
            for (int i=1; i<=3; i++)
            {
                _game.Users[i-1].currentCardValue = i;
            }

            _game.Users[3].score = 0;
            int originalScore = _game.Users[3].score;
            _game.Users[3].currentCardValue = -1;

            string[] results = _game.updateScoreBoard();

            bool answer1 = results[0].Equals("user 3");
            bool answer2 = results[1].Equals("user 4 ");
            Assert.IsTrue(answer1, "round winner is user 3");
            Assert.IsTrue(answer2, "user 4 got a penalty card");
            Assert.AreEqual(_game.Users[3].score,originalScore);
        }

        [Test]
        public void all_Penalty_Cards()
        {
            for (int i=1; i<=4; i++)
            {
                _game.Users[i-1].currentCardValue = -1;
            }

            string[] results = _game.updateScoreBoard();

            bool answer1 = results[0].Equals("No one");
            bool answer2 = results[1].Equals("user 1 user 2 user 3 user 4 ");
            Assert.IsTrue(answer1, "no one won the round");
            Assert.IsTrue(answer2, "everyone received penalty cards");
        }
    }

    [TestFixture]
    public class winner_tests
    {
        private DrawCardGame _game;

        [SetUp]
        public void SetUp()
        {
            _game = new DrawCardGame{};
            _game.Users.Participants = new Player[4];
            _game.ScoreBoard.Participants = new Player[4];
            for (int i=1; i<=4; i++)
            {
                _game.setPlayer(i-1,"user " + i);
            }
        }

        [Test]
        public void no_Winner_Score_Less_Than_21_Larger_By_Two()
        {
            int scores = 16;
            for (int i=1; i<=3; i++)
            {
                _game.Users[i-1].currentCardValue = i;
                _game.Users[i-1].score = scores;
                scores = scores +1;
            }
            _game.Users[3].currentCardValue = 8;
            _game.Users[3].score = 18;

            _game.updateScoreBoard();
            bool result = _game.winnerDetermined();

            Assert.IsFalse(result, "No winner can be determined.");
        }

        [Test]
        public void no_Winner_At_Least_21_But_Not_Greater_By_2()
        {
            int scores = 18;
            for (int i=1; i<=3; i++)
            {
                _game.Users[i-1].currentCardValue = i;                
                _game.Users[i-1].score = scores;
                scores = scores +1;
            }
            _game.Users[3].currentCardValue = 8;
            _game.Users[3].score = 19;

            _game.updateScoreBoard();
            bool result = _game.winnerDetermined();

            Assert.IsFalse(result, "No winner can be determined.");
        }

        [Test]
        public void no_Winner_Niether_At_Least_21_Nor_Greater_By_2()
        {
            int scores = 10;
            for (int i=1; i<=4; i++)
            {
                _game.Users[i-1].currentCardValue = i;
                _game.Users[i-1].score = scores;
                scores = scores +1;
            }

            _game.updateScoreBoard();
            bool result = _game.winnerDetermined();

            Assert.IsFalse(result, "No winner can be determined.");
        }

        [Test]
        public void _winner_At_21_And_Greater_By_2()
        {
            int scores = 17;
            for (int i=1; i<=3; i++)
            {
                _game.Users[i-1].currentCardValue = i;
                _game.Users[i-1].score = scores;
                scores = scores +1;
            }
            _game.Users[3].currentCardValue = 8;
            _game.Users[3].score = 19;

            _game.updateScoreBoard();
            bool result = _game.winnerDetermined();

            Assert.IsTrue(result, "A winner can be determined.");
            bool answer1 = _game.Winner.username.Equals("user 4");
            Assert.IsTrue(answer1, "user 4 is the winner of the game");

        }
    }

}