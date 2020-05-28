using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace aka.Data {
    public class UrlAliasDBContext {
        private readonly IMongoDatabase db;
        private readonly IMongoCollection<UrlAlias> aliases;

        public UrlAliasDBContext() {
            var client = new MongoClient("mongodb://127.0.0.1:27017");
            db = client.GetDatabase("UrlAliasDB");
            aliases = db.GetCollection<UrlAlias>("UrlAliases");
        }

        public async Task<UrlAlias> GetAlias(string name) {
            var filter = Builders<UrlAlias>.Filter.Eq("Alias", name);
            var result = await aliases.Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<UrlAlias>> GetAllAliases() {
            var result = await aliases.FindAsync(_ => true);
            return await result.ToListAsync();
        }

        public async Task AddAlias(UrlAlias alias) {
            await aliases.InsertOneAsync(alias);
        }

        public async Task IncCount(UrlAlias alias) {
            var filter = Builders<UrlAlias>.Filter.Eq("_id", alias.Id);
            var update = Builders<UrlAlias>.Update.Inc("Count", 1);
            await aliases.UpdateOneAsync(filter, update);
        }
    }
}
