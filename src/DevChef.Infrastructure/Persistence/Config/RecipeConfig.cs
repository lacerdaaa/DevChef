using DevChef.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevChef.Infrastructure.Persistence.Config;

public class RecipeConfig : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.ToTable("recipes");
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Title)
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(r => r.Description)
            .HasMaxLength(500);

        builder.Property(r => r.PhotoUrl)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(r => r.PrepTime)
            .IsRequired();

        builder.Property(r => r.Servings)
            .IsRequired();

        builder.Property(r => r.CuisineId)
            .IsRequired();

        builder.Property(r => r.AuthorId)
            .IsRequired();

        builder.Property<DateTime>("CreatedAtUtc")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        
        builder.OwnsMany(r => r.Ingredients, i =>
        {
            i.ToTable("recipe_ingredients");

            i.WithOwner().HasForeignKey("RecipeId");
            i.Property<int>("Id");
            i.HasKey("Id");

            i.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            i.Property(x => x.Quantity)
                .HasColumnType("numeric(10,2)")
                .IsRequired();

            i.Property(x => x.Unit)
                .IsRequired()
                .HasMaxLength(20);
        });
        
        builder.OwnsMany(r => r.Steps, s =>
        {
            s.ToTable("recipe_steps");

            s.WithOwner().HasForeignKey("RecipeId");
            s.Property<int>("Id");
            s.HasKey("Id");

            s.Property(x => x.Order)
                .IsRequired();

            s.Property(x => x.Instruction)
                .IsRequired()
                .HasMaxLength(400);
        });
        
        builder.OwnsMany<Ingredient>(r => r.Ingredients, i =>
        {
            i.ToTable("recipe_ingredients");

            i.WithOwner().HasForeignKey("RecipeId");
            i.Property<int>("Id");
            i.HasKey("Id");

            i.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            i.Property(x => x.Quantity)
                .HasColumnType("numeric(10,2)")
                .IsRequired();

            i.Property(x => x.Unit)
                .IsRequired()
                .HasMaxLength(20);
        });

    }
}
