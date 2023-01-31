namespace RemoteNotes.Service.Console
{
    public interface IManagerFactory
    {
        T Create<T>();
    }
}