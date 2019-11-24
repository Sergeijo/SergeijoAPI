using System.Net;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Serialization;

namespace Web.Api.Presenters
{
    public sealed class GetUserByIdPresenter : IOutputPort<GetUserByIdResponse>
    {
        public JsonContentResult ContentResult { get; }

        public GetUserByIdPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetUserByIdResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
