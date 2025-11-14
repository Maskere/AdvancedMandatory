namespace Mandatory;

public interface IAttack{
    void RecieveHit(int hit);
    void Attack();
    int GetTotalDefence();
    int GetTotalOffence();
}
