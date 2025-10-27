namespace Mandatory;

public class ArmorCollection : DefenceItem{
    private Dictionary<ArmorSlot, DefenceItem> armors = new();

    public ArmorCollection(IIncreaseArmorValue increaseArmorValue, IDecreaseArmorValue decreaseArmorValue) :base(increaseArmorValue,decreaseArmorValue){
    }

    public void EquipArmor(Armor armor){
        if(armors.ContainsKey(armor.Slot)){
            throw new InvalidOperationException($"Slot {armor.Slot} is already occupied");
        }
        armors.Add(armor.Slot, armor);
    }

    public void UnequipArmor(ArmorSlot slot){
        if(armors.ContainsKey(slot)){
            armors.Remove(slot);
        }
    }

    public override void DecreaseArmorValue(Armor target, int amount){
        foreach(DefenceItem item in armors.Values){
            item.DecreaseArmorValue(target,amount);
        }
    }

    public override void IncreaseArmorValue(Armor target, int amount){
        foreach(DefenceItem item in armors.Values){
            item.IncreaseArmorValue(target,amount);
        }
    }

    public override int GetTotalDefencePoint() {
        int totalArmor = 0;

        foreach(DefenceItem item in armors.Values){
            totalArmor += item.GetTotalDefencePoint();
        }
        return totalArmor;
    }
}
