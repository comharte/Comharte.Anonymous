namespace Comharte.Anonymous.Domain.ValueObjects;

public class Member
{
    public static Member Create(Guid memberId, MemberType memberType)
        => new(GlobalIdGuard.Create(memberId), memberType.GlobalId);

    public static Member Create(Guid memberRef, Guid memberTypeGlobalId)
        => Create(memberRef, MemberType.Single(memberTypeGlobalId));

    private readonly int _hashCode;

    private readonly Guid _ref;

    private readonly Guid _typeGlobalId;

    public Member(Guid @ref, Guid typeGlobalId)
    {
        _ref = @ref;
        _typeGlobalId = typeGlobalId;

        _hashCode = HashCode.Combine(_ref, _typeGlobalId);
    }

    public Guid Ref => _ref;

    public Guid TypeGlobalId => _typeGlobalId;

    public MemberType Type => MemberType.Single(_typeGlobalId);

    public override bool Equals(object? obj)
        => obj != null && obj is Member other && _ref.Equals(other._ref) && _typeGlobalId.Equals(other._typeGlobalId);

    public override int GetHashCode()
        => _hashCode;


}