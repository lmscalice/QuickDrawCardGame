namespace CardGame.Interfaces
{
    public interface IInputValidator
    {
        int numberOfPlayersValidation(int enteredNum);
        string usernameValidation(string enteredName);        
    }
}