using System.Collections.Generic;

namespace Web.Api.Core.Dto.GatewayResponses.Repositories
{
    public sealed class CreateUserResponse : BaseGatewayResponse
    {
        public int Id { get; }
        public CreateUserResponse(int id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Id = id;
        }
    }
}
