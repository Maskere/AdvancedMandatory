using System.Diagnostics;
namespace MandatoryGameframework;

public class MyLogger{
    private static MyLogger instance = new();
    public static MyLogger Instance {get {return instance; }}

    private TraceSource ts;
    private TraceListener? debugListener = null;

    private MyLogger(){
        ts = new("TurnBased",SourceLevels.All);
        ts.Switch = new("TurnBased", SourceLevels.All.ToString());
    }

    public void AddListener(TraceListener listener){
        ts.Listeners.Add(listener);
    }

    public void RemoveListener(TraceListener listener){
        ts.Listeners.Remove(listener);
    }

    public void SetDefaultLevel(SourceLevels level){
        ts.Switch.Level = level;
    }

    public void SetDebugLoggin(){
        if(debugListener == null){
            debugListener = new ConsoleTraceListener();
            ts.Listeners.Add(debugListener);
        }
    }

    public void RemoveDebugLogging(){
        if(debugListener != null){
            ts.Listeners.Remove(debugListener);
            debugListener = null;
        }
    }

    public void Stop(){
        ts.Close();
    }

    public void LogInfo(string message){
        ts.TraceEvent(TraceEventType.Information, 2, message);
    }

    public void LogWarning(string message){
        ts.TraceEvent(TraceEventType.Warning, 2, message);
    }

    public void LogError(string message){
        ts.TraceEvent(TraceEventType.Error, 2, message);
    }

    public void LogCritical(string message){
        ts.TraceEvent(TraceEventType.Critical, 2, message);
    }
}
