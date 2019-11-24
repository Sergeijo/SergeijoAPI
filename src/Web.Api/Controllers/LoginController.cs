using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Interfaces.UseCases;
using Web.Api.Presenters;

namespace Web.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginAsyncUseCase _loginUseCase;
        private readonly LoginPresenter _loginPresenter;

        public LoginController(ILoginAsyncUseCase loginUseCase, LoginPresenter loginPresenter)
        {
            _loginUseCase = loginUseCase;
            _loginPresenter = loginPresenter;
        }

        /// <summary>
        /// Login user in async await pattern. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] Models.Request.LoginUserRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _loginUseCase.Handle(new LoginRequest(request.Id, request.Password), _loginPresenter);
            return _loginPresenter.ContentResult;
        }
    }
}
