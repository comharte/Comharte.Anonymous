namespace Comharte.Anonymous.Models.Events;

public class OrganizationChangedEvent : IEvent
{
    public class MemberModel
    {
        public Guid MemberRef { get; set; }

        public Guid MemberTypeGlobalId { get; set; }
    }

    public bool IsCreated { get; set; }

    public bool IsDeleted { get; set; }

    public Guid GlobalId { get; set; }

    public string DisplayName { get; set; } = string.Empty;

    public List<MemberModel> Members { get; set; } = new List<MemberModel>();
}
