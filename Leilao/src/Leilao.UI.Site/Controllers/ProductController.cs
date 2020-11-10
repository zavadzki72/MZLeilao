using Leilao.ApplicationService.Interfaces;
using Leilao.ApplicationService.ViewModels.Request.Product;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Leilao.UI.Site.Controllers {

    public class ProductController : Controller {

        private readonly IProductApplicationService _productApplicationService;

        public ProductController(IProductApplicationService productApplicationService) {
            _productApplicationService = productApplicationService;
        }

        [HttpGet]
        public IActionResult CreateProduct() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreatePrductRequestViewModel viewModel) {

            await _productApplicationService.CreateProduct(viewModel);

            return RedirectToAction("Index", "Home");
        }

    }
}
