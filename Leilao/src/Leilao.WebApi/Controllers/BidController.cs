using Leilao.ApplicationService.Interfaces;
using Leilao.ApplicationService.ViewModels.Request.Bid;
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
    public class BidController : BaseController {

        private readonly IBidApplicationService _bidApplicationService;

        public BidController(
            IMediatorHandler mediatorHandler,
            INotificationHandler<DomainNotification> notifications,
            IBidApplicationService bidApplicationService
        ) : base(notifications, mediatorHandler) {
            _bidApplicationService = bidApplicationService;
        }

        /// <summary>
        ///     Get all bids of plataform
        /// </summary>
        /// <returns>list of bids</returns>
        /// <response code="200">Resume was found</response>
        /// <response code="400">Error in process/response>
        /// <response code="404">There's no resume</response>
        /// <response code="500">Returned case internal error</response> 
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<BidResponseViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<BidResponseViewModel>>> GetAll() {

            var bids = await _bidApplicationService.GetAllBids();

            return Response(bids);
        }

        /// <summary>
        ///     Get all bids in progress
        /// </summary>
        /// <returns>list of bids</returns>
        /// <response code="200">Resume was found</response>
        /// <response code="400">Error in process/response>
        /// <response code="404">There's no resume</response>
        /// <response code="500">Returned case internal error</response> 
        [HttpGet]
        [Route("GetInProgress")]
        [ProducesResponseType(typeof(List<BidResponseViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<BidResponseViewModel>>> GetInProgress() {

            var bids = await _bidApplicationService.GetBidsInProgress();

            return Response(bids);
        }

        /// <summary>
        ///     Get all bids ended
        /// </summary>
        /// <returns>list of bids</returns>
        /// <response code="200">Resume was found</response>
        /// <response code="400">Error in process/response>
        /// <response code="404">There's no resume</response>
        /// <response code="500">Returned case internal error</response> 
        [HttpGet]
        [Route("GetFinished")]
        [ProducesResponseType(typeof(List<BidResponseViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<BidResponseViewModel>>> GetFinished() {

            var bids = await _bidApplicationService.GetFinishedBids();

            return Response(bids);
        }

        /// <summary>
        ///     Get bid by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Bid of informed id</returns>
        /// <response code="200">Resume was found</response>
        /// <response code="400">Error in process/response>
        /// <response code="404">There's no resume for the informed ID</response>
        /// <response code="500">Returned case internal error</response> 
        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(typeof(BidResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BidResponseViewModel>> GetById(Guid id) {

            var viewModel = await _bidApplicationService.GetBidById(id);

            return Response(viewModel);
        }

        /// <summary>
        ///     Finish one bid
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Bid updated</returns>
        /// <response code="200">Resume was found</response>
        /// <response code="400">Error in process/response>
        /// <response code="500">Returned case internal error</response> 
        [HttpPut]
        [Route("Finish")]
        [ProducesResponseType(typeof(BidResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BidResponseViewModel>> Finish([FromBody] Guid id) {

            var result = await _bidApplicationService.FinishBid(id);

            return Response(result);
        }

        /// <summary>
        ///     Create a new bid
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns>Bid created</returns>
        /// <response code="200">Resume was found</response>
        /// <response code="400">Error in process/response>
        /// <response code="500">Returned case internal error</response> 
        [HttpPost]
        [ProducesResponseType(typeof(BidResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BidResponseViewModel>> Create([FromBody] CreateBidRequestViewModel viewModel) {

            var result = await _bidApplicationService.CreateBid(viewModel);

            return Response(result);
        }

    }
}
