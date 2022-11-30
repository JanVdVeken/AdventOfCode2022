using Common.Config;
using System.Net;

namespace Common.Clients
{
    public class AocClient : IAocClient
    {
        private readonly Uri _baseUri;
        private CookieContainer _container;
        public AocClient(IAoCConfig config, int year)
        {
            _baseUri = new Uri($"{config.BaseAPIUrl}{year}/day/");
            _container = new CookieContainer();
            _container.Add(_baseUri, new Cookie("session", config.SessionKey));
        }

        public async Task<string> GetInputForDayAsync(int day)
        {
            using var client = new HttpClient(new HttpClientHandler() {CookieContainer = _container })
            {
                BaseAddress = _baseUri 
            };
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return await client.GetStringAsync($"{day}/input");
        }

        public async Task<string> PostAnswerForDayAsync(int day,int dayPart, string answer)
        {
            using var client = new HttpClient(new HttpClientHandler() {CookieContainer = _container })
            {
                BaseAddress = _baseUri 
            };
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var values = new Dictionary<string, string>
            {
                { "level", $"{dayPart}"},
                { "answer", $"{answer}" }   
            };
            var response = await client.PostAsync($"{day}/answer", new FormUrlEncodedContent(values));
            return await response.Content.ReadAsStringAsync();
        }
    }
}
