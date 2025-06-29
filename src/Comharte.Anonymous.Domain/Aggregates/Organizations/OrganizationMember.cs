namespace Comharte.Anonymous.Domain.Aggregates.Organizations;

public class OrganizationMember
{
    public static OrganizationMember Create(int organizationId, Member member)
    {
        if (member == null)
        {
            throw new ArgumentNullException(nameof(member));
        }
        return new OrganizationMember(organizationId, member.Ref, member.TypeGlobalId);
    }

    private readonly int _hashCode;

    private readonly Member _member;

    private OrganizationMember(int organizationId, Guid memberRef, Guid memberTypeGlobalId)
    {
        OrganizationId = organizationId;
        MemberRef = memberRef;
        MemberTypeGlobalId = memberTypeGlobalId;
        _member = Member.Create(memberRef, memberTypeGlobalId);

        _hashCode = HashCode.Combine(OrganizationId, _member);
    }

    public int OrganizationId { get; private set; }

    public Guid MemberRef { get; private set; }

    public Guid MemberTypeGlobalId { get; private set; }

    public Member Member => _member;

    public override bool Equals(object? obj)
        => obj != null && obj is OrganizationMember other &&
           OrganizationId.Equals(other.OrganizationId) &&
           Member.Equals(other.Member);

    public override int GetHashCode()
        => _hashCode;

}