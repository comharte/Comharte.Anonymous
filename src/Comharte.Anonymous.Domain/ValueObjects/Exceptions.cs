namespace Comharte.Anonymous.Domain.ValueObjects;

public class DisplayNameInvalidValueException : InvalidRequestException
{
    public DisplayNameInvalidValueException(string displayName)
        : base($"Display name '{displayName}' is invalid.")
    { }
}

public class MemberInvalidGlobalIdException : InvalidRequestException
{
    public MemberInvalidGlobalIdException(Guid globalId)
        : base($"Member global ID '{globalId}' is invalid.")
    { }
}

public class GlobalIdInvalidValueException : InvalidRequestException
{
    public GlobalIdInvalidValueException(Guid globalId)
        : base($"GlobalId '{globalId}' is invalid.")
    { }
}