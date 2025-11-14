namespace Mandatory;

public class EventHandlerHelper : INotifier{
    public void Notify(string message){
        EventHandler.Instance.NotifyObserverListeners(message);
    }
}
