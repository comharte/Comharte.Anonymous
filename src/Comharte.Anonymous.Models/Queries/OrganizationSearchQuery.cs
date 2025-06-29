using static Comharte.Anonymous.Models.Queries.OrganizationSearchQueryResult;

namespace Comharte.Anonymous.Models.Queries;

public class OrganizationSearchQueryEndpointDescriptor : QueryV1EndpointDescriptor<OrganizationSearchQuery, OrganizationSearchQueryResult>
{
    public const string ROUTE = "organization/search";
    public OrganizationSearchQueryEndpointDescriptor() : base(ROUTE)
    { }
}

public class OrganizationSearchQuery : IQuery<OrganizationSearchQueryResult>
{
}


public class OrganizationSearchQueryResult : List<OrganizationModel>, IQueryResult
{
    public class OrganizationMemberModel
    {
        public Guid MemberRef { get; set; } = Guid.Empty;

        public Guid MemberTypeGlobalId { get; set; } = Guid.Empty;

        public string MemberTypeUniqueCode { get; set; } = string.Empty;

    }
    public class OrganizationModel
    {
        public Guid GlobalId { get; set; }

        public string DisplayName { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;

        public DateTime CreationDate { get; set; }

        public Guid CreationUser { get; set; } = Guid.Empty;

        public List<OrganizationMemberModel> Members { get; set; } = new List<OrganizationMemberModel>();
    }

    public OrganizationSearchQueryResult(IEnumerable<OrganizationModel> item)
        : base(item) { }

    public OrganizationSearchQueryResult()
    { }
}