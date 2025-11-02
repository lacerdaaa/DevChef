using DevChef.Domain.Common;

namespace DevChef.Domain.Entities;

public sealed class Rating : Entity
{
    public Guid RecipeId { get; private set; }
    public Guid UserId { get; private set; }
    public int Stars { get; private set; }
    public string? Comment { get; private set; }

    private Rating() { }

    public Rating(Guid recipeId, Guid userId, int stars, string? comment = null)
    {
        if (stars is < 1 or > 5)
            throw new ArgumentOutOfRangeException(nameof(stars), "Rating must be between 1 and 5 stars.");

        RecipeId = recipeId;
        UserId = userId;
        Stars = stars;
        Comment = comment?.Trim();
    }

    public void Update(int stars, string? comment)
    {
        if (stars is < 1 or > 5)
            throw new ArgumentOutOfRangeException(nameof(stars), "Rating must be between 1 and 5.");
        Stars = stars;
        Comment = comment?.Trim();
        Touch();
    }
}