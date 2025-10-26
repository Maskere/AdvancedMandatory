namespace Mandatory;

public class Armor : DefenceItem{
    private int armorAmount;
    public ArmorSlot Slot {get;}

    public Armor(int armorAmount,
            IIncreaseArmorValue increaseArmorComponent,
            IDecreaseArmorValue decreaseArmorComponent, ArmorSlot slot) : base(increaseArmorComponent,decreaseArmorComponent){
        this.armorAmount = armorAmount;
        Slot = slot;
    }

    public void IncreaseArmorValue(int amount){
        this.IncreaseArmorValue(this,amount);
    }

    public override void IncreaseArmorValue(Armor target,int amount) {
        target.armorAmount += amount;

        base.IncreaseArmorValue(this, amount);
    }

    public void DecreaseArmorValue(int amount){
        this.DecreaseArmorValue(this,amount);
    }

    public override void DecreaseArmorValue(Armor target,int amount) {
        target.armorAmount -= amount;

        base.DecreaseArmorValue(this,amount);
    }

    public override int GetTotalDefencePoint() {
        return armorAmount;
    }
}
