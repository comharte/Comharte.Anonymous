namespace Comharte.Anonymous.Domain.ValueObjects.Guards;

public class NameStringGuard
{
    public static implicit operator string(NameStringGuard displayName) => displayName.Value;

    public static implicit operator NameStringGuard(string value) => new(value);

    public NameStringGuard(string value)
    {
        if (string.IsNullOrWhiteSpace(value)
            || value.Length > 60)
        {
            throw new DisplayNameInvalidValueException(value);
        }

        Value = value;
    }

    public string Value { get; private set; }
}