using System.Collections.Generic;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseResponses
{
    public class UpdateUserByIdResponse : UseCaseResponseMessage
    {
        public int Id { get; }
        public IEnumerable<string> Errors { get; }

        public UpdateUserByIdResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public UpdateUserByIdResponse(int id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
