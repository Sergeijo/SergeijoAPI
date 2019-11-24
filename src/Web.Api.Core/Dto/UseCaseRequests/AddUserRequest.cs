using System;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseRequests
{
    public class AddUserRequest : IUseCaseRequest<AddUserResponse>
    {
        public int Id { get; }
        public string Name { get; }
        public DateTime Birthdate { get; }
        public string Username { get; }
        public string Password { get; }

        public AddUserRequest(int id, string name, DateTime birthdate, string password)
        {
            Id = id;
            Name = name;
            Birthdate = birthdate;
            Username = name;
            Password = password;
        }
    }
}
