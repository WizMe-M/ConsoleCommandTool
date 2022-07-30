namespace ConsoleCommandTool.Locator;

public class ServiceLocator : IServiceLocator
{
    public static ServiceLocator Instance { get; }
    private readonly Dictionary<Type, List<object>> _services = new();

    static ServiceLocator()
    {
        Instance = new ServiceLocator();
    }

    public void Register<TService>(TService service)
    {
        if (service is null) throw new ArgumentNullException(nameof(service));

        var key = typeof(TService);
        if (!_services.ContainsKey(key))
            _services.Add(key, new List<object>());
        _services[key].Add(service);
    }

    public TService GetService<TService>()
    {
        if (_services.ContainsKey(typeof(TService)))
            return (TService)_services[typeof(TService)].Single();
        throw new InvalidOperationException($"Can't resolve service: {typeof(TService)}");
    }

    public IEnumerable<TService> GetAll<TService>()
    {
        if (_services.ContainsKey(typeof(TService)))
            return _services[typeof(TService)].Cast<TService>();
        throw new InvalidOperationException($"Can't resolve services: {typeof(TService)}");
    }
}