namespace MandatoryGameframework;

public interface IGameObjectFactory{
    IArmor CreateArmor();
    IWeapon CreateWeapon();
    ICreature CreateCreature();
}
