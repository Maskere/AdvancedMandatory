namespace Mandatory;

public abstract class Creature : GameObject{
    private IDamageCalculator damageCalculator;
    private INotifier notifier;

    public ArmorCollection Defence {get;}
    public WeaponCollection Offence {get;}

    public int HitPoint {get;set;}

    /// <summary>
    /// Initialize the creature with name and hitpoint.
    /// Also initializes the inventory collection.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="hitPoint"></param>
    public Creature(string? name, int hitPoint, INotifier notifier,ArmorCollection defence,WeaponCollection offence, IDamageCalculator damageCalculator){
        this.Defence = defence;
        this.Offence = offence;
        this.notifier = notifier;
        this.damageCalculator = damageCalculator;
        Name = name;
        HitPoint = hitPoint;
    }

    public abstract void TakeTurn();

    public virtual void Hit(){
    }

    public virtual void RecieveHit(int hit){
        if(hit == 0) return;

        int totalHitBy = damageCalculator.CalculateFinalDamage(this,hit);
        HitPoint -= totalHitBy;

        string status = $"{Name} was hit for {totalHitBy}";
        notifier.Notify(status);
    }

    public abstract void Loot(GameObject loot);

    public int GetTotalDefense(){
        return Defence.GetTotalDefencePoint();
    }

    public int GetTotalOffence(){
        return Offence.GetTotalAttackDamage();
    }
}
