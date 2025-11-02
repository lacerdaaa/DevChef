using DevChef.Domain.Common;
using DevChef.Domain.Enums;

namespace DevChef.Domain.Entities;

public sealed class User : Entity
{
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string PasswordHash { get; private set; } = default!;
    public Role Role { get; private set; }

    private User() { }

    public User(string name, string email, string passwordHash, Role role = Role.User)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required.");
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email is required.");
        if (string.IsNullOrWhiteSpace(passwordHash)) throw new ArgumentException("Password hash is required.");

        Name = name.Trim();
        Email = email.Trim().ToLowerInvariant();
        PasswordHash = passwordHash;
        Role = role;
    }

    public void PromoteToChef()
    {
        if (Role == Role.Admin)
            throw new InvalidOperationException("Admin cannot be changed.");
        Role = Role.Chef;
        Touch();
    }

    public void PromoteToAdmin() => Role = Role.Admin;
}