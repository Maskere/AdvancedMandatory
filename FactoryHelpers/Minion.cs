namespace Mandatory;

public class Minion : Creature {
    private INotifier notifier;

    public Minion(string? name, int hitPoint,INotifier notifier, ArmorCollection armorCollection, WeaponCollection weaponCollection) :base(name,hitPoint,notifier,armorCollection,weaponCollection){
        Name = name;
        HitPoint = hitPoint;
        this.notifier = notifier;
    }

    public override void Loot(GameObject loot) {
        throw new NotImplementedException();
    }

    public override void TakeTurn() {
        throw new NotImplementedException();
    }
}
