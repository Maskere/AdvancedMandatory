namespace Mandatory;

public class WeaponCollection : AttackItem{
    private Dictionary<WeaponSlot, AttackItem> weapons = new();

    public WeaponCollection(IIncreaseWeaponDamage increaseWeaponDamage, IDecreaseWeaponDamage decreaseWeaponDamage) : base(increaseWeaponDamage,decreaseWeaponDamage){
    }

    public void EquipWeapon(Weapon weapon){
        if(weapons.ContainsKey(weapon.Slot)){
            throw new InvalidOperationException($"Slot {weapon.Slot} is already occupied");
        }
        weapons.Add(weapon.Slot, weapon);
    }
    public void UnequipWeapon(WeaponSlot slot){
        if(weapons.ContainsKey(slot)){
            weapons.Remove(slot);
        }
    }

    public override void IncreaseWeaponDamage(Weapon target, int amount) {
        foreach(AttackItem item in weapons.Values){
            item.IncreaseWeaponDamage(target,amount);
        }
    }

    public override void DecreaseWeaponDamage(Weapon target, int amount) {
        foreach(AttackItem item in weapons.Values){
            item.DecreaseWeaponDamage(target,amount);
        }
    }

    public override int GetTotalAttackDamage() {
        int totalDamage = 0;

        foreach(AttackItem item in weapons.Values){
            totalDamage += item.GetTotalAttackDamage();
        }
        return totalDamage;
    }
}
