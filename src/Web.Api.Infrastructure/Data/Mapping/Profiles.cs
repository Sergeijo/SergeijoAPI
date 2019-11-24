using System;
using AutoMapper;
using Web.Api.Core.Domain.Entities;
using Web.Api.Infrastructure.Data.Entities;


namespace Web.Api.Infrastructure.Data.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<User, AppUser>().ConstructUsing(u => new AppUser { Id = u.Id.ToString(), Name = u.Name, Birthdate = u.Birthdate, UserName = u.Name, PasswordHash = u.Password });
            CreateMap<AppUser, User>().ConstructUsing(au => new User(Convert.ToInt32(au.Id), au.Name, au.Birthdate, au.PasswordHash));
        }
    }
}
