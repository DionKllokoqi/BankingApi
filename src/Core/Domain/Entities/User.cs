namespace Domain.Entities;

public class User(string userName, string password)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string UserName { get; private set; } = userName;
    public string Password { get; private set; } = password;
    public string Role { get; } = "user";
    public IEnumerable<Account>? Accounts { get; set; }
}