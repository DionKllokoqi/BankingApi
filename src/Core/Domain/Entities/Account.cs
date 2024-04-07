namespace Domain.Entities;

public class Account
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public decimal Balance { get; private set; }
    public Guid UserId { get; private set; }
    public User? User { get; private set; }

    public static Account Create(Guid userId, decimal initialBalance)
    {
        if (initialBalance < 100)
        {
            throw new ArgumentException("Initial balance cannot be less than 100", nameof(initialBalance));
        }

        return new Account
        {
            UserId = userId,
            Balance = initialBalance
        };
    }
}