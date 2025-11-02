using DevChef.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevChef.Infrastructure.Persistence.Config;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(80);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(120);

        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.PasswordHash)
            .IsRequired();

        builder.Property(u => u.Role)
            .IsRequired();

        builder.Property(u => u.CreatedAtUtc)
            .IsRequired();
    }
}