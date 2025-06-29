namespace Comharte.Anonymous.Domain.Views;

public class OrganizationMemberView
{
    public OrganizationMemberView(int organizationId, Guid memberRef, Guid memberTypeGlobalId)
    {
        OrganizationId = organizationId;
        MemberRef = memberRef;
        MemberTypeGlobalId = memberTypeGlobalId;
    }

    public int OrganizationId { get; private set; }

    public Guid MemberRef { get; private set; }

    public Guid MemberTypeGlobalId { get; private set; }

}