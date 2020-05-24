using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace aka.Data {
    [Route("/")]
    public class AliasController : Controller {
        private readonly UrlAliasDBContext db;

        public AliasController() {
            db = new UrlAliasDBContext();
        }

        [HttpGet("{alias}")]
        public async Task<IActionResult> RedirectToAlias(string alias) {
            var url = await db.GetUrl(alias);
            if (url == null) {
                return NotFound();
            }
            return Redirect(url);
        }

        [HttpPost("/api/alias")]
        public async Task<IActionResult> AddAlias(string alias, string url) {
            var doc = await db.AddAlias(alias, url);
            return CreatedAtRoute(nameof(AddAlias), doc);
        }
    }
}
