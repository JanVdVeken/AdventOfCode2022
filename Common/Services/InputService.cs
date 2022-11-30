using Common.Clients;

namespace Common.Services
{
    public class InputService : IInputService
    {
        private static InputService _inputServiceInstance;

        private const int MaxAmountOfDays = 25;
        private readonly string _inputsFolder;
        private readonly int _yearOfChallenge;
        private string[] _inputs;
        private IAocClient _client;
        private InputService(int yearOfChallenge, IAocClient aocClient)
        {
            _yearOfChallenge = yearOfChallenge;
            _inputs = new string[25];
            _inputsFolder = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"../../../../_Inputs/"));
            _client = aocClient;
        }

        public async Task<string> GetInputOfDayAsync(int dayOfTheMonth)
        {
            if (_inputs.Any(string.IsNullOrEmpty))
            {
                await GetAllPossibleInputs();
            }
            return _inputs[dayOfTheMonth - 1];
        }
        private async Task GetAllPossibleInputs()
        {
            var daysToGet = DecideAmountOfDays();
            if (!Directory.Exists(_inputsFolder)) Directory.CreateDirectory(_inputsFolder);
            for (var i = 0; i < daysToGet; i++)
            {
                var currentFile = Path.Combine(_inputsFolder, $"{_yearOfChallenge}_{i + 1}.txt");
                if (!File.Exists(currentFile))
                {
                    var content = await _client.GetInputForDayAsync(i + 1);
                    await File.WriteAllTextAsync(currentFile, content);
                }
                _inputs[i] = await File.ReadAllTextAsync(currentFile);
            }
        }
        private int DecideAmountOfDays()
        {
            if (_yearOfChallenge < DateTime.Now.Year) return MaxAmountOfDays;
            if (_yearOfChallenge == DateTime.Now.Year && DateTime.Now.Month == 12)
            {
                return Math.Min(DateTime.Now.Day, MaxAmountOfDays);
            }
            return 0;
        }
        public static async Task<InputService> CreateInputServiceAsync(int yearOfChallenge, IAocClient aocClient)
        {
            if (_inputServiceInstance is not null) return _inputServiceInstance;
            _inputServiceInstance = new InputService(yearOfChallenge, aocClient);
            await _inputServiceInstance.GetAllPossibleInputs();
            return _inputServiceInstance;
        }
    }
}