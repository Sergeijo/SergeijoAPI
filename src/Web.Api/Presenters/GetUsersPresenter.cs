﻿using System.Net;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Serialization;

namespace Web.Api.Presenters
{
    public sealed class GetUsersPresenter : IOutputPort<GetUsersResponse>
    {
        public JsonContentResult ContentResult { get; }

        public GetUsersPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetUsersResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}