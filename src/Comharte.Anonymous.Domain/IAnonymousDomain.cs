namespace Comharte.Anonymous.Domain;

public interface IAnonymousDomain
{
    public Organization OrganizationCreate(Guid globalId, string displayName);

    public void OrganizationModify(Organization organization, string displayName);

    public void OrganizationDelete(Organization organization);

    public void OrganizationRecover(Organization organization);

    public void OrganizationAddMember(Organization organization, Guid memberRef, Guid memberTypeRef);

    public void OrganizationRemoveMember(Organization organization, Guid memberRef, Guid memberTypeRef);
}