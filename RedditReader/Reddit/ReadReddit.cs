namespace RedditReader.Reddit
{
    public class Reddit
    {


    public async Task<string> GetRedditInfo(int limit) {


            var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var appId = MyConfig.GetValue<string>("AppSettings:appId");
            var appSecret = MyConfig.GetValue<string>("AppSettings:appSecret");
            var username = MyConfig.GetValue<string>("AppSettings:username");
            var password = MyConfig.GetValue<string>("AppSettings:password");

            var auth = new RedditAuth(appId, appSecret, username, password);
            var accessToken = await auth.GetAccessToken();

            var apiClient = new RedditApiClient(accessToken);
            var topPosts = await apiClient.GetTopPostsFromSubreddit("movies", limit);

            return topPosts;

        }      


    }
}
