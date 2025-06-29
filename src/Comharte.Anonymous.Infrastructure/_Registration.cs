global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;

global using Comharte.ServiceBus.Queues;

global using Comharte.Host.Hosting.Factory;
global using Comharte.Host.Hosting.Factory.Build;
global using Comharte.Host.Infrastructure.Repository.Seed;
global using Comharte.Host.Infrastructure.Repository.Database.QueryBuilders;

global using Comharte.Anonymous.Domain.Aggregates.Organizations;
global using Comharte.Anonymous.Models.Events;

namespace Comharte.Anonymous.Infrastructure;

public class InfrastructureRegistration : BaseRegistration
{
    public override void Build(ApplicationHostOptions options, IConfiguration configuration)
    {
        options.Infrastructure.ServiceBusAssemblies.Add<InfrastructureRegistration>();
        options.Infrastructure.RepositoryAssemblies.Add<InfrastructureRegistration>();

        options.Infrastructure.RetainOutboxMessages = true;
        options.Infrastructure.MigrateOutboxDatabase = true;
        options.Infrastructure.EnableOutbox = true;
    }
}