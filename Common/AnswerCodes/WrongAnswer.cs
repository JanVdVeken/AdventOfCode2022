namespace Common.AnswerCodes;

public class WrongAnswer : GenericAnswer
{
    public int AmountOfSeconds;
    public WrongAnswer(string message) : base(message)
    {
        
    }
}