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
    public sealed class UpdateAsyncUserByIdUseCase : IUpdateAsyncUserByIdUseCase
    {
        private readonly IUserRepository _userRepository;

        public UpdateAsyncUserByIdUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UpdateUserByIdRequest message, IOutputPort<UpdateUserByIdResponse> outputPort)
        {
            var response = await _userRepository.Update(message.UpdateId.ToString(), new User(message.NewId, message.Name, message.Birthdate, message.Password));
            outputPort.Handle(response.Success ? new UpdateUserByIdResponse(response.Id, true) : new UpdateUserByIdResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
