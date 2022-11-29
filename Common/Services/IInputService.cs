namespace Common.Services;

public interface IInputService
{
    Task<string> GetInputOfDayAsync(int day);
}