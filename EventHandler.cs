namespace Mandatory;

public class EventHandler : IObserverHandler{
    private List<ObserverListener> observers = new();

    private static EventHandler instance = new();
    public static EventHandler Instance {get {return instance;}}

    public void AddObserverListener(ObserverListener observer){
        observers.Add(observer);
    }

    public void RemoveObserverListener(ObserverListener observer){
        observers.Remove(observer);
    }

    public void NotifyObserverListeners(string status){
        foreach(ObserverListener obs in observers){
            obs.Update(status);
        }
    }
}
