namespace Comharte.Anonymous.Application.Commands;

internal class OrganizationAddMemberCommandHandler : ICommandHandler<OrganizationAddMemberCommand, CommandEmptyResult>
{
    private readonly IAnonymousDomain _domain;

    private readonly IRepository<Organization> _repository;

    public OrganizationAddMemberCommandHandler(IAnonymousDomain domain, IRepository<Organization> repository)
    {
        _domain = domain;
        _repository = repository;
    }

    public async Task<CommandEmptyResult> Handle(OrganizationAddMemberCommand request)
    {
        var organization = await _repository.Single(request.GlobalId);

        _domain.OrganizationAddMember(organization,
            request.MemberRef,
            MemberType.Single(request.MemberType));

        return this.CreateEmptyResult();
    }
}