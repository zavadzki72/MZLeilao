using Leilao.ApplicationService.Interfaces;
using Leilao.ApplicationService.ViewModels.Request.Product;
using Leilao.ApplicationService.ViewModels.Response;
using Leilao.Domain.Core.Bus;
using Leilao.Domain.Core.Notifications;
using Leilao.WebApi.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leilao.WebApi.Controllers {

    [Route("[controller]")]
    public class ProductController : BaseController {

        private readonly IProductApplicationService _productApplicationService;

        public ProductController(
            IMediatorHandler mediatorHandler,
            INotificationHandler<DomainNotification> notifications,
            IProductApplicationService productApplicationService
        ) : base(notifications, mediatorHandler) {
            _productApplicationService = productApplicationService;
        }

        /// <summary>
        ///     Get all products of plataform
        /// </summary>
        /// <returns>list of products</returns>
        /// <response code="200">Resume was found</response>
        /// <response code="400">Error in process/response>
        /// <response code="404">There's no resume</response>
        /// <response code="500">Returned case internal error</response> 
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<ProductResponseViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ProductResponseViewModel>>> GetAll() {
            
            var products = await _productApplicationService.GetAllProducts();

            return Response(products);
        }

        /// <summary>
        ///     Get product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product of informed id</returns>
        /// <response code="200">Resume was found</response>
        /// <response code="400">Error in process/response>
        /// <response code="404">There's no resume for the informed ID</response>
        /// <response code="500">Returned case internal error</response> 
        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(typeof(ProductResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductResponseViewModel>> GetById(Guid id) {

            var productViewModel = await _productApplicationService.GetProductById(id);

            return Response(productViewModel);
        }

        /// <summary>
        ///     Create a new product
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns>User created</returns>
        /// <response code="200">Resume was found</response>
        /// <response code="400">Error in process/response>
        /// <response code="500">Returned case internal error</response> 
        [HttpPost]
        [ProducesResponseType(typeof(ProductResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductResponseViewModel>> Create([FromBody] CreatePrductRequestViewModel viewModel) {

            var result = await _productApplicationService.CreateProduct(viewModel);

            return Response(result);
        }

    }
}
