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
    public sealed class GetAsyncUserByIdUseCase : IGetAsyncUserByIdUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetAsyncUserByIdUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(GetUserByIdRequest message, IOutputPort<GetUserByIdResponse> outputPort)
        {
            if (message.Id != 0)
            {
                // confirm we have a user with the given name
                var user = await _userRepository.FindById(message.Id);
                if (user != null)
                {
                    // generate response
                    outputPort.Handle(new GetUserByIdResponse(user, true));
                    return true;
                }
            }
            outputPort.Handle(new GetUserByIdResponse(new[] { new Error("get_user_by_id_failure", "Invalid User Id.") }));
            return false;
        }
    }
}
