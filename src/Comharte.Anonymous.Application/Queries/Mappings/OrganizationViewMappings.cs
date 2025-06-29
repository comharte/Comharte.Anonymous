namespace Comharte.Anonymous.Application.Queries.Mappings;

public static class OrganizationViewMappings
{
    public static OrganizationSearchQueryResult.OrganizationMemberModel ToModel(this OrganizationMemberView view)
        => new OrganizationSearchQueryResult.OrganizationMemberModel
        {
            MemberRef = view.MemberRef,
            MemberTypeGlobalId = view.MemberTypeGlobalId,
            MemberTypeUniqueCode = MemberType.Single(view.MemberTypeGlobalId).UniqueCode
        };

    public static OrganizationSearchQueryResult.OrganizationModel ToModel(this OrganizationView view)
        => new OrganizationSearchQueryResult.OrganizationModel
        {
            GlobalId = view.GlobalId,
            DisplayName = view.DisplayName,
            IsDeleted = view.IsDeleted,
            CreationDate = view.CreationDate,
            CreationUser = view.CreationUserRef,
            Members = [.. view.Members.Select(member => member.ToModel())]
        };

    public static IEnumerable<OrganizationSearchQueryResult.OrganizationModel> ToModel(this IEnumerable<OrganizationView> views)
        => views.Select(view => view.ToModel());
}
