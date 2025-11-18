namespace MandatoryGameframework;

/// <summary>
/// Represents a composite structure for managing multiple weapon items, treating them as a single <see cref="IWeapon"/> component.
/// This class aggregates the attack damage of all equipped weapons.
/// </summary>
public class WeaponCollection : IWeapon{
    private Dictionary<WeaponSlot, IWeapon> weapons = new();

    /// <summary>
    /// Gets or sets the name of the collection. Default is "Weapon collection".
    /// </summary>
    public string? Name {get;set;} = "Weapon collection";
    /// <summary>
    /// Gets or sets a value indicating whether the collection can be looted. Default is true.
    /// </summary>
    public bool Lootable {get;set;} = true;
    /// <summary>
    /// Gets or sets a value indicating whether the collection can be removed. Default is true.
    /// </summary>
    public bool Removeable {get;set;} = true;
    /// <summary>
    /// Gets or sets the weapon slot designation. For a collection, this is typically set to WeaponSlot.All.
    /// </summary>
    public WeaponSlot WeaponSlot { get;set;} = WeaponSlot.All;
    /// <summary>
    /// Gets or sets the position of the weapon collection in the game world.
    /// </summary>
    public Position Position { get;set;}

    /// <summary>
    /// Equips a new <see cref="IWeapon"/> item into the collection, keyed by its slot.
    /// </summary>
    /// <param name="weapon">The weapon item to be equipped.</param>
    /// <exception cref="InvalidOperationException">Thrown if the specific slot the weapon requires is already occupied.</exception>
    public void EquipWeapon(IWeapon weapon){
        if(weapons.ContainsKey(weapon.WeaponSlot)){
            throw new InvalidOperationException($"Slot {weapon.WeaponSlot} is already occupied");
        }
        weapons.Add(weapon.WeaponSlot, weapon);
    }

    /// <summary>
    /// Removes an <see cref="IWeapon"/> item from the collection based on its slot type.
    /// </summary>
    /// <param name="slot">The slot type of the weapon to unequip.</param>
    public void UnequipWeapon(WeaponSlot slot){
        if(weapons.ContainsKey(slot)){
            weapons.Remove(slot);
        }
    }

    /// <summary>
    /// Calculates the total combined attack damage value by summing the damage of all equipped weapons.
    /// </summary>
    /// <returns>The sum of all <c>GetTotalAttackDamage()</c> calls on the child weapon items.</returns>
    public int GetTotalAttackDamage() {
        int totalDamage = 0;

        foreach(IWeapon item in weapons.Values){
            totalDamage += item.GetTotalAttackDamage();
        }
        return totalDamage;
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting resources.
    /// This implementation disposes of all contained weapon items before clearing the collection.
    /// </summary>
    public void Dispose(){
        foreach(IWeapon we in weapons.Values){
            we.Dispose();
        }
        weapons.Clear();
        GC.SuppressFinalize(this);
    }
}
