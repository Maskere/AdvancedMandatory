namespace Mandatory;

public class Weapon : AttackItem, IWeaponModTarget{
    private int damageAmount;
    public WeaponSlot Slot {get;private set;}

    public Weapon(int damageAmount, WeaponSlot slot) : base(null,null){
        damageAmount = 0;
        Slot = slot;
    }

    public void ChangeWeaponDamage(int amount) {
        this.damageAmount += amount;
    }

    public override int GetTotalAttackDamage() {
        return damageAmount;
    }
}
