namespace Comharte.Anonymous.Domain.Views;

public class OrganizationView
{
    private readonly List<OrganizationMemberView> _members = [];

    public OrganizationView(int id, Guid globalId, string displayName, bool isDeleted, DateTime creationDate, Guid creationUserRef)
    {
        Id = id;
        GlobalId = globalId;
        DisplayName = displayName;
        IsDeleted = isDeleted;
        CreationDate = creationDate;
        CreationUserRef = creationUserRef;
    }

    public int Id { get; private set; }

    public Guid GlobalId { get; private set; }

    public string DisplayName { get; private set; }

    public bool IsDeleted { get; private set; }

    public DateTime CreationDate { get; private set; }

    public Guid CreationUserRef { get; private set; }

    public IReadOnlyCollection<OrganizationMemberView> Members => _members.AsReadOnly();

}