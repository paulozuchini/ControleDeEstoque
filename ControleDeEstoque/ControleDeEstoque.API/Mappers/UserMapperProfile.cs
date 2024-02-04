using AutoMapper;
using ControleDeEstoque.API.Domain.Entities;
using ControleDeEstoque.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.API.Mappers
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            // CreateUserRequest -> User
            CreateMap<CreateUserRequest, User>();

            // UpdateUserRequest -> User
            CreateMap<UpdateUserRequest, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore both null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        if (x.DestinationMember.Name == "UserRole" && src.UserRole == null) return false;

                        return true;
                    }
                ));
        }
    }
}
