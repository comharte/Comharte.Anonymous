namespace Comharte.Anonymous.Models.Commands;

public class OrganizationDeleteCommandEndpointDescriptor : CommandV1EndpointDescriptor<OrganizationDeleteCommand>
{
    public const string ROUTE = "organization/delete";

    public OrganizationDeleteCommandEndpointDescriptor() : base(ROUTE) 
    { }
}

public class OrganizationDeleteCommand : ICommand
{
    public Guid GlobalId { get; set; }
}