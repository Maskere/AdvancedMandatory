namespace Mandatory;

public class Armor : DefenceItem, IArmorModTarget{
    private int armorAmount;
    public ArmorSlot Slot {get;private set;}

    public Armor(ArmorSlot slot) : base(null,null) {
        this.armorAmount = 0;
        Slot = slot;
    }

    public Armor(int armorAmount, ArmorSlot slot) : base(null,null){
        this.armorAmount = armorAmount;
        Slot = slot;
    }

    public void ChangeArmorSlot(ArmorSlot slot){
        this.Slot = slot;
    }

    public override int GetTotalDefencePoint() {
        return armorAmount;
    }

    public void ChangeArmorValue(int amount) {
        this.armorAmount += amount;
    }
}
