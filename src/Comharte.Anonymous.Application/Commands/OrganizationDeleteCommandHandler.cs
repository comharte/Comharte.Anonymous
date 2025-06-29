namespace Comharte.Anonymous.Application.Commands;

internal class OrganizationDeleteCommandHandler : ICommandHandler<OrganizationDeleteCommand, CommandEmptyResult>
{
    private readonly IAnonymousDomain _domain;

    private readonly IRepository<Organization> _repository;

    public OrganizationDeleteCommandHandler(IAnonymousDomain domain, IRepository<Organization> repository)
    {
        _domain = domain;
        _repository = repository;
    }

    public async Task<CommandEmptyResult> Handle(OrganizationDeleteCommand request)
    {
        var organization = await _repository.Single(request.GlobalId);

        _domain.OrganizationDelete(organization);

        return this.CreateEmptyResult();
    }
}