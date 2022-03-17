using CovidStat.Domain.Entities;
using System;
using System.Threading.Tasks;
using CovidStat.Application.DTOs;
using CovidStat.Application.DTOs.User;
using CovidStat.Application.Filters;


namespace CovidStat.Application.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<User> Authenticate(string email, string password);

        Task<GetUserDto> CreateUser(CreateUserDto dto);
        Task<bool> DeleteUser(Guid id);
        Task<GetUserDto> UpdatePassword(Guid id, UpdatePasswordDto dto);
        Task<PaginatedList<GetUserDto>> GetAllUsers(GetUsersFilter filter);
        Task<GetUserDto> GetUserById(Guid id);
    }
}
