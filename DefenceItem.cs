namespace MandatoryGameframework;

/// <summary>
/// Represents the abstract base class for all defensive items (armor) in the game.
/// It provides common properties shared by all armor types and serves as the
/// abstract component for the Decorator Pattern (along with IArmor).
/// </summary>
public abstract class DefenceItem : IArmor{
    /// <summary>
    /// Gets or sets the name of the armor item.
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
    /// Gets or sets the slot type this armor occupies (e.g., Head, Torso).
    /// </summary>
    public abstract ArmorSlot ArmorSlot {get;set;}
    /// <summary>
    /// Gets or sets the position of the item in the game world.
    /// </summary>
    public Position Position {get;set;}
    /// <summary>
    /// Abstract method to calculate the total defensive value provided by this item.
    /// Concrete classes (and decorators) must implement this.
    /// </summary>
    /// <returns>The calculated defensive point value.</returns>
    public abstract int GetTotalDefencePoint();
    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// This is inherited from the IDisposable interface via IGameObject (implied).
    /// </summary>
    public abstract void Dispose();
}
