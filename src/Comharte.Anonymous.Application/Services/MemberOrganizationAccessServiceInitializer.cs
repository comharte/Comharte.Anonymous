namespace Comharte.Anonymous.Application.Services;

internal class MemberOrganizationAccessServiceInitializer
{
    private readonly MemberOrganizationAccessService _service;

    private readonly IRepository<MemberOrganizationPermissionView> _repository;

    public MemberOrganizationAccessServiceInitializer(MemberOrganizationAccessService service, IRepository<MemberOrganizationPermissionView> repository)
    {
        _service = service;
        _repository = repository;
    }

    public async Task Initialize()
    {
        var views = await _repository.List(new Query<MemberOrganizationPermissionView>());

        _service.Update(views);
    }

    public async Task Reload(IEnumerable<Guid> memberRefs)
    {
        var views = await _repository.List(new Query<MemberOrganizationPermissionView>()
        {
            Where = view => memberRefs.Contains(view.MemberRef)
        });

        _service.Update(views);
    }
}