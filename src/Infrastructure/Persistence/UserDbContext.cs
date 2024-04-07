using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}