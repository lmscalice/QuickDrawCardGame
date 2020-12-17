using NUnit.Framework;
using System;
using System.IO;

namespace CardGame.Components.Tests
{
    [TestFixture]
    public class InputValidatorTests
    {
        private InputValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new InputValidator{};  
        }

        [Test]
        public void numberOfPlayers_Test_Return_Good_Input()
        {
            using (var consoleInput = new StringReader(""+ Environment.NewLine + "w" + Environment.NewLine + "10" + Environment.NewLine + "0" + Environment.NewLine + "2"))
            {
                Console.SetIn(consoleInput);
                int result = _validator.numberOfPlayersValidation(100);
                int result1 = _validator.numberOfPlayersValidation(3);

                Assert.AreEqual(result,2);
                Assert.AreEqual(result1,3);
            }
        }

        [Test]
        public void username_Test_Return_Good_Input()
        {
            using (var consoleInput = new StringReader(""+ Environment.NewLine + "willy" ))
            {
                Console.SetIn(consoleInput);
                string output = _validator.usernameValidation("");
                string output1 = _validator.usernameValidation("bob");

                bool result = output.Equals("willy");
                bool result1 = output1.Equals("bob");

                Assert.IsTrue(result, "first result is willy");
                Assert.IsTrue(result1, "second result is bob");
            }
        }
    }
}