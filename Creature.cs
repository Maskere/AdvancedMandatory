namespace Mandatory;

public abstract class Creature : GameObject{
    private ArmorCollection defence;
    private WeaponCollection offence;

    private INotifier notifier;
    public int HitPoint {get;set;}

    /// <summary>
    /// Initialize the creature with name and hitpoint.
    /// Also initializes the inventory collection.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="hitPoint"></param>
    public Creature(string? name, int hitPoint, INotifier notifier,ArmorCollection defence,WeaponCollection offence){
        this.defence = defence;
        this.offence = offence;
        this.notifier = notifier;
        Name = name;
        HitPoint = hitPoint;
    }

    public abstract void TakeTurn();

    public virtual void Hit(){
    }

    public virtual void RecieveHit(int hit){
        if(hit == 0) return;

        HitPoint -= hit;
        string status = $"{Name} was hit for {hit}";
        notifier.Notify(status);
    }

    public abstract void Loot(GameObject loot);

    public int GetTotalDefense(){
        return defence.GetTotalDefencePoint();
    }

    public int GetTotalOffence(){
        return offence.GetTotalAttackDamage();
    }

    public override void Instantiate(){
    }
}
