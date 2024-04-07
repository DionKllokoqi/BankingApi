using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(e => e.Accounts)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .HasPrincipalKey(e => e.Id);
    }


    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }
}