using DevChef.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevChef.Infrastructure.Persistence.Config;

public class RatingConfig : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.ToTable("ratings", tableBuilder =>
        {
            tableBuilder.HasCheckConstraint("CK_ratings_stars_range", "\"Stars\" BETWEEN 1 AND 5");
        });
        builder.HasKey(r => r.Id);

        builder.Property(r => r.RecipeId)
            .IsRequired();

        builder.Property(r => r.UserId)
            .IsRequired();

        builder.Property(r => r.Stars)
            .IsRequired();

        builder.Property(r => r.Comment)
            .HasMaxLength(500);

        builder.Property(r => r.CreatedAtUtc)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(r => r.UpdatedAtUtc);

        builder.HasIndex(r => new { r.RecipeId, r.UserId })
            .IsUnique();
    }
}
