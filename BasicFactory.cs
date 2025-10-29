namespace Mandatory;

public class BasicFactory : GameObjectFactory {
    public override Armor CreateArmor(){
        return new Armor(10,new BasicArmorIncrease(),new BasicArmorDecrease(),ArmorSlot.None) {Name = "Basic armor",Lootable = true, Removeable = true};
    }

    public override Weapon CreateWeapon() {
        return new Weapon(5, new BasicWeaponDamageIncrease(), new BasicWeaponDamageDecrease(),WeaponSlot.None) {Name = "Basic weapon",Lootable = true, Removeable = true};
    }

    public override Creature CreateCreature() {
        return new Minion("Minion",20,new BasicNotifier(),new ArmorCollection(new BasicArmorIncrease(),new BasicArmorDecrease()),new WeaponCollection(new BasicWeaponDamageIncrease(),new BasicWeaponDamageDecrease()));
    }
}
