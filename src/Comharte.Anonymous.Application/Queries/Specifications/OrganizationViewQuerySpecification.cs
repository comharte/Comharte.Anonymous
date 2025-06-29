namespace Comharte.Anonymous.Application.Queries.Specifications;

public class OrganizationViewQuerySpecification : Query<OrganizationView>
{
    public OrganizationViewQuerySpecification(Guid userGlobalId)
    {
        Where = Where = org => org.Members.Any(member => member.MemberRef.Equals(userGlobalId));
    }
}