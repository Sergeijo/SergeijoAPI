using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseResponses
{
    public class DeleteUserByIdResponse : UseCaseResponseMessage
    {
        public string Result { get; }
        public IEnumerable<Error> Errors { get; }

        public DeleteUserByIdResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public DeleteUserByIdResponse(string result, bool success = false, string message = null) : base(success, message)
        {
            Result = result;
        }
    }
}
