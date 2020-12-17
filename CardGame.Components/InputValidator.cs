using System;
using System.Linq;
using CardGame.Interfaces;

namespace CardGame.Components
{
    public class InputValidator: IInputValidator
    {
        // validates that the input for the number of players is an integer in the range 2-4
        public int numberOfPlayersValidation(int enteredNum)
        {
            while ( !(enteredNum >=2 & enteredNum<=4) )
            {
                Console.WriteLine("Please Enter a Number between 2 and 4");
                try
                {
                    enteredNum = Convert.ToInt32(Console.ReadLine());
                }
                catch(SystemException)
                {
                    // if input is not a number - set to 100 so validator continues to ask for new input
                    enteredNum = 100;                    
                }    
            }

            return enteredNum;
        }
         
        // validates that there is an input for the username
        public string usernameValidation(string enteredName)
        {
            while (string.IsNullOrEmpty(enteredName))
            {
                Console.WriteLine("Username can't be empty! Please input your username again");
                enteredName = Console.ReadLine();
            }

            return enteredName;
        }

    }
}