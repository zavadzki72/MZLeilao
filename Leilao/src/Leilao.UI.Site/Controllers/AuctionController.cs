using Leilao.ApplicationService.Interfaces;
using Leilao.ApplicationService.ViewModels.Request.Bid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leilao.UI.Site.Controllers {

    public class AuctionController : Controller {

        private readonly IBidApplicationService _bidApplicationService;
        private readonly IUserApplicationService _userApplicationService;
        private readonly IProductApplicationService _productApplicationService;

        public AuctionController(IBidApplicationService bidApplicationService, IUserApplicationService userApplicationService, IProductApplicationService productApplicationService) {
            _bidApplicationService = bidApplicationService;
            _userApplicationService = userApplicationService;
            _productApplicationService = productApplicationService;
        }


        [HttpGet]
        public async Task<IActionResult> CreateBid([FromQuery] string error) {

            ViewBag.Error = error;

            ViewBag.Produtos = await LoadProducts();
            ViewBag.Users = await LoadUsers();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBid(CreateBidRequestViewModel viewModel) {

            var ret = await _bidApplicationService.CreateBid(viewModel);

            if(ret == null)
                return RedirectToAction("CreateBid", "Auction", new { error = "Você nao pode oferecer um lance com esse valor, aumente e tente novamente!" });

            return RedirectToAction("BidList", "Auction");
        }

        [HttpGet]
        public async Task<IActionResult> BidList() {

            var list = await _bidApplicationService.GetAllBids();

            return View(list);
        }

        private async Task<SelectList> LoadProducts() {

            var allProducts = await _productApplicationService.GetAllProducts();

            Dictionary<Guid, string> dictProducts = new Dictionary<Guid, string>();

            allProducts.ForEach(x => {
                dictProducts.Add(x.Id, x.Name);
            });

            SelectList products = new SelectList(
                dictProducts.Select(x => new { Value = x.Key, Text = x.Value }),
                "Value",
                "Text"
            );

            return products;
        }

        private async Task<SelectList> LoadUsers() {

            var allUsers = await _userApplicationService.GetAllUsers();

            Dictionary<Guid, string> dictUsers = new Dictionary<Guid, string>();

            allUsers.ForEach(x => {
                dictUsers.Add(x.Id, x.Name);
            });

            SelectList users = new SelectList(
                dictUsers.Select(x => new { Value = x.Key, Text = x.Value }),
                "Value",
                "Text"
            );

            return users;
        }
    }
}
