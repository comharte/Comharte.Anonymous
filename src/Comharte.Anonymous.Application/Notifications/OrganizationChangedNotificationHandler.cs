namespace Comharte.Anonymous.Application.Notifications;

internal class OrganizationChangedNotificationHandler : INotificationHandler<OrganizationChangedNotification>
{
    private readonly MemberOrganizationAccessServiceInitializer _memberAccessServiceInitializer;

    public OrganizationChangedNotificationHandler(MemberOrganizationAccessServiceInitializer memberAccessServiceInitializer)
    {
        _memberAccessServiceInitializer = memberAccessServiceInitializer;
    }

    public async Task Handle(OrganizationChangedNotification requestEvent)
    {
        await _memberAccessServiceInitializer.Reload(requestEvent.Members.Select(m => m.MemberRef));
    }
}