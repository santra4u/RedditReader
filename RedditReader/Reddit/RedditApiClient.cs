using System.Net.Http.Headers;

namespace RedditReader.Reddit
{

    public class RedditApiClient
    {
        private readonly string _accessToken;

        public RedditApiClient(string accessToken)
        {
            _accessToken = accessToken;
        }

        public async Task<string> GetTopPostsFromSubreddit(string subreddit, int limit)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            client.DefaultRequestHeaders.Add("User-Agent", "MockClient/0.1 by Me");
            var response = await client.GetAsync($"https://oauth.reddit.com/r/{subreddit}/top.json?limit="+limit);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
