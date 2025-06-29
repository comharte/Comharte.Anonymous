namespace Comharte.Anonymous.Application.Commands;

internal class OrganizationModifyCommandHandler : ICommandHandler<OrganizationModifyCommand, CommandEmptyResult>
{
    private readonly IRepository<Organization> _repository;

    private readonly IAnonymousDomain _domain;

    public OrganizationModifyCommandHandler(IRepository<Organization> repository, IAnonymousDomain domain)
    {
        _repository = repository;
        _domain = domain;
    }

    public async Task<CommandEmptyResult> Handle(OrganizationModifyCommand request)
    {
        var organization = await _repository.Single(request.GlobalId);

        _domain.OrganizationModify(organization, request.DisplayName);

        return this.CreateEmptyResult();
    }
}