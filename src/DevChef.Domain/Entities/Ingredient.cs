using DevChef.Domain.Common;

namespace DevChef.Domain.Entities;

public sealed class Ingredient : ValueObject
{
    public string Name { get; }
    public decimal Quantity { get; }
    public string Unit { get; }

    public Ingredient(string name, decimal quantity, string unit)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Ingredient name cannot be empty.");
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than 0.");
        if (string.IsNullOrWhiteSpace(unit))
            throw new ArgumentException("Unit cannot be empty.");

        Name = name.Trim();
        Quantity = quantity;
        Unit = unit.Trim();
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Name.ToLowerInvariant();
        yield return Quantity;
        yield return Unit.ToLowerInvariant();
    }

    public override string ToString() => $"{Quantity} {Unit} {Name}";
}