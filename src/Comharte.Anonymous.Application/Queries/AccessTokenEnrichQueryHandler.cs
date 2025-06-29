namespace Comharte.Anonymous.Application.Queries;

internal class AccessTokenEnrichQueryHandler : IQueryHandler<AccessTokenEnrichQuery, AccessTokenEnrichQueryResult>
{
    private const string VERSION = "1.0.0";

    private const string ACTION = "Comharte.Anonymous.Application.AccessTokenEnrichQueryHandler.Handle()";

    private readonly ILogger<AccessTokenEnrichQueryHandler> _logger;

    private readonly MemberOrganizationAccessService _organizationAccessService;

    public AccessTokenEnrichQueryHandler(MemberOrganizationAccessService organizationAccessService, ILogger<AccessTokenEnrichQueryHandler> logger)
    {
        _organizationAccessService = organizationAccessService;
        _logger = logger;
    }

    public Task<AccessTokenEnrichQueryResult> Handle(AccessTokenEnrichQuery request)
    {
        try
        {
            if (string.IsNullOrEmpty(request.ObjectId)
                || Guid.TryParse(request.ObjectId, out var memberRef))
            {
                throw new InvalidRequestException("Invalid ObjectId provided for access token enrichment.");
            }

            var organizations = _organizationAccessService.CreateOrganizationAccess(memberRef);


            return CreateSuccessResult(organizations);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to enrich access token");
            return CreateErrorResult();
        }
    }

    private Task<AccessTokenEnrichQueryResult> CreateErrorResult()
        => Task.FromResult(new AccessTokenEnrichQueryResult()
        {
            Version = VERSION,
            IsError = true,
            Action = ACTION
        });

    private Task<AccessTokenEnrichQueryResult> CreateSuccessResult(string organizations)
        => Task.FromResult(new AccessTokenEnrichQueryResult()
        {
            Version = VERSION,
            IsError = true,
            Action = ACTION,
            extension_Organizations = organizations
        });
}