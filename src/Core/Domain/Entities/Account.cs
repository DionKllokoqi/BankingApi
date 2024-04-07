namespace Domain.Entities;

public class Account
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string? Name { get; private set; }
    public decimal Balance { get; private set; }
    public Guid UserId { get; private set; }
    public User? User { get; private set; }

    public static Account Create(Guid userId, string name, decimal initialBalance)
    {
        if (initialBalance < 100)
        {
            throw new ArgumentException("Balance cannot be less than 100", nameof(initialBalance));
        }

        return new Account
        {
            UserId = userId,
            Name = name,
            Balance = initialBalance
        };
    }
}