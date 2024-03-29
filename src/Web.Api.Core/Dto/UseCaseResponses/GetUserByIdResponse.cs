﻿using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseResponses
{
    public class GetUserByIdResponse : UseCaseResponseMessage
    {
        public User User { get; }
        public IEnumerable<Error> Errors { get; }

        public GetUserByIdResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetUserByIdResponse(User user, bool success = false, string message = null) : base(success, message)
        {
            User = user;
        }
    }
}
