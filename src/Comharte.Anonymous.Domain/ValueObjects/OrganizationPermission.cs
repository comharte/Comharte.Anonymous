namespace Comharte.Anonymous.Domain.ValueObjects;

public sealed class OrganizationPermission
{
    private static MemberType GetMemberType(Guid memberType)
        => MemberType.SingleOrDefault(memberType)
        ?? throw new UnauthorizedException($"Invalid organization permission type.");

    private const string SEPARATOR = "/";

    private int _hashCode;

    private readonly Guid _organizationGlobalId;

    private readonly MemberType _memberType;

    public OrganizationPermission(string permission)
    {
        var organizationPermissionParts = permission.Split(SEPARATOR);

        if (organizationPermissionParts.Length != 2)
        {
            throw new UnauthorizedException($"Invalid organization permission format.");
        }
        if (!Guid.TryParse(organizationPermissionParts[0], out var organizationGlobalId))
        {
            throw new UnauthorizedException($"Invalid organization globalId format.");
        }
        if (!Guid.TryParse(organizationPermissionParts[1], out var memberType))
        {
            throw new UnauthorizedException($"Invalid organization permission type.");
        }

        _organizationGlobalId = organizationGlobalId;
        _memberType = GetMemberType(memberType);
        _hashCode = HashCode.Combine(_organizationGlobalId, _memberType);
    }

    public OrganizationPermission(Guid organizationGlobalId, Guid memberType)
        : this(organizationGlobalId, GetMemberType(memberType))
    { }
    public OrganizationPermission(Guid organizationGlobalId, MemberType memberType)
    {
        _organizationGlobalId = organizationGlobalId;
        _memberType = memberType;
        _hashCode = HashCode.Combine(_organizationGlobalId, _memberType);
    }

    public Guid OrganizationGlobalId => _organizationGlobalId;

    public MemberType MemberType => _memberType;

    public override bool Equals(object? obj)
        => obj != null && obj is OrganizationPermission other && other._organizationGlobalId.Equals(_organizationGlobalId) && other._memberType.Equals(_memberType);

    public override int GetHashCode()
        => _hashCode;

    public override string ToString()
        => $"{_organizationGlobalId}{SEPARATOR}{_memberType}";
}
