namespace RedditReader.Reddit
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class RedditAuth
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _username;
        private readonly string _password;

        public RedditAuth(string clientId, string clientSecret, string username, string password)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _username = username;
            _password = password;
        }

        public async Task<string> GetAccessToken()
        {
            using var client = new HttpClient();
            var credentials = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
            client.DefaultRequestHeaders.Add("User-Agent", "MockClient/0.1 by Me");

            var postData = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("grant_type", "password"),
            new KeyValuePair<string, string>("username", _username),
            new KeyValuePair<string, string>("password", _password)
        };

            var content = new FormUrlEncodedContent(postData);
            var response = await client.PostAsync("https://www.reddit.com/api/v1/access_token", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<dynamic>(responseString);

            return responseData.access_token;
        }
    }

}
