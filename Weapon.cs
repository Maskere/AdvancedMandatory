namespace Mandatory;

/// <summary>
/// Represents a basic, concrete weapon item in the game.
/// It holds a base damage value and implements the core logic for calculating its attack damage.
/// It also serves as a target for modifications via the <see cref="IWeaponModTarget"/> interface.
/// </summary>
public class Weapon : AttackItem, IWeaponModTarget{
    private int damageAmount;
    /// <summary>
    /// Gets the slot type this weapon occupies (e.g., MainHand, OffHand).
    /// </summary>
    public WeaponSlot Slot {get;private set;}

    /// <summary>
    /// Initializes a new instance of the <see cref="Weapon"/> class.
    /// </summary>
    /// <param name="damageAmount">The initial base damage value of the weapon.</param>
    /// <param name="slot">The slot this weapon occupies.</param>
    public Weapon(int damageAmount, WeaponSlot slot){
        damageAmount = 0;
        Slot = slot;
    }

    /// <summary>
    /// Changes the base attack damage value of the weapon by the specified amount.
    /// This is part of the <see cref="IWeaponModTarget"/> contract.
    /// </summary>
    /// <param name="amount">The amount to add to or subtract from the current damage value.</param>
    public void ChangeWeaponDamage(int amount) {
        this.damageAmount += amount;
    }

    /// <summary>
    /// Overrides the base method to return the current base attack damage value of the weapon.
    /// </summary>
    /// <returns>The current integer damage value (<c>damageAmount</c>).</returns>
    public override int GetTotalAttackDamage() {
        return damageAmount;
    }

    /// <summary>
    /// Disposes of the weapon item.
    /// </summary>
    public override void Dispose(){
        GC.SuppressFinalize(this);
    }
}
