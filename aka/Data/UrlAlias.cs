using MongoDB.Bson;

namespace aka.Data {
    public class UrlAlias {
        public ObjectId Id { get; set; }
        public string Alias { get; set; }
        public string Url { get; set; }
        public int Count { get; set; }

        public UrlAlias(string alias, string url) {
            Alias = alias;
            Url = url;
            Count = 0;
        }
    }
}
