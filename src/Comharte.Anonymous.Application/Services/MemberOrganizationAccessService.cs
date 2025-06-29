namespace Comharte.Anonymous.Application.Services;

internal class MemberOrganizationAccessService
{
    private readonly ILogger<MemberOrganizationAccessService> _logger;

    private readonly object _accessLock = new();

    private ConcurrentDictionary<Guid, OrganizationAccess> _access = [];

    public MemberOrganizationAccessService(ILogger<MemberOrganizationAccessService> logger)
    {
        _logger = logger;
    }

    public void Update(IEnumerable<MemberOrganizationPermissionView> permissionViews)
    {
        lock (_accessLock)
        {
            foreach (var permissionViewGroup in permissionViews.GroupBy(pv => pv.MemberRef))
            {
                var memberRef = permissionViewGroup.Key;
                var pemissions = permissionViewGroup.Select(pv => new OrganizationPermission(pv.OrganizationGlobalId, pv.MemberTypeGlobalId));
                var access = new OrganizationAccess(pemissions);

                _access.TryRemove(memberRef, out _);

                if (!_access.TryAdd(memberRef, access))
                {
                    _logger.LogCritical("Failed to update organization access for member {MemberRef}", memberRef);
                }
            }
        }
    }

    public string CreateOrganizationAccess(Guid memberRef)
        => _access.TryGetValue(memberRef, out var access)
            ? access.ToString()
            : string.Empty;
}