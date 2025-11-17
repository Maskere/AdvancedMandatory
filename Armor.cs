namespace Mandatory;

/// <summary>
/// Represents a basic, concrete armor item in the game.
/// It holds a base defense value and implements the core logic for calculating its defense point.
/// It also serves as a target for modifications via the <see cref="IArmorModTarget"/> interface.
/// </summary>
public class Armor : DefenceItem, IArmorModTarget{
    private int armorAmount;

    public override ArmorSlot ArmorSlot {get;set;}
    /// <summary>
    /// Initializes a new instance of the <see cref="Armor"/> class.
    /// </summary>
    /// <param name="armorAmount">The initial base defense value of the armor.</param>
    /// <param name="slot">The slot this armor occupies.</param>
    public Armor(int armorAmount, ArmorSlot Slot){
        this.armorAmount = armorAmount;
        ArmorSlot = Slot;
    }

    /// <summary>
    /// Changes the base defense value of the armor by the specified amount.
    /// This is part of the <see cref="IArmorModTarget"/> contract.
    /// </summary>
    /// <param name="amount">The amount to add to or subtract from the current armor value.</param>
    public void ChangeArmorValue(int amount) {
        this.armorAmount += amount;
    }

    /// <summary>
    /// Overrides the base method to return the current base defense value of the armor.
    /// </summary>
    /// <returns>The current integer defense value (<c>armorAmount</c>).</returns>
    public override int GetTotalDefencePoint() {
        return armorAmount;
    }

    /// <summary>
    /// Disposes of the armor item.
    /// </summary>
    public override void Dispose(){
        GC.SuppressFinalize(this);
    }
}
