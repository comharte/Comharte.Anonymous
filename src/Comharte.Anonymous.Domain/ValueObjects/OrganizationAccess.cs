namespace Comharte.Anonymous.Domain.ValueObjects;

public sealed class OrganizationAccess
{
    private const string SEPARATOR = ";";

    private readonly ImmutableHashSet<OrganizationPermission> _organizationPermissions;

    public OrganizationAccess(IEnumerable<OrganizationPermission> organizationPermissions)
    {
        _organizationPermissions = [.. organizationPermissions.Distinct()];
    }
    public OrganizationAccess(string organizations)
        : this(organizations.Split(SEPARATOR))
    { }

    public OrganizationAccess(IEnumerable<string> organizations, IEnumerable<OrganizationPermission> additionalPermissions)
        : this(organizations.Select(organization => new OrganizationPermission(organization)).Concat(additionalPermissions))
    { }

    public OrganizationAccess(IEnumerable<string> organizations)
        : this(organizations, [])
    { }

    public override string ToString()
        => string.Join(SEPARATOR, _organizationPermissions.Select(op => op.ToString()));

    private void ThrowIfNotMemberOf(IEnumerable<OrganizationPermission> organizationPermissions)
        => _ = organizationPermissions.Any(organizationPermission => _organizationPermissions.Contains(organizationPermission))
            ? true
            : throw new AccessDeniedException($"Organization insufficient permission.");

    public void ThrowIfNotMemberOf(Organization organization, params MemberType[] memberTypes)
        => ThrowIfNotMemberOf(memberTypes.Select(memberType => new OrganizationPermission(organization.GlobalId, memberType)));

    public void ThrowIfDeleteDenied(Organization organization)
        => ThrowIfNotMemberOf(organization, MemberType.Owner);

    public void ThrowIfRecoverDenied(Organization organization)
        => ThrowIfNotMemberOf(organization, MemberType.Owner);

    public void ThrowIfModifyDenied(Organization organization)
        => ThrowIfNotMemberOf(organization, MemberType.Owner);

    public void ThrowIfAddMemberDenied(Organization organization)
        => ThrowIfNotMemberOf(organization, MemberType.Owner);

    public void ThrowIfRemoveMemberDenied(Organization organization)
        => ThrowIfNotMemberOf(organization, MemberType.Owner);

    public void ThrowIfCreateDenied()
        => _ = _organizationPermissions.Select(op => op.OrganizationGlobalId).Distinct().Count() >= 3
            ? throw new AccessDeniedException($"Insufficient permission to create more than 3 organizations.")
            : true;
}