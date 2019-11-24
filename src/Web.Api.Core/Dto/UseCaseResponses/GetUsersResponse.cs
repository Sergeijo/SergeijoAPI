using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseResponses
{
    public class GetUsersResponse : UseCaseResponseMessage
    {
        public List<User> Users { get; }
        public IEnumerable<Error> Errors { get; }

        public GetUsersResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetUsersResponse(List<User> users, bool success = false, string message = null) : base(success, message)
        {
            Users = users;
        }
    }
}
