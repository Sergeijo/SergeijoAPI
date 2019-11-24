using System;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseRequests
{
    public class UpdateUserByIdRequest : IUseCaseRequest<UpdateUserByIdResponse>
    {
        public int UpdateId { get; }
        public int NewId { get; }
        public string Name { get; }
        public DateTime Birthdate { get; }
        public string Username { get; }
        public string Password { get; }

        public UpdateUserByIdRequest(int updateid, int newid, string name, DateTime birthdate, string password)
        {
            UpdateId = updateid;
            NewId = newid;
            Name = name;
            Birthdate = birthdate;
            Username = name;
            Password = password;
        }
    }
}
