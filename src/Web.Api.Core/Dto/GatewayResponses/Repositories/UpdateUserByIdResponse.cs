﻿using System.Collections.Generic;

namespace Web.Api.Core.Dto.GatewayResponses.Repositories
{
    public sealed class UpdateUserByIdResponse : BaseGatewayResponse
    {
        public int Id { get; }
        public UpdateUserByIdResponse(int id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Id = id;
        }
    }
}
