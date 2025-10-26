namespace Mandatory;

public interface IObserverHandler{
    void AddObserverListener(ObserverListener observer);
    void RemoveObserverListener(ObserverListener observer);
    void NotifyObserverListeners(string status);
}
