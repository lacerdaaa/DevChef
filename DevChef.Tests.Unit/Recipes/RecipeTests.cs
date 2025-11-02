using DevChef.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace DevChef.Tests.Unit.Recipes;

public class RecipeTestsOk
{
    [Fact]
    public void Should_Create_Recipe_With_Valid_Data()
    {
        var ingredients = new List<Ingredient>
        {
            new("Eggs", 3, "unit"),
            new("Flour", 500, "g")
        };

        var steps = new List<Step>
        {
            new(1, "Beat the eggs"),
            new(2, "Mix with flour")
        };

        var cuisineId = Guid.NewGuid();
        var authorId = Guid.NewGuid();

        var recipe = new Recipe(
            "Pancake",
            "Delicious breakfast",
            "https://cdn.devchef.app/pancake.jpg",
            TimeSpan.FromMinutes(20),
            2,
            cuisineId,
            authorId,
            ingredients,
            steps
        );

        recipe.Title.Should().Be("Pancake");
        recipe.Ingredients.Should().HaveCount(2);
        recipe.Steps.Should().HaveCount(2);
        recipe.PhotoUrl.Should().NotBeNullOrWhiteSpace();
    }
}