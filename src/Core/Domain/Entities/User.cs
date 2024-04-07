namespace Domain.Entities;

public class User(string userName, string password)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string UserName { get; private set; } = userName;
    public string Password { get; private set; } = password;
    public string Role { get; } = "user";
    public ICollection<Account>? Accounts { get; set; }

    public void AddAccount(string name, decimal initialBalance)
    {
        Accounts ??= [];

        if (Accounts.Any(a => a.Name == name))
        {
            throw new ArgumentException("Account with this name already exists.");
        }

        var account = Account.Create(Id, name, initialBalance);
        Accounts.Add(account);
    }
}