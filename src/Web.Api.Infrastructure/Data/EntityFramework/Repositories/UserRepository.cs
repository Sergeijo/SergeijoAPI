using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto;
using Web.Api.Core.Dto.GatewayResponses.Repositories;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Infrastructure.Data.Entities;


namespace Web.Api.Infrastructure.Data.EntityFramework.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserRepository(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> Create(User user, string password)
        {
            var appUser = _mapper.Map<AppUser>(user);
            var identityResult = await _userManager.CreateAsync(appUser, password);
            return new CreateUserResponse(Convert.ToInt32(appUser.Id), identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        }

        public async Task<List<User>> GetAll()
        {
            var allUsersTask = Task.Run(() => this.allUsers());
            return await allUsersTask;
        }

        public async Task<UpdateUserByIdResponse> Update(string userid, User user)
        {
            var appUser = _mapper.Map<AppUser>(user);
            await _userManager.DeleteAsync(await _userManager.FindByIdAsync(userid));
            var identityResult = await _userManager.CreateAsync(appUser, appUser.PasswordHash);
            return new UpdateUserByIdResponse(Convert.ToInt32(appUser.Id), identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        }

        public async Task<User> FindById(int id)
        {
            return _mapper.Map<User>(await _userManager.FindByIdAsync(id.ToString()));
        }

        public async Task<User> FindByName(string name)
        {
            return _mapper.Map<User>(await _userManager.FindByNameAsync(name));
        }

        public async Task<bool> DeleteById(int id)
        {
            IdentityResult resultado = await _userManager.DeleteAsync(await _userManager.FindByIdAsync(id.ToString()));
            return resultado.Succeeded;
        }

        public async Task<bool> CheckPassword(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(_mapper.Map<AppUser>(user), password);
        }

        private List<User> allUsers()
        {
            List<User> userListAux = new List<User>();
            foreach (AppUser userAux in _userManager.Users)
            {
                userListAux.Add(_mapper.Map<User>(userAux));
            }
            return _mapper.Map<List<User>>(userListAux);
        }
    }
}
