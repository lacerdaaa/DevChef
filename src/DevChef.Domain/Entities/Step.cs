using DevChef.Domain.Common;

namespace DevChef.Domain.Entities;

public sealed class Step : ValueObject
{
    public int Order { get; }
    public string Instruction { get; }

    public Step(int order, string instruction)
    {
        if (order <= 0)
            throw new ArgumentOutOfRangeException(nameof(order), "Step order must be positive.");
        if (string.IsNullOrWhiteSpace(instruction))
            throw new ArgumentException("Instruction cannot be empty.");

        Order = order;
        Instruction = instruction.Trim();
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Order;
        yield return Instruction.ToLowerInvariant();
    }
}