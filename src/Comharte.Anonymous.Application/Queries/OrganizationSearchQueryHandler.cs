namespace Comharte.Anonymous.Application.Queries;

public class OrganizationSearchQueryHandler : IQueryHandler<OrganizationSearchQuery, OrganizationSearchQueryResult>
{
    private readonly IRepository<OrganizationView> _repository;

    private readonly IIdentityContext _user;

    public OrganizationSearchQueryHandler(IRepository<OrganizationView> repository, IIdentityContext identityContext)
    {
        _repository = repository;
        _user = identityContext;
    }
    public async Task<OrganizationSearchQueryResult> Handle(OrganizationSearchQuery request)
    {
        var views = await _repository.List(new OrganizationViewQuerySpecification(_user.GlobalId));

        return [.. views.ToModel()];
    }
}