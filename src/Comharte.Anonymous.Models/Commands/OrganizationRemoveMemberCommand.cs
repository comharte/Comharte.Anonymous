namespace Comharte.Anonymous.Models.Commands;

public class OrganizationRemoveMemberCommandEndpointDescriptor : CommandV1EndpointDescriptor<OrganizationRemoveMemberCommand>
{
    public const string ROUTE = "organization/removeMember";
    public OrganizationRemoveMemberCommandEndpointDescriptor() : base(ROUTE)
    { }
}

public class OrganizationRemoveMemberCommand : ICommand
{
    public Guid GlobalId { get; set; }

    public Guid MemberRef { get; set; }

    public Guid MemberType { get; set; }
}