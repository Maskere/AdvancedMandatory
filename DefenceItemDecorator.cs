namespace MandatoryGameframework;

/// <summary>
/// Represents the abstract base class for all decorators that add functionality to an <see cref="IArmor"/> item.
/// It adheres to the Decorator Pattern by implementing the common <see cref="IArmor"/> interface
/// and holding a reference to the item it wraps.
/// </summary>
public abstract class DefenceItemDecorator : IArmor{
    /// <summary>
    /// The reference to the core armor component being wrapped and decorated.
    /// </summary>
    protected readonly IArmor wrappedItem;

    /// <summary>
    /// Gets or sets the slot type this armor occupies. Access is delegated to the wrapped item.
    /// </summary>
    public ArmorSlot ArmorSlot {get => wrappedItem.ArmorSlot;set => wrappedItem.ArmorSlot = value;}
    /// <summary>
    /// Gets or sets the name of the decorated item. Access is delegated to the wrapped item.
    /// </summary>
    public string? Name {get => wrappedItem.Name;set => wrappedItem.Name = value;}
    /// <summary>
    /// Gets or sets a value indicating whether the decorated item can be looted. Access is delegated to the wrapped item.
    /// </summary>
    public bool Lootable {get => wrappedItem.Lootable;set => wrappedItem.Lootable = value;}
    /// <summary>
    /// Gets or sets a value indicating whether the decorated item can be removed. Access is delegated to the wrapped item.
    /// </summary>
    public bool Removeable {get => wrappedItem.Removeable;set => wrappedItem.Removeable = value;}
    /// <summary>
    /// Gets or sets the position of the decorated item in the game world. Access is delegated to the wrapped item.
    /// </summary>
    public Position Position { get => wrappedItem.Position;set => wrappedItem.Position = value;}

    /// <summary>
    /// Initializes a new instance of the <see cref="DefenceItemDecorator"/> class.
    /// </summary>
    /// <param name="wrappedItem">The armor component to be decorated.</param>
    public DefenceItemDecorator(IArmor wrappedItem){
        this.wrappedItem = wrappedItem;
    }

    /// <summary>
    /// Gets the total defense point value. By default, this delegates the call to the wrapped item.
    /// Concrete subclasses will override this method to add their unique defensive bonus.
    /// </summary>
    /// <returns>The total defense points from the wrapped item.</returns>
    public virtual int GetTotalDefencePoint() {
        return wrappedItem.GetTotalDefencePoint();
    }

    /// <summary>
    /// Implements the <see cref="IDisposable"/> contract. 
    /// NOTE: For full cleanup, this should also call <c>wrappedItem.Dispose()</c> 
    /// if the decorator is responsible for the wrapped item's lifetime.
    /// </summary>
    public void Dispose() {
        GC.SuppressFinalize(this);
    }
}
