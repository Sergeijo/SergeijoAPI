using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseRequests
{
    public class LoginRequest : IUseCaseRequest<LoginResponse>
    {
        public int Userid { get; }
        public string Password { get; }

        public LoginRequest(int userid, string password)
        {
            Userid = userid;
            Password = password;
        }
    }
}
