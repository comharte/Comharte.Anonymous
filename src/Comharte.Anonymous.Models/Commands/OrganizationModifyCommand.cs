namespace Comharte.Anonymous.Models.Commands;

public class OrganizationModifyCommandEndpointDescriptor : CommandV1EndpointDescriptor<OrganizationModifyCommand>
{
    public const string ROUTE = "organization/modify";

    public OrganizationModifyCommandEndpointDescriptor() : base(ROUTE)
    { }
}

public class OrganizationModifyCommand : ICommand
{
    public Guid GlobalId { get; set; }

    public string DisplayName { get; set; } = string.Empty;
}