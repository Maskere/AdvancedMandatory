namespace Mandatory;

/// <summary>
/// Represents a collection of individual armor items, treating them as a single IArmor component.
/// This class acts as the Composite in the Composite Pattern, providing methods to manage
/// and aggregate the stats of the equipped armor pieces.
/// </summary>
public class ArmorCollection : IArmor{
    private Dictionary<ArmorSlot, IArmor> armors = new();

    /// <summary>
    /// Gets or sets the name of the collection. Default is "Armor collection".
    /// </summary>
    public string? Name { get;set;} = "Armor collection";
    /// <summary>
    /// Gets or sets a value indicating whether the collection can be looted. Default is true.
    /// </summary>
    public bool Lootable { get;set;} = true;
    /// <summary>
    /// Gets or sets a value indicating whether the collection can be removed. Default is true.
    /// </summary>
    public bool Removeable { get;set;} = true;
    /// <summary>
    /// Gets or sets the armor slot designation. For a collection, this is typically set to ArmorSlot.All.
    /// </summary>
    public ArmorSlot ArmorSlot { get;set;} = ArmorSlot.All;
    /// <summary>
    /// Gets or sets the position of the armor collection in the game world.
    /// </summary>
    public Position Position { get;set;}

    /// <summary>
    /// Equips a new IArmor item into the collection.
    /// </summary>
    /// <param name="armor">The armor item to be equipped.</param>
    /// <exception cref="ArgumentException">Thrown if a full armor set (ArmorSlot.All) is already equipped and the new armor is not a full set.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the specific slot the new armor requires is already occupied.</exception>
    public void EquipArmor(IArmor armor){
        if(armors.ContainsKey(ArmorSlot.All) && armor.ArmorSlot != ArmorSlot.All){
            throw new ArgumentException("A full set of armor is equipped");
        }
        if(armors.ContainsKey(armor.ArmorSlot)){
            throw new InvalidOperationException($"Slot {armor.ArmorSlot} is already occupied");
        }

        armors.Add(armor.ArmorSlot, armor);
    }

    /// <summary>
    /// Removes an IArmor item from the collection based on its slot type.
    /// </summary>
    /// <param name="type">The slot type of the armor to unequip.</param>
    public void UnequipArmor(ArmorSlot type){
        if(armors.ContainsKey(type)){
            armors.Remove(type);
        }
    }

    /// <summary>
    /// Calculates the total combined defense point value by summing the defense of all equipped armor items.
    /// </summary>
    /// <returns>The sum of all GetTotalDefencePoint() calls on the child armor items.</returns>
    public int GetTotalDefencePoint() {
        int totalArmor = 0;

        foreach(IArmor item in armors.Values){
            totalArmor += item.GetTotalDefencePoint();
        }
        return totalArmor;
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting resources.
    /// This implementation disposes of all contained armor items before clearing the collection.
    /// </summary>
    public void Dispose(){
        foreach(IArmor ar in armors.Values){
            ar.Dispose();
        }
        armors.Clear();
        GC.SuppressFinalize(this);
    }
}
