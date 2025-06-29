namespace Comharte.Anonymous.Domain.Aggregates.Organizations;

public class Organization : AggregateRoot, IIdentifiableEntityByGlobalId, IIdentifiableEntityById
{
    internal class EventHandler
    {
        private readonly Organization _organization;

        public EventHandler(Organization organization)
        {
            _organization = organization;
        }

        private Organization AddEvent<TEvent>(TEvent eventPayload)
            where TEvent : IEvent
        {
            _organization.EnqueueEvent(eventPayload);
            return _organization;
        }

        private OrganizationChangedEvent CreateChangedEvent(bool isCreated, bool isDeleted)
            => new OrganizationChangedEvent()
            {
                IsCreated = isCreated,
                IsDeleted = isDeleted,
                GlobalId = _organization.GlobalId,
                DisplayName = _organization.DisplayName,
                Members = [.. _organization.Members.Select(m => new OrganizationChangedEvent.MemberModel()
                {
                    MemberRef = m.Member.Ref,
                    MemberTypeGlobalId = m.Member.Type,
                })],
            };

        public Organization OnCreation()
            => AddEvent(CreateChangedEvent(true, false));

        public Organization OnModification()
            => AddEvent(CreateChangedEvent(false, false));

        public Organization OnDelete()
            => AddEvent(CreateChangedEvent(false, true));
    }

    public static Organization Create(Guid globalId, NameStringGuard displayName, DateTime creationDate, Guid creationUserRef)
        => new Organization(0, globalId, displayName, false, creationDate, creationUserRef)
            .AddMember(creationUserRef, MemberType.Owner.GlobalId);

    private readonly List<OrganizationMember> _members = [];

    internal readonly EventHandler _events;

    public Organization(int id, Guid globalId, string displayName, bool isDeleted, DateTime creationDate, Guid creationUserRef)
    {
        Id = id;
        GlobalId = globalId;
        DisplayName = displayName;
        IsDeleted = isDeleted;
        CreationDate = creationDate;
        CreationUserRef = creationUserRef;

        _events = new EventHandler(this);
    }

    public int Id { get; private set; }

    public Guid GlobalId { get; private set; }

    public string DisplayName { get; private set; }

    public bool IsDeleted { get; private set; }

    public Guid CreationUserRef { get; private set; }

    public DateTime CreationDate { get; private set; }

    public IReadOnlyCollection<OrganizationMember> Members => _members.AsReadOnly();

    internal IEnumerable<OrganizationPermission> GetMemberPermissions(Guid memberRef)
    => _members.Where(m => m.MemberRef.Equals(memberRef))
        .Select(m => new OrganizationPermission(GlobalId, m.Member.TypeGlobalId));

    public Organization Modify(NameStringGuard displayName)
    {
        DisplayName = displayName;
        return this;
    }

    public Organization Delete()
    {
        if (IsDeleted)
        {
            throw new OrganizationAlreadyDeletedException();
        }

        IsDeleted = true;
        return this;
    }

    public Organization Recover()
    {
        if (!IsDeleted)
        {
            throw new OrganizationAlreadyActiveException();
        }

        IsDeleted = false;
        return this;
    }

    public Organization AddMember(Guid memberRef, Guid memberTypeGlobalId)
    {
        var newMember = Member.Create(memberRef, memberTypeGlobalId);

        if (_members.Any(m => m.Member.Equals(newMember)))
        {
            throw new OrganizationMemberAlreadyExistsException();
        }

        _members.Add(OrganizationMember.Create(Id, newMember));

        return this;
    }

    public Organization RemoveMember(Guid memberRef, Guid memberTypeGlobalId)
    {
        var memberType = MemberType.Single(memberTypeGlobalId);
        var existingMemebr = Member.Create(memberRef, memberType);

        var organizationMember = _members.SingleOrDefault(_members => _members.Member.Equals(existingMemebr));
        if (organizationMember == null)
        {
            throw new OrganizationMemberNotFoundException();
        }

        if (memberType.Equals(MemberType.Owner) &&
            !_members.Any(m => m.Member.Equals(existingMemebr) && m.Member.Type.Equals(MemberType.Owner)))
        {
            throw new OrganizationCannotRemoveLastOwnerException();
        }

        _members.Remove(organizationMember);

        return this;
    }
}