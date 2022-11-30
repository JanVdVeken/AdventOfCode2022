﻿using Common.Clients;
using System.Net;

namespace Common.Services;

public class InputService : IInputService
{
    private readonly AoCConfig _aocConfig;
    private static InputService _inputServiceInstance;
    
    private const int MaxAmountOfDays = 25;
    private readonly Uri _baseUri;
    private readonly string _inputsFolder;
    private readonly int _yearOfChallenge;
    private string[] _inputs;
    private InputService(int yearOfChallenge, AoCConfig aocConfig)
    {
        _yearOfChallenge = yearOfChallenge;
        _aocConfig = aocConfig;
        _inputs = new string[25];
        _inputsFolder = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"../../../../_Inputs/"));
        _baseUri = new Uri($"{_aocConfig.BaseAPIUrl}{_yearOfChallenge}/day/");
    }

    public static async Task<InputService> CreateInputServiceAsync(int yearOfChallenge, AoCConfig aocConfig)
    {
        if (_inputServiceInstance is not null) return _inputServiceInstance;

        _inputServiceInstance = new InputService(yearOfChallenge, aocConfig);
        await _inputServiceInstance.GetAllPossibleInputs();
        return _inputServiceInstance;
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
            var currentFile = Path.Combine(_inputsFolder,$"{_yearOfChallenge}_{i+1}.txt");
            if (!File.Exists(currentFile))
            {
                var content = await GetInputForDayAsync(i);
                await File.WriteAllTextAsync(currentFile, content);
            }
            _inputs[i] = await File.ReadAllTextAsync(currentFile);
        }
    }
    private async Task<string> GetInputForDayAsync(int day)
    {
        var cookieContainer = new CookieContainer();
        var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
        using var client = new HttpClient(handler) { BaseAddress = _baseUri};
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        cookieContainer.Add(_baseUri, new Cookie("session", _aocConfig.SessionKey));
        return await client.GetStringAsync($"{day+1}/input");
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
}