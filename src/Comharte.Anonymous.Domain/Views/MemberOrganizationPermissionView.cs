namespace Comharte.Anonymous.Domain.Views;

public class MemberOrganizationPermissionView
{
    private MemberOrganizationPermissionView(Guid memberRef, Guid memberTypeGlobalId, Guid organizationGlobalId)
    {
        MemberRef = memberRef;
        MemberTypeGlobalId = memberTypeGlobalId;
        OrganizationGlobalId = organizationGlobalId;
    }

    public Guid MemberRef { get; private set; }

    public Guid MemberTypeGlobalId { get; private set; }

    public Guid OrganizationGlobalId { get; private set; }
}
