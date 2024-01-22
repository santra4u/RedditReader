using RedditReader.Reddit;

namespace RedditReaderTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAuth()
        {
            RedditData reddit = new RedditData();
            var data = reddit.GetRedditData(10000).Result;
            Assert.IsNotNull(data);
            
        }
        [Test]
        public void TestRateLimits()
        {

            var options = new ParallelOptions { MaxDegreeOfParallelism = 20 };

            //await Parallel.ForEachAsync(itemIds, options, async id => {
            //    var result = _service.GetItemDetails(id);
            //    var something = CreateSomething(result);
            //    list.Add(something);
            //});

            RedditData reddit = new RedditData();
            var data = reddit.GetRedditData(10).Result;
            Assert.IsNotNull(data);

        }
    }
}