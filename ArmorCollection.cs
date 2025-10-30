namespace Mandatory;

public class ArmorCollection{
    private Dictionary<ArmorSlot, DefenceItem> armors = new();

    public ArmorCollection(){
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

    public int GetTotalDefencePoint() {
        int totalArmor = 0;

        foreach(DefenceItem item in armors.Values){
            totalArmor += item.GetTotalDefencePoint();
        }
        return totalArmor;
    }
}
