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
    public sealed class DeleteAsyncUserByIdUseCase : IDeleteAsyncUserByIdUseCase
    {
        private readonly IUserRepository _userRepository;

        public DeleteAsyncUserByIdUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserByIdRequest message, IOutputPort<DeleteUserByIdResponse> outputPort)
        {
            if (message.Id != 0)
            {
                // confirm the user has been deleted successfully
                var result  = await _userRepository.DeleteById(message.Id);
                if (result)
                {
                    // generate response
                    outputPort.Handle(new DeleteUserByIdResponse("User has been deleted successfully.", true));
                    return true;
                }
            }
            outputPort.Handle(new DeleteUserByIdResponse(new[] { new Error("delete_user_by_id_failure", "Invalid User Id.") }));
            return false;
        }
    }
}
