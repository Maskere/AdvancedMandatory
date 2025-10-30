namespace Mandatory;

public class WeaponCollection{
    private Dictionary<WeaponSlot, AttackItem> weapons = new();

    public WeaponCollection(){
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

    public int GetTotalAttackDamage() {
        int totalDamage = 0;

        foreach(AttackItem item in weapons.Values){
            totalDamage += item.GetTotalAttackDamage();
        }
        return totalDamage;
    }
}
