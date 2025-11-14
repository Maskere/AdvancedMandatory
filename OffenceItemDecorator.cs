namespace Mandatory;

/// <summary>
/// Represents the abstract base class for all decorators that add functionality or modifiers to an <see cref="IWeapon"/> item.
/// It implements the <see cref="IWeapon"/> interface and uses property delegation to ensure it always
/// reflects the current state of the wrapped weapon.
/// </summary>
public abstract class OffenceItemDecorator : IWeapon{
    /// <summary>
    /// The reference to the core weapon component being wrapped and decorated.
    /// </summary>
    protected readonly IWeapon wrappedWeapon;

    /// <summary>
    /// Gets or sets the slot type this weapon occupies. Access is delegated to the wrapped item.
    /// </summary>
    public WeaponSlot WeaponSlot { get => wrappedWeapon.WeaponSlot;set => wrappedWeapon.WeaponSlot = value;}
    /// <summary>
    /// Gets or sets the name of the decorated item. Access is delegated to the wrapped item.
    /// </summary>
    public string? Name { get => wrappedWeapon.Name;set => wrappedWeapon.Name = value;} 
    /// <summary>
    /// Gets or sets a value indicating whether the decorated item can be looted. Access is delegated to the wrapped item.
    /// </summary>
    public bool Lootable { get => wrappedWeapon.Lootable;set => wrappedWeapon.Lootable = value;}
    /// <summary>
    /// Gets or sets a value indicating whether the decorated item can be removed. Access is delegated to the wrapped item.
    /// </summary>
    public bool Removeable { get => wrappedWeapon.Removeable;set => wrappedWeapon.Removeable = value;}
    /// <summary>
    /// Gets or sets the position of the decorated item in the game world. Access is delegated to the wrapped item.
    /// </summary>
    public Position Position { get => wrappedWeapon.Position;set => wrappedWeapon.Position = value;}

    /// <summary>
    /// Initializes a new instance of the <see cref="OffenceItemDecorator"/> class.
    /// </summary>
    /// <param name="wrappedWeapon">The weapon component to be decorated.</param>
    public OffenceItemDecorator(IWeapon wrappedWeapon){
        this.wrappedWeapon = wrappedWeapon;
    }

    /// <summary>
    /// Implements the <see cref="IDisposable"/> contract. 
    /// NOTE: For full cleanup, this should also call <c>wrappedWeapon.Dispose()</c> 
    /// if the decorator is responsible for the wrapped item's lifetime.
    /// </summary>
    public void Dispose(){
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Gets the total attack damage value. By default, this delegates the call to the wrapped item.
    /// Concrete subclasses must override this method to add their unique damage bonus or effects.
    /// </summary>
    /// <returns>The total attack damage from the wrapped weapon.</returns>
    public int GetTotalAttackDamage(){
        return wrappedWeapon.GetTotalAttackDamage();
    }
}
