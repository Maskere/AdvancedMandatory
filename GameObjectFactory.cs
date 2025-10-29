namespace Mandatory;

public abstract class GameObjectFactory {
    public abstract Armor CreateArmor();
    public abstract Weapon CreateWeapon();
    public abstract Creature CreateCreature();
}
