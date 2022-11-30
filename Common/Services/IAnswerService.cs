using Common.AnswerCodes;

namespace Common.Services;

public interface IAnswerService
{
    Task<GenericAnswer> PostAnswerAsync(int day, int dayPart, string answer);
}