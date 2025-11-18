namespace MandatoryGameframework;

public interface IWeapon : IWorldObject{
    WeaponSlot WeaponSlot {get;set;}
    int GetTotalAttackDamage();
}
