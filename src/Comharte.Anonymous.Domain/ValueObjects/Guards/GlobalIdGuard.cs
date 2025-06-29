namespace Comharte.Anonymous.Domain.ValueObjects.Guards;

public class GlobalIdGuard
{
    public static implicit operator Guid(GlobalIdGuard globalId) => globalId.Value;

    public static implicit operator GlobalIdGuard(Guid value) => new(value);

    public static GlobalIdGuard Create(Guid value)
        => new(value);

    public GlobalIdGuard(Guid value)
    {
        if (value.Equals(Guid.Empty))
        {
            throw new GlobalIdInvalidValueException(value);
        }

        Value = value;
    }

    public Guid Value { get; }

    public override string ToString() => Value.ToString();

    public override bool Equals(object? obj)
        => obj != null && obj is GlobalIdGuard other && Value.Equals(other.Value);

    public override int GetHashCode()
        => Value.GetHashCode();
}