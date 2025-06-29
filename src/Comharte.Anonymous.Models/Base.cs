global using Comharte.Models;
global using Comharte.Models.Descriptors;
global using Comharte.Anonymous.Models.Events;

internal class ModelsRegistration { }

public abstract class EndpointDescriptor : IEndpointDescriptor
{
    private const string SERVICE = "anonymous";

    private readonly string _route;

    private readonly string _version;

    private readonly EndpointType _type;

    public EndpointDescriptor(string route, string version, EndpointType type)
    {
        _route = route;
        _version = version;
        _type = type;
    }
    public EndpointType Type => _type;
    public string Route => _route;
    public string Version => _version;
    public string Service => SERVICE;
}

public abstract class CommandV1EndpointDescriptor<TCommand> : EndpointDescriptor, IEndpointDescriptor<TCommand, CommandEmptyResult>
    where TCommand : ICommand
{
    protected CommandV1EndpointDescriptor(string route)
        : base(route, "v1", EndpointType.COMMAND)
    { }
}
public abstract class QueryV1EndpointDescriptor<TQuery, TQueryResult> : EndpointDescriptor, IEndpointDescriptor<TQuery, TQueryResult>
    where TQuery : IQuery<TQueryResult>
    where TQueryResult : IQueryResult
{
    protected QueryV1EndpointDescriptor(string route)
        : base(route, "v1", EndpointType.QUERY)
    { }
}