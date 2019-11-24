using System.Linq;
using System.Threading.Tasks;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.Interfaces.UseCases;

namespace Web.Api.Core.UseCases
{
    public sealed class AddAsyncUserUseCase : IAddAsyncUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public AddAsyncUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(AddUserRequest message, IOutputPort<AddUserResponse> outputPort)
        {
            var response = await _userRepository.Create(new User(message.Id, message.Name, message.Birthdate, message.Username), message.Password);
            outputPort.Handle(response.Success ? new AddUserResponse(response.Id, true) : new AddUserResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
