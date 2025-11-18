namespace MandatoryGameframework;

public interface IObserverHandler : IDisposable{
    void AddObserverListener(IObserverListener observer);
    void RemoveObserverListener(IObserverListener observer);
    void NotifyObserverListeners(string status);
}
