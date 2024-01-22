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
        public void Test1()
        {
            RedditData reddit = new RedditData();
            var data = reddit.GetRedditData().Result;
            Assert.IsNotNull(data);
            
        }
    }
}