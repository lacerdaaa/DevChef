using DevChef.Domain.Common;

namespace DevChef.Domain.Entities;

public sealed class Cuisine : Entity
{
    public string Name { get; private set; } = default!;
    public Guid? ParentCuisineId { get; private set; }

    private Cuisine() { }

    public Cuisine(string name, Guid? parentCuisineId = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Cuisine name cannot be empty.");

        Name = name.Trim();
        ParentCuisineId = parentCuisineId;
    }

    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("Cuisine name cannot be empty.");

        Name = newName.Trim();
        Touch();
    }
}