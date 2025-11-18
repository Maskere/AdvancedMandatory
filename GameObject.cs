namespace MandatoryGameframework;

/// <summary>
/// The abstract base class for all entities in the game world.
/// It implements the core contract defined by <see cref="IGameObject"/>,
/// providing shared properties and a basic string representation.
/// </summary>
public abstract class GameObject : IGameObject{
    /// <summary>
    /// Gets or sets the name of the game object.
    /// </summary>
    public string? Name {get;set;}
    /// <summary>
    /// Gets or sets a value indicating whether this object can be looted upon interaction or removal.
    /// </summary>
    public bool Lootable {get;set;}
    /// <summary>
    /// Gets or sets a value indicating whether this object can be safely removed from the game world.
    /// </summary>
    public bool Removeable {get;set;}

    /// <summary>
    /// Abstract method required by the <see cref="IDisposable"/> contract (inherited via <see cref="IGameObject"/>).
    /// Concrete subclasses must implement the logic to free resources.
    /// </summary>
    public abstract void Dispose();

    /// <summary>
    /// Returns a string that represents the current game object.
    /// </summary>
    /// <returns>A formatted string containing the object's name, lootable status, and removeable status.</returns>
    public override string ToString() {
        return $"{Name} - Lootable: {Lootable} - Removeable: {Removeable}";
    }
}
