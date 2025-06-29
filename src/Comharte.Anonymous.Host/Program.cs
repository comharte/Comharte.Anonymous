global using Comharte.Host.Hosting.Factory;
global using Comharte.Host.Hosting.Factory.Build;

global using Comharte.Anonymous.Application;
global using Comharte.Anonymous.Domain;
global using Comharte.Anonymous.Infrastructure;

await ApplicationHostFactory.RunApplication(args,
     new DomainRegistration(),
     new ApplicationRegistration(),
     new InfrastructureRegistration(),
     new HostRegistration());

public class HostRegistration : BaseRegistration
{
    public override void Build(ApplicationHostOptions options, IConfiguration configuration)
    {
        options.Host.EndpointsAssemblies.Add<ModelsRegistration>();
    }
}