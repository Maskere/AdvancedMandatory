namespace Mandatory;

public interface ICreature : IWorldObject, ILoot, IMoveable,ITakeTurn{
    int HitPoint {get;set;}
}
