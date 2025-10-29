namespace Mandatory;

public abstract class AttackItem : GameObject, IIncreaseWeaponDamage,IDecreaseWeaponDamage{
    private IIncreaseWeaponDamage? increaseWeaponDamageComponent;
    private IDecreaseWeaponDamage? decreaseWeaponDamageComponent;

    public IIncreaseWeaponDamage? IncreaseWeaponDamageComponent{
        get => increaseWeaponDamageComponent;
    }

    public IDecreaseWeaponDamage? DecreaseWeaponDamageComponent{
        get => decreaseWeaponDamageComponent;
    }

    public AttackItem(IIncreaseWeaponDamage? increaseWeaponDamageComponent, IDecreaseWeaponDamage? decreaseWeaponDamageComponent){
        this.increaseWeaponDamageComponent = increaseWeaponDamageComponent;
        this.decreaseWeaponDamageComponent = decreaseWeaponDamageComponent;
    }

    public virtual void IncreaseWeaponDamage(Weapon target, int amount){
        if(increaseWeaponDamageComponent != null)
            increaseWeaponDamageComponent.IncreaseWeaponDamage(target,amount);
    }

    public virtual void DecreaseWeaponDamage(Weapon target, int amount){
        if(decreaseWeaponDamageComponent != null)
            decreaseWeaponDamageComponent.DecreaseWeaponDamage(target, amount);
    }

    public abstract int GetTotalAttackDamage();
}
