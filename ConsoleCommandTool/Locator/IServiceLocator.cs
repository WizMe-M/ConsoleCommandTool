namespace ConsoleCommandTool.Locator;

public interface IServiceLocator
{
    TService GetService<TService>();
    IEnumerable<TService> GetAll<TService>();
}