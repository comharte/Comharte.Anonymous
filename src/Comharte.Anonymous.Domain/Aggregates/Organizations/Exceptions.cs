namespace Comharte.Anonymous.Domain.Aggregates.Organizations;

public class OrganizationMemberInvalidReferenceException : InvalidRequestException
{
    public const string MESSAGE_FORMAT = "Invalid member reference: {0}";

    public OrganizationMemberInvalidReferenceException(Guid memberRef)
        : base(string.Format(MESSAGE_FORMAT, memberRef))
    { }
}

public class OrganizationMemberAlreadyExistsException : InvalidRequestException
{
    public const string MESSAGE = "Member with same role already exists in organization";

    public OrganizationMemberAlreadyExistsException()
        : base(MESSAGE)
    { }
}

public class OrganizationMemberNotFoundException : InvalidRequestException
{
    public const string MESSAGE = "Member not found";

    public OrganizationMemberNotFoundException()
        : base(MESSAGE)
    { }
}

public class OrganizationCannotRemoveLastOwnerException : InvalidRequestException
{
    public const string MESSAGE = "Cannot remove last owner";

    public OrganizationCannotRemoveLastOwnerException()
        : base(MESSAGE)
    { }
}

public class OrganizationAlreadyDeletedException : InvalidRequestException
{
    public const string MESSAGE = "Organization is already deleted";
    public OrganizationAlreadyDeletedException()
        : base(MESSAGE)
    { }
}

public class OrganizationAlreadyActiveException : InvalidRequestException
{
    public const string MESSAGE = "Organization is already active";
    public OrganizationAlreadyActiveException()
        : base(MESSAGE)
    { }
}
