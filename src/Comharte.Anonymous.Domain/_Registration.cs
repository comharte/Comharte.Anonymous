global using System.Collections.Immutable;

global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;

global using Comharte.Core.Exceptions;
global using Comharte.Core.Time;

global using Comharte.Models;

global using Comharte.Host.Domain;

global using Comharte.Host.Hosting.Factory;
global using Comharte.Host.Hosting.Factory.Build;

global using Comharte.Anonymous.Domain.ValueObjects;
global using Comharte.Anonymous.Domain.ValueObjects.Guards;
global using Comharte.Anonymous.Domain.Aggregates.Organizations;

global using Comharte.Anonymous.Models.Events;

namespace Comharte.Anonymous.Domain;

public class DomainRegistration : BaseRegistration
{
    public override void Build(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AnonymousDomain>();
        services.AddScoped<IAnonymousDomain>(provider => provider.GetRequiredService<AnonymousDomain>());
    }
}