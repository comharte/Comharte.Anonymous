namespace Comharte.Anonymous.Models.Commands;

public class OrganizationCreateCommandEndpointDescriptor : CommandV1EndpointDescriptor<OrganizationCreateCommand>
{
    public const string ROUTE = "organization/create";
    public OrganizationCreateCommandEndpointDescriptor() : base(ROUTE)
    { }
}

public class OrganizationCreateCommand : ICommand
{
    public Guid GlobalId { get; set; }

    public string DisplayName { get; set; } = string.Empty;

}
