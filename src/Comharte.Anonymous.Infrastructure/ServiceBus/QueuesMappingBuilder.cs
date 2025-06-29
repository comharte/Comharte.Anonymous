namespace Comharte.Anonymous.Infrastructure.ServiceBus;

public class QueuesMappingBuilder : IServiceBusQueueMappingBuilder
{
    public void Build(IServiceBusQueueMappingWriter mapping)
    {
        mapping.AddMappingForInternalProcessing<OrganizationChangedEvent>();
    }
}
