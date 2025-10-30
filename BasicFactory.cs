namespace Mandatory;

public class BasicFactory : GameObjectFactory {
    public override Armor CreateArmor(){
        return new Armor(10,ArmorSlot.None) {Name = "Basic armor",Lootable = true, Removeable = true};
    }

    public override Weapon CreateWeapon() {
        return new Weapon(5,WeaponSlot.None) {Name = "Basic short sword", Lootable = true, Removeable = true};
    }

    public override Creature CreateCreature() {
        return new Minion("Minion",20,new BasicNotifier(),new ArmorCollection(),new WeaponCollection());
    }
}
