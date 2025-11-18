namespace MandatoryGameframework;

public interface IDamageCalculator{
    int CalculateFinalDamage(ICreature target, int hit);
}
