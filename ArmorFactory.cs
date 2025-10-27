namespace Mandatory;

public class ArmorFactory : GameObjectFactory {
    public GameObject CreateGameObject() {
        return new Armor();
    }
}
