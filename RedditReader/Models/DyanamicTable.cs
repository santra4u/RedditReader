using System.Collections.Generic;

namespace RedditReader.Models
{   
    public class DynamicTable
    {
        public string name { get; set; }
        public List<Dictionary<string, string>> properties { get; set; }
    }
    
}
