namespace Mandatory;

public interface IWorldManager{
    IGameObject AddGameObject(IGameObject gameObject);
    void RemoveAllGameObjects();
    void RemoveGameObject(IGameObject gameObject);
}
