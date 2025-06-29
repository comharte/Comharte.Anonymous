namespace Comharte.Anonymous.Models.Commands;

public class OrganizationRecoverCommandEndpointDescriptor : CommandV1EndpointDescriptor<OrganizationRecoverCommand>
{
    public const string ROUTE = "organization/recover";

    public OrganizationRecoverCommandEndpointDescriptor() : base(ROUTE) 
    { }
}

public class OrganizationRecoverCommand : ICommand
{
    public Guid GlobalId { get; set; }
}