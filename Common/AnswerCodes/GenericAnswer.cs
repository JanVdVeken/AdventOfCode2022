namespace Common.AnswerCodes;

public class GenericAnswer
{
    private readonly string _internalMessage;
    public string InternalMessage => _internalMessage;
    public GenericAnswer(string message)
    {
        _internalMessage = message;
    }
}