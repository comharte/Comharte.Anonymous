namespace Comharte.Anonymous.Application.Commands;

internal class OrganizationCreateCommandHandler : ICommandHandler<OrganizationCreateCommand, CommandEmptyResult>
{
    private readonly IRepository<Organization> _repository;

    private readonly IAnonymousDomain _domain;

    public OrganizationCreateCommandHandler(IRepository<Organization> repository, IAnonymousDomain domain)
    {
        _repository = repository;
        _domain = domain;
    }

    public async Task<CommandEmptyResult> Handle(OrganizationCreateCommand request)
    {
        var organization = _domain.OrganizationCreate(request.GlobalId, request.DisplayName);

        await _repository.Add(organization);

        return this.CreateEmptyResult();
    }
}