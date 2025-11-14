namespace Mandatory;

public interface IGameObject : IDisposable{
    string? Name {get;set;}
    bool Lootable {get;set;}
    bool Removeable {get;set;}
}
