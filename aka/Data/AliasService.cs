using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aka.Data {
    public class AliasService {
        private readonly UrlAliasDBContext db;

        public AliasService() {
            db = new UrlAliasDBContext();
        }

        public async Task<string> GetUrl(string alias) {
            return await db.GetUrl(alias);
        }

        public async Task<List<UrlAlias>> GetAllAliases() {
            return await db.GetAllAliases();
        }

        public async Task AddAlias(UrlAlias alias) {
            await db.AddAlias(alias);
        }
    }
}
