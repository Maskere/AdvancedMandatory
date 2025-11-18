namespace MandatoryGameframework;

public interface IAttack{
    void RecieveHit(int hit);
    void Attack();
    int GetTotalDefence();
    int GetTotalOffence();
}
