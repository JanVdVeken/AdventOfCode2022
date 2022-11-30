namespace Common.Clients
{
    public interface IAocClient
    {
        Task<string> GetInputForDayAsync(int day);
    }
}