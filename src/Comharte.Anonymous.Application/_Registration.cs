global using System.Collections.Concurrent;

global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;

global using Comharte.Core.Exceptions;

global using Comharte.Host.Application.Repository;

global using Comharte.Host.Application.Contexts.Identity;
global using Comharte.Host.Hosting.Factory.Build;
global using Comharte.Host.Hosting.Factory;

global using Comharte.Mediator.Handlers;

global using Comharte.Models;


global using Comharte.Anonymous.Application.Queries.Specifications;
global using Comharte.Anonymous.Application.Queries.Mappings;
global using Comharte.Anonymous.Application.Services;
global using Comharte.Anonymous.Domain;
global using Comharte.Anonymous.Domain.Aggregates.Organizations;
global using Comharte.Anonymous.Domain.ValueObjects;
global using Comharte.Anonymous.Domain.Views;
global using Comharte.Anonymous.Models.Commands;
global using Comharte.Anonymous.Models.Queries;
global using Comharte.Anonymous.Models.Notifications;

namespace Comharte.Anonymous.Application;

public class ApplicationRegistration : BaseRegistration
{
    public override void Build(ApplicationHostOptions options, IConfiguration configuration)
    {
        options.Application.RequestHandlersAssemblies.Add<ApplicationRegistration>();
    }

    public override void Build(IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddSingleton<MemberOrganizationAccessService>()
            .AddScoped<MemberOrganizationAccessServiceInitializer>();
    }
}