using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<User> Create(string username, string password);
}