namespace Mandatory;

public class Weapon : AttackItem{
    private int damageAmount;
    public WeaponSlot Slot {get;private set;}

    public Weapon() : base(null,null){
        damageAmount = 0;
        Slot = WeaponSlot.None;
    }

    public Weapon(int damageAmount,
            IIncreaseWeaponDamage increaseWeaponDamageComponent,
            IDecreaseWeaponDamage decreaseWeaponDamageComponent, WeaponSlot slot) 
        : base(increaseWeaponDamageComponent,decreaseWeaponDamageComponent){
            this.damageAmount = damageAmount;
            Slot = slot;
    }

    public void IncreaseWeaponDamage(int amount){
        this.IncreaseWeaponDamage(this, amount);
    }

    public override void IncreaseWeaponDamage(Weapon target,int amount) {
        target.damageAmount += amount;

        base.IncreaseWeaponDamage(this,amount);
    }

    public void DecreaseWeaponDamage(int amount){
        this.DecreaseWeaponDamage(this,amount);
    }

    public override void DecreaseWeaponDamage(Weapon target, int amount) {
        target.damageAmount -= amount;

        base.DecreaseWeaponDamage(target, amount);
    }

    public void ChangeWeaponSlot(WeaponSlot slot){
        this.Slot = slot;
    }

    public override int GetTotalAttackDamage() {
        return damageAmount;
    }
}
