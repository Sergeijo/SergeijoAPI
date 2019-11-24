using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseRequests
{
    public class GetUserByIdRequest : IUseCaseRequest<GetUserByIdResponse>
    {
        public int Id { get; }

        public GetUserByIdRequest(int id)
        {
            Id = id;
        }
    }
}
