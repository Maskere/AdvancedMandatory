namespace Mandatory;

public interface IGrid<T> where T : notnull{
    int Width {get;}
    int Height {get;}
    T GetValue(int x, int y);
    void SetValue(int x, int y, T value);
    void RemoveValue(int x, int y);
}
