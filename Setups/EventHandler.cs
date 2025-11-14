namespace Mandatory;

public class EventHandler : IObserverHandler{
    private List<IObserverListener> observers = new();

    private static EventHandler instance = new();
    public static EventHandler Instance {get {return instance;}}

    public void AddObserverListener(IObserverListener observer){
        observers.Add(observer);
    }

    public void RemoveObserverListener(IObserverListener observer){
        observers.Remove(observer);
    }

    public void NotifyObserverListeners(string status){
        foreach(IObserverListener obs in observers){
            obs.GetUpdate(status);
        }
    }

    public void Dispose(){
        observers.Clear();
        GC.SuppressFinalize(this);
    }
}
