using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Interfaces.UseCases;
using Web.Api.Presenters;

namespace Web.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAddAsyncUserUseCase _addAsyncUserUseCase;
        private readonly AddUserPresenter _addUserPresenter;

        private readonly IGetAsyncUsersUseCase _getAsyncUsersUseCase;
        private readonly GetUsersPresenter _getUsersPresenter;

        private readonly IGetAsyncUserByIdUseCase _getAsyncUserByIdUseCase;
        private readonly GetUserByIdPresenter _getUserByIdPresenter;

        private readonly IUpdateAsyncUserByIdUseCase _updateAsyncUserUseCase;
        private readonly UpdateUserByIdPresenter _updateUserPresenter;

        private readonly IDeleteAsyncUserByIdUseCase _deleteAsyncUserByIdUseCase;
        private readonly DeleteUserByIdPresenter _deleteUserByIdPresenter;

        public UserController(IAddAsyncUserUseCase addUserUseCase, AddUserPresenter addUserPresenter,
            IGetAsyncUserByIdUseCase getUserByIdUseCase, GetUserByIdPresenter getUserByIdPresenter,
            IGetAsyncUsersUseCase getUsersUseCase, GetUsersPresenter getUsersPresenter,
            IUpdateAsyncUserByIdUseCase updateUserUseCase, UpdateUserByIdPresenter updateUserPresenter,
            IDeleteAsyncUserByIdUseCase deleteUserByIdUseCase, DeleteUserByIdPresenter deleteUserByIdPresenter)
        {
            _addAsyncUserUseCase = addUserUseCase;
            _addUserPresenter = addUserPresenter;
            _getAsyncUserByIdUseCase = getUserByIdUseCase;
            _getUserByIdPresenter = getUserByIdPresenter;
            _getAsyncUsersUseCase = getUsersUseCase;
            _getUsersPresenter = getUsersPresenter;
            _updateAsyncUserUseCase = updateUserUseCase;
            _updateUserPresenter = updateUserPresenter;
            _deleteAsyncUserByIdUseCase = deleteUserByIdUseCase;
            _deleteUserByIdPresenter = deleteUserByIdPresenter;
        }

        /// <summary>
        /// Add new user in async await pattern.
        /// </summary>
        /// <param name="request">New user fields.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddUserAsync([FromBody] Models.Request.AddUserRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _addAsyncUserUseCase.Handle(new AddUserRequest(request.Id, request.Name, request.Birthdate, request.Password), _addUserPresenter);
            return _addUserPresenter.ContentResult;
        }

        /// <summary>
        /// Gets all the users in async await pattern.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _getAsyncUsersUseCase.Handle(new GetUsersRequest(), _getUsersPresenter);
            return _getUsersPresenter.ContentResult;
        }

        /// <summary>
        /// Gets the specified user identifier in async await pattern.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute][Required]string userId)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _getAsyncUserByIdUseCase.Handle(new GetUserByIdRequest(Convert.ToInt32(userId)), _getUserByIdPresenter);
            return _getUserByIdPresenter.ContentResult;
        }

        /// <summary>
        /// Puts the specified user with all the updates in async await pattern.
        /// </summary>
        /// <param name="userIdToUpdate">The user identifier.</param>
        /// <param name="request">The user view model.</param>
        /// <returns></returns>
        [HttpPut("{userIdToUpdate}")]
        public async Task<IActionResult> UpdateUserByIdAsync([FromRoute]string userIdToUpdate, [FromBody] Models.Request.UpdateUserRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _updateAsyncUserUseCase.Handle(new UpdateUserByIdRequest(Convert.ToInt32(userIdToUpdate), request.Updated_id, request.Updated_name, request.Updated_birthdate, request.Updated_password), _updateUserPresenter);
            return _updateUserPresenter.ContentResult;
        }

        /// <summary>
        /// Delete the specified user identifier in async await pattern.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUserByIdAsync([FromRoute]string userId)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _deleteAsyncUserByIdUseCase.Handle(new DeleteUserByIdRequest(Convert.ToInt32(userId)), _deleteUserByIdPresenter);
            return _deleteUserByIdPresenter.ContentResult;
        }
    }
}
