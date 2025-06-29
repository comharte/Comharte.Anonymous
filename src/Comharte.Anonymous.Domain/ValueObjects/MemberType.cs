namespace Comharte.Anonymous.Domain.ValueObjects;

public class MemberType : Enumeration
{
    public static readonly MemberType Owner = new(1, Guid.Parse("744044b9-508f-4ab9-bcb0-1feb1e53a3e0"), "OWNER");

    public static readonly MemberType Basic = new(2, Guid.Parse("d8a9cdee-1786-4e7c-9350-3cce37886cea"), "BASIC");

    private MemberType(int id, Guid globalId, string displayName)
        : base(id, globalId, displayName)
    { }

    public static MemberType Single(Guid globalId)
        => Single<MemberType>(globalId);

    public static MemberType? SingleOrDefault(Guid globalId)
        => SingleOrDefault<MemberType>(globalId);
}