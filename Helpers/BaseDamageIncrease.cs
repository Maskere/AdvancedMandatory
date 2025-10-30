namespace Mandatory;

public class BaseDamageIncrease : IIncreaseWeaponDamage {
    public void IncreaseWeaponDamage(IWeaponModTarget target, int amount) {
        target.ChangeWeaponDamage(amount);
    }
}
