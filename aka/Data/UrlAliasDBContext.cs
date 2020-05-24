using System.Threading.Tasks;
using MongoDB.Driver;

namespace aka.Data {
    public class UrlAliasDBContext {
        private readonly IMongoDatabase db;
        private readonly IMongoCollection<UrlAlias> aliases;

        public UrlAliasDBContext() {
            var client = new MongoClient("mongodb://localhost:27017");
            db = client.GetDatabase("UrlAliasDB");
            aliases = db.GetCollection<UrlAlias>("UrlAliases");
        }

        public async Task<string> GetUrl(string alias) {
            var filter = Builders<UrlAlias>.Filter.Eq("Alias", alias);
            var result = await aliases.Find(filter).FirstOrDefaultAsync();
            return result?.Url;
        }

        public async Task<UrlAlias> AddAlias(string alias, string url) {
            var doc = new UrlAlias(alias, url);
            await aliases.InsertOneAsync(doc);
            return doc;
        }
    }
}
