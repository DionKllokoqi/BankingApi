using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class UserRepository(UserDbContext dbContext) : IUserRepository
{
    private readonly UserDbContext _dbContext = dbContext;

    public async Task AddAccount(Guid userId, Account account)
    {
        await _dbContext.Accounts.AddAsync(account);
    }

    public async Task<User> Create(string username, string password)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == username);
        if (user is not null)
        {
            throw new ArgumentException("User with this username already exists.");
        }

        user = new User(username, password);
        await _dbContext.Users.AddAsync(user);
        return user;
    }

    public Task<User?> GetById(Guid id)
    {
        return _dbContext.Users.Include(u => u.Accounts).FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}