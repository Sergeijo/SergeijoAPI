using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto.GatewayResponses.Repositories;

namespace Web.Api.Core.Interfaces.Gateways.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> FindById(int id);
        Task<User> FindByName(string name);
        Task<CreateUserResponse> Create(User user, string password);
        Task<UpdateUserByIdResponse> Update(string userid, User user);
        Task<bool> DeleteById(int id);
        Task<bool> CheckPassword(User user, string password);
    }
}
