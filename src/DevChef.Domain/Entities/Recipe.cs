using DevChef.Domain.Common;

namespace DevChef.Domain.Entities;

public sealed class Recipe : Entity
{
    private readonly List<Ingredient> _ingredients = new();
    private readonly List<Step> _steps = new();
    private readonly List<Guid> _favoritedBy = new();

    public string Title { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public string PhotoUrl { get; private set; } = default!;
    public TimeSpan PrepTime { get; private set; }
    public int Servings { get; private set; }
    public Guid CuisineId { get; private set; }
    public Guid AuthorId { get; private set; }

    public IReadOnlyCollection<Ingredient> Ingredients => _ingredients.AsReadOnly();
    public IReadOnlyCollection<Step> Steps => _steps.AsReadOnly();
    public IReadOnlyCollection<Guid> FavoritedBy => _favoritedBy.AsReadOnly();

    private Recipe() { }

    public Recipe(
        string title,
        string description,
        string photoUrl,
        TimeSpan prepTime,
        int servings,
        Guid cuisineId,
        Guid authorId,
        IEnumerable<Ingredient> ingredients,
        IEnumerable<Step> steps)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required.");
        if (string.IsNullOrWhiteSpace(photoUrl))
            throw new ArgumentException("Photo is required.");
        if (prepTime <= TimeSpan.Zero)
            throw new ArgumentOutOfRangeException(nameof(prepTime));
        if (servings <= 0)
            throw new ArgumentOutOfRangeException(nameof(servings));
        if (!ingredients.Any())
            throw new ArgumentException("At least one ingredient is required.");
        if (!steps.Any())
            throw new ArgumentException("At least one step is required.");

        Title = title.Trim();
        Description = description?.Trim() ?? "";
        PhotoUrl = photoUrl.Trim();
        PrepTime = prepTime;
        Servings = servings;
        CuisineId = cuisineId;
        AuthorId = authorId;

        _ingredients.AddRange(ingredients);
        _steps.AddRange(steps);
    }

    public void AddFavorite(Guid userId)
    {
        if (_favoritedBy.Contains(userId))
            throw new InvalidOperationException("Already favorited.");
        _favoritedBy.Add(userId);
        Touch();
    }

    public void RemoveFavorite(Guid userId)
    {
        _favoritedBy.Remove(userId);
        Touch();
    }
}
