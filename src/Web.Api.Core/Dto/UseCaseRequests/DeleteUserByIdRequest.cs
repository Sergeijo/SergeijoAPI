using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseRequests
{
    public class DeleteUserByIdRequest : IUseCaseRequest<DeleteUserByIdResponse>
    {
        public int Id { get; }

        public DeleteUserByIdRequest(int id)
        {
            Id = id;
        }
    }
}
