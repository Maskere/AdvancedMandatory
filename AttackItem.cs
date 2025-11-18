namespace MandatoryGameframework;

/// <summary>
/// Represents the abstract base class for all offensive items (weapons) in the game.
/// It provides common properties shared by all weapon types and defines the contract 
/// for damage calculation and object disposal.
/// </summary>
public abstract class AttackItem : IWeapon{
    /// <summary>
    /// Gets or sets the name of the weapon item.
    /// </summary>
    public string? Name {get;set;}
    /// <summary>
    /// Gets or sets a value indicating whether the item can be looted.
    /// </summary>
    public bool Lootable {get;set;}
    /// <summary>
    /// Gets or sets a value indicating whether the item can be removed from a container or inventory.
    /// </summary>
    public bool Removeable {get;set;}
    /// <summary>
    /// Gets or sets the slot type this weapon occupies (e.g., MainHand, OffHand).
    /// </summary>
    public abstract WeaponSlot WeaponSlot {get;set;}
    /// <summary>
    /// Gets or sets the position of the item in the game world.
    /// </summary>
    public Position Position {get;set;}
    /// <summary>
    /// Abstract method to calculate the total attack damage provided by this weapon.
    /// Concrete classes must implement this.
    /// </summary>
    /// <returns>The calculated attack damage value.</returns>
    public abstract int GetTotalAttackDamage();
    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// This is inherited from the IDisposable interface via IGameObject (implied).
    /// </summary>
    public abstract void Dispose();
}
