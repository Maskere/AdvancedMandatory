namespace Mandatory;

public class DamageDecorator : IIncreaseWeaponDamage {
    private IIncreaseWeaponDamage wrappedComponent;

    public DamageDecorator(IIncreaseWeaponDamage wrappedComponent){
        this.wrappedComponent = wrappedComponent;
    }

    public void IncreaseWeaponDamage(IWeaponModTarget target, int amount) {
        wrappedComponent.IncreaseWeaponDamage(target,amount);
    }
}
