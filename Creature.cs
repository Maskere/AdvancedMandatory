namespace MandatoryGameframework;

/// <summary>
/// Represents the abstract base class for all creatures in the game world.
/// A creature is a game object that can move, attack, take damage, and equip gear.
/// </summary>
public abstract class Creature : ICreature, IAttack, ISelectTarget{
    private ITransform transform;
    private IDamageCalculator damageCalculator;
    private INotifier notifier;

    public IGameObject? currentTarget {get; protected set;}

    /// <summary>
    /// Gets the equipped defensive item (armor). Can be null.
    /// </summary>
    public IArmor Defence {get; private set;}
    /// <summary>
    /// Gets the equipped offensive item (weapon). Can be null.
    /// </summary>
    public IWeapon Offence {get; private set;}

    /// <summary>
    /// Gets or sets the current hit points (health) of the creature.
    /// </summary>
    public int HitPoint {get;set;}
    /// <summary>
    /// Gets or sets the name of the creature.
    /// </summary>
    public string? Name {get;set;}
    /// <summary>
    /// Gets or sets a value indicating whether the creature drops loot upon removal/death.
    /// </summary>
    public bool Lootable {get;set;}
    /// <summary>
    /// Gets or sets a value indicating whether the creature can be removed from the game world.
    /// </summary>
    public bool Removeable {get;set;}
    /// <summary>
    /// Gets or sets the current position of the creature in the game world.
    /// </summary>
    public Position Position {get;set;}

    /// <summary>
    /// Initializes a new instance of the <see cref="Creature"/> class.
    /// </summary>
    /// <param name="transform">The component responsible for the creature's spatial properties.</param>
    /// <param name="notifier">The service used to notify the game world (e.g., UI, log) of events.</param>
    /// <param name="damageCalculator">The service used to calculate final damage taken.</param>
    public Creature(ITransform transform,INotifier notifier, IDamageCalculator damageCalculator){
        this.Defence = new Armor(0,ArmorSlot.None);
        this.Offence = new Weapon(0,WeaponSlot.None);
        this.transform = transform;
        this.notifier = notifier;
        this.damageCalculator = damageCalculator;
    }

    /// <summary>
    /// Abstract method for the creature to select a target for interaction (e.g., attack).
    /// </summary>
    public abstract void SelectTarget(IGameObject target);
    /// <summary>
    /// Abstract method for the creature's movement logic.
    /// </summary>
    public abstract void Move(Position delta);
    /// <summary>
    /// Abstract method for the creature's attack logic.
    /// </summary>
    public abstract void Attack();
    /// <summary>
    /// Abstract method for the creature's looting behavior.
    /// </summary>
    /// <param name="loot">The game object being looted.</param>
    public abstract void Loot(IGameObject loot);
    /// <summary>
    /// Abstract method representing the overall actions the creature takes during its turn.
    /// </summary>
    public abstract void TakeTurn();

    /// <summary>
    /// Applies damage to the creature, reducing its HitPoint after defense calculation.
    /// Notifies the game of the hit.
    /// </summary>
    /// <param name="hit">The raw incoming damage amount.</param>
    public virtual void RecieveHit(int hit){
        if(hit <= 0) return;

        int totalHitBy = damageCalculator.CalculateFinalDamage(this,hit);

        string status = $"{Name} was hit for {totalHitBy}";
        notifier.Notify(status);
    }

    /// <summary>
    /// Gets the total defense point value provided by the currently equipped armor.
    /// </summary>
    /// <returns>The total defense points, or 0 if no armor is equipped.</returns>
    public int GetTotalDefence(){
        if(Defence == null) return 0;
        return Defence.GetTotalDefencePoint();
    }

    /// <summary>
    /// Gets the total attack damage value provided by the currently equipped weapon.
    /// </summary>
    /// <returns>The total attack damage, or 0 if no weapon is equipped.</returns>
    public int GetTotalOffence(){
        if(Offence == null) return 0;
        return Offence.GetTotalAttackDamage();
    }

    /// <summary>
    /// Equips a new armor item to the creature's Defence slot.
    /// </summary>
    /// <param name="armor">The armor item to equip.</param>
    public void SetArmor(IArmor armor){
        this.Defence = armor;
    }

    /// <summary>
    /// Equips a new weapon item to the creature's Offence slot.
    /// </summary>
    /// <param name="weapon">The weapon item to equip.</param>
    public void SetWeapon(IWeapon weapon){
        this.Offence = weapon;
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose(){
        GC.SuppressFinalize(this);
    }
}
