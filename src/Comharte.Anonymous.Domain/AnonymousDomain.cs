namespace Comharte.Anonymous.Domain;

internal class AnonymousDomain : IAnonymousDomain
{
    private readonly IUserContext _user;

    private readonly ITimeService _time;

    public AnonymousDomain(IUserContext user, ITimeService time)
    {
        _user = user;
        _time = time;
    }

    private Organization GrantAccess(Organization organization, Func<OrganizationAccess, Action<Organization>> validator)
    {
        var currentOrganizationPermissions = organization.GetMemberPermissions(_user.GlobalId);
        var permission = new OrganizationAccess(_user.Permissions, currentOrganizationPermissions);

        validator(permission)(organization);

        return organization;
    }

    public Organization OrganizationCreate(Guid globalId, string displayName)
    {
        var permission = new OrganizationAccess(_user.Permissions);

        permission.ThrowIfCreateDenied();

        return Organization.Create(globalId, displayName, _time.SystemDate(), _user.GlobalId)
            ._events.OnCreation();
    }

    public void OrganizationModify(Organization organization, string displayName)
        => GrantAccess(organization, permissions => permissions.ThrowIfModifyDenied)
            .Modify(displayName)
            ._events.OnModification();

    public void OrganizationDelete(Organization organization)
        => GrantAccess(organization, permissions => permissions.ThrowIfDeleteDenied)
            .Delete()
            ._events.OnDelete();

    public void OrganizationRecover(Organization organization)
        => GrantAccess(organization, permissions => permissions.ThrowIfRecoverDenied)
            .Recover()
            ._events.OnModification();


    public void OrganizationAddMember(Organization organization, Guid memberRef, Guid memberTypeRef)
        => GrantAccess(organization, permissions => permissions.ThrowIfAddMemberDenied)
            .AddMember(memberRef, memberTypeRef)
            ._events.OnModification();

    public void OrganizationRemoveMember(Organization organization, Guid memberRef, Guid memberTypeRef)
        => GrantAccess(organization, permissions => permissions.ThrowIfRemoveMemberDenied)
            .RemoveMember(memberRef, memberTypeRef)
            ._events.OnModification();
}