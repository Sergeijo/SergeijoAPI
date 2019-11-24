using System.Collections.Generic;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseResponses
{
    public class AddUserResponse : UseCaseResponseMessage 
    {
        public int Id { get; }
        public IEnumerable<string> Errors {  get; }

        public AddUserResponse(IEnumerable<string> errors, bool success=false, string message=null) : base(success, message)
        {
            Errors = errors;
        }

        public AddUserResponse(int id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
