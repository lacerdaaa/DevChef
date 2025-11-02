using DevChef.Domain.Common;

namespace DevChef.Domain.Entities;

public sealed class Favorite : Entity
{
    public Guid RecipeId { get; private set; }
    public Guid UserId { get; private set; }

    private Favorite() { }

    public Favorite(Guid recipeId, Guid userId)
    {
        RecipeId = recipeId;
        UserId = userId;
    }
}