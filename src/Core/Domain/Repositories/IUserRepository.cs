using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<User> Create(string username, string password);
    Task<User?> GetById(Guid id);
    Task AddAccount(Guid userId, Account account);
    Task DeleteAccount(Guid userId, string accountName);
    Task SaveChangesAsync();
}