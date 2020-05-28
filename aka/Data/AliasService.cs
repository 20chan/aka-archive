using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aka.Data {
    public class AliasService {
        private readonly UrlAliasDBContext db;

        public AliasService() {
            db = new UrlAliasDBContext();
        }

        public async Task<UrlAlias> GetAlias(string name) {
            return await db.GetAlias(name);
        }

        public async Task<List<UrlAlias>> GetAllAliases() {
            return await db.GetAllAliases();
        }

        public async Task AddAlias(UrlAlias alias) {
            await db.AddAlias(alias);
        }

        public async Task IncCount(UrlAlias alias) {
            await db.IncCount(alias);
        }
    }
}
