using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace aka.Data {
    [Route("/")]
    public class AliasController : Controller {
        private readonly AliasService service;

        public AliasController(AliasService aliasService) {
            service = aliasService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> RedirectToAlias(string name) {
            var alias = await service.GetAlias(name);
            if (alias == null) {
                return NotFound();
            }

            await service.IncCount(alias);
            return Redirect(alias.Url);
        }

        [HttpPost("/api/alias")]
        public async Task<IActionResult> AddAlias(UrlAlias urlAlias) {
            await service.AddAlias(urlAlias);
            return CreatedAtRoute(nameof(AddAlias), urlAlias);
        }
    }
}
