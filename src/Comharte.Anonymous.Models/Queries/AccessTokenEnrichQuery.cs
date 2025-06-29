namespace Comharte.Anonymous.Models.Queries;

public class AccessTokenEnrichQueryEndpointDescriptor : QueryV1EndpointDescriptor<AccessTokenEnrichQuery, AccessTokenEnrichQueryResult>
{
    public const string ROUTE = "organization/search";
    public AccessTokenEnrichQueryEndpointDescriptor() : base(ROUTE)
    { }
}

public class AccessTokenEnrichQuery : IQuery<AccessTokenEnrichQueryResult>
{
    public string? ObjectId { get; set; }
}

public class AccessTokenEnrichQueryResult : IQueryResult
{
    public string? Version { get; set; }

    public string? Action { get; set; }

    public bool? IsError { get; set; }

    public string? extension_Organizations { get; set; }
}