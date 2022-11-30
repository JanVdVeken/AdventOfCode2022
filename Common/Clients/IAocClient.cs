namespace Common.Clients
{
    public interface IAocClient
    {
        Task<string> GetInputForDayAsync(int day);
        Task<string> PostAnswerForDayAsync(int day, int dayPart, string answer);
    }
}