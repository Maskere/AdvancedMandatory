namespace MandatoryGameframework;

/// <summary>
/// Provides an abstract base implementation for the Abstract Factory Pattern,
/// defining the contract for creating a family of related game objects.
/// </summary>
public abstract class GameObjectFactory : IGameObjectFactory {
    /// <summary>
    /// Abstract method that must be implemented by concrete factories to create a new armor item.
    /// </summary>
    /// <returns>A new instance of <see cref="IArmor"/>.</returns>
    public abstract IArmor CreateArmor();
    /// <summary>
    /// Abstract method that must be implemented by concrete factories to create a new weapon item.
    /// </summary>
    /// <returns>A new instance of <see cref="IWeapon"/>.</returns>
    public abstract IWeapon CreateWeapon();
    /// <summary>
    /// Abstract method that must be implemented by concrete factories to create a new creature.
    /// </summary>
    /// <returns>A new instance of <see cref="ICreature"/>.</returns>
    public abstract ICreature CreateCreature();
}
