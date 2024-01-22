namespace RedditReader.Reddit
{
    public class Reddit
    {


    public async Task<string> GetRedditInfo() {


            var appId = "JsbgvAr4_NqKRhO9NOFeBQ";
            var appSecret = "OrF0-6Y829iGXSeEqv5MNpzadyGlxg";
           

            var auth = new RedditAuth(appId, appSecret, "somnathtest", "Testing1");
            var accessToken = await auth.GetAccessToken();

            var apiClient = new RedditApiClient(accessToken);
            var topPosts = await apiClient.GetTopPostsFromSubreddit("movies");

            return topPosts;

        }      


    }
}
