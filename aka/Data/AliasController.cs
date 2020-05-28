using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace aka.Data {
    [Route("/")]
    public class AliasController : Controller {
        private readonly AliasService service;

        public AliasController(AliasService aliasService) {
            service = aliasService;
        }

        [HttpGet("{alias}")]
        public async Task<IActionResult> RedirectToAlias(string alias) {
            var url = await service.GetUrl(alias);
            if (url == null) {
                return NotFound();
            }
            return Redirect(url);
        }

        [HttpPost("/api/alias")]
        public async Task<IActionResult> AddAlias(UrlAlias urlAlias) {
            await service.AddAlias(urlAlias);
            return CreatedAtRoute(nameof(AddAlias), urlAlias);
        }
    }
}
