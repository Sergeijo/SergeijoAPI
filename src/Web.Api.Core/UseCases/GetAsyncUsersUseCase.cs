using System.Threading.Tasks;
using Web.Api.Core.Dto;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.Interfaces.Services;
using Web.Api.Core.Interfaces.UseCases;

namespace Web.Api.Core.UseCases
{
    public sealed class GetAsyncUsersUseCase : IGetAsyncUsersUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetAsyncUsersUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(GetUsersRequest message, IOutputPort<GetUsersResponse> outputPort)
        {
            var user = await _userRepository.GetAll();
            if (user != null)
            {
                // generate response
                outputPort.Handle(new GetUsersResponse(user, true));
                return true;
            }

            outputPort.Handle(new GetUsersResponse(new[] { new Error("get_users_failure", "Invalid return list of Users.") }));
            return false;
        }
    }
}
