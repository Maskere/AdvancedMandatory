namespace MandatoryGameframework;

/// <summary>
/// Represents an armor item in the game.
/// Inherits from <see cref="DefenceItem"/> and implements <see cref="IArmorModTarget"/>,
/// allowing it to be the target for modifications that affect its defense value.
/// </summary>
public class Armor : DefenceItem, IArmorModTarget{
    private int armorAmount;

    /// <summary>
    /// Gets or sets the slot where the armor item can be equipped (e.g., Head, Torso, Legs).
    /// This property overrides a base property from <see cref="DefenceItem"/>.
    /// </summary>
    public override ArmorSlot ArmorSlot {get;set;}

    /// <summary>
    /// Initializes a new instance of the <see cref="Armor"/> class.
    /// </summary>
    /// <param name="armorAmount">The initial base defensive value of the armor.</param>
    /// <param name="Slot">The slot this armor occupies.</param>
    public Armor(int armorAmount, ArmorSlot Slot){
        this.armorAmount = armorAmount;
        ArmorSlot = Slot;
    }

    /// <summary>
    /// Adjusts the current armor value by the specified amount.
    /// This is typically used by modifiers to change the defense value.
    /// </summary>
    /// <param name="amount">The value to add to (or subtract from, if negative) the current armor amount.</param>
    public void ChangeArmorValue(int amount) {
        this.armorAmount += amount;
    }

    /// <summary>
    /// Gets the current total defensive point value of the armor.
    /// </summary>
    /// <returns>The current total armor amount.</returns>
    public override int GetTotalDefencePoint() {
        return armorAmount;
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// In this implementation, it suppresses finalization for deterministic cleanup.
    /// </summary>
    public override void Dispose(){
        GC.SuppressFinalize(this);
    }
}
