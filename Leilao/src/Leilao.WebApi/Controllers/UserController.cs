using Leilao.ApplicationService.Interfaces;
using Leilao.ApplicationService.ViewModels.Request.User;
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
    public class UserController : BaseController {

        private readonly IUserApplicationService _userApplicationService;

        public UserController(
            IMediatorHandler mediatorHandler,
            INotificationHandler<DomainNotification> notifications,
            IUserApplicationService userApplicationService
        ) : base(notifications, mediatorHandler) {
            _userApplicationService = userApplicationService;
        }

        /// <summary>
        ///     Get all users of plataform
        /// </summary>
        /// <returns>list of users</returns>
        /// <response code="200">Resume was found</response>
        /// <response code="400">Error in process/response>
        /// <response code="404">There's no resume</response>
        /// <response code="500">Returned case internal error</response> 
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<UserResponseViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<UserResponseViewModel>>> GetAll() {
            
            var users = await _userApplicationService.GetAllUsers();

            return Response(users);
        }

        /// <summary>
        ///     Get user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User of informed id</returns>
        /// <response code="200">Resume was found</response>
        /// <response code="400">Error in process/response>
        /// <response code="404">There's no resume for the informed ID</response>
        /// <response code="500">Returned case internal error</response> 
        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(typeof(UserResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserResponseViewModel>> GetById(Guid id) {

            var userViewModel = await _userApplicationService.GetUserById(id);

            return Response(userViewModel);
        }

        /// <summary>
        ///     Create a new user
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
        public async Task<ActionResult<UserResponseViewModel>> Create([FromBody] CreateUserRequestViewModel viewModel) {

            var result = await _userApplicationService.CreateUser(viewModel);

            return Response(result);
        }
    }
}
