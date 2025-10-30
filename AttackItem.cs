namespace Mandatory;

public abstract class AttackItem : GameObject{
    private IIncreaseWeaponDamage? increaseWeaponDamageComponent;
    private IDecreaseWeaponDamage? decreaseWeaponDamageComponent;

    public AttackItem(IIncreaseWeaponDamage? increaseWeaponDamageComponent = null, IDecreaseWeaponDamage? decreaseWeaponDamageComponent = null){
        this.increaseWeaponDamageComponent = increaseWeaponDamageComponent;
        this.decreaseWeaponDamageComponent = decreaseWeaponDamageComponent;
    }

    public void ApplyChange(IWeaponModTarget target, int amount){
        increaseWeaponDamageComponent?.IncreaseWeaponDamage(target,amount);
        decreaseWeaponDamageComponent?.DecreaseWeaponDamage(target,amount);
    }

    public abstract int GetTotalAttackDamage();
}
