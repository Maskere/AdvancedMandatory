namespace Mandatory;

public interface IGameObjectFactory{
    IArmor CreateArmor();
    IWeapon CreateWeapon();
    ICreature CreateCreature();
}
