namespace Comharte.Anonymous.Application.Commands;

internal class OrganizationRecoverCommandHandler : ICommandHandler<OrganizationRecoverCommand, CommandEmptyResult>
{
    private readonly IAnonymousDomain _domain;

    private readonly IRepository<Organization> _repository;

    public OrganizationRecoverCommandHandler(IAnonymousDomain domain, IRepository<Organization> repository)
    {
        _domain = domain;
        _repository = repository;
    }

    public async Task<CommandEmptyResult> Handle(OrganizationRecoverCommand request)
    {
        var organization = await _repository.Single(request.GlobalId);

        _domain.OrganizationRecover(organization);

        return this.CreateEmptyResult();
    }
}