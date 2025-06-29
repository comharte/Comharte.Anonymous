namespace Comharte.Anonymous.Application.Commands;

internal class OrganizationRemoveMemberCommandHandler : ICommandHandler<OrganizationRemoveMemberCommand, CommandEmptyResult>
{
    private readonly IAnonymousDomain _domain;

    private readonly IRepository<Organization> _repository;

    public OrganizationRemoveMemberCommandHandler(IAnonymousDomain domain, IRepository<Organization> repository)
    {
        _domain = domain;
        _repository = repository;
    }

    public async Task<CommandEmptyResult> Handle(OrganizationRemoveMemberCommand request)
    {
        var organization = await _repository.Single(request.GlobalId);

        _domain.OrganizationRemoveMember(organization,
            request.MemberRef,
            MemberType.Single(request.MemberType));

        return this.CreateEmptyResult();
    }
}