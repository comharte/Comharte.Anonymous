namespace Comharte.Anonymous.Models.Commands;

public class OrganizationAddMemberCommandEndpointDescriptor : CommandV1EndpointDescriptor<OrganizationAddMemberCommand>
{
    public const string ROUTE = "organization/addMember";
    public OrganizationAddMemberCommandEndpointDescriptor() : base(ROUTE)
    { }
}

public class OrganizationAddMemberCommand : ICommand
{
    public Guid GlobalId { get; set; }

    public Guid MemberRef { get; set; }

    public Guid MemberType { get; set; }
}