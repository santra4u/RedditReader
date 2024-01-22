using Newtonsoft.Json.Linq;
using RedditReader.Models;

namespace RedditReader.Reddit
{
    public class RedditData
    {

        public async Task<DynamicTable> GetRedditData()
        {
            Models.DynamicTable dt = new Models.DynamicTable();

            Reddit reddit = new Reddit();
            var redditmessage = await reddit.GetRedditInfo();
            if (!string.IsNullOrEmpty(redditmessage))
            {
                //var redditmessageJson = JsonConvert.DeserializeObject(redditmessage);

                var doc = JObject.Parse(redditmessage);

                Dictionary<string, string> TitleVotes = new Dictionary<string, string>();
                Dictionary<string, string> UserVotes = new Dictionary<string, string>();

                TitleVotes["<B>Tiles</B>"] = "<B>Votes</B>";
                UserVotes["<B>User Name</B>"] = "<B>Votes</B>";
                foreach (var item in doc["data"]["children"])
                {
                    TitleVotes[item["data"]["title"].ToString()] = item["data"]["ups"].ToString();
                    UserVotes[item["data"]["author"].ToString()] = item["data"]["ups"].ToString();
                }



                //  var Title = doc["data"]["children"][0]["data"]["title"].ToString();

                var table = new List<Dictionary<string, string>>
                {
                    TitleVotes,
                    UserVotes
                };

                var entity = new DynamicTable
                {
                    name = "Reddit Posts and Users",
                    properties = table
                };
                return entity;
            }

            return dt;
        }

    }
}
