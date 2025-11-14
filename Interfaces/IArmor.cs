namespace Mandatory;

public interface IArmor : IWorldObject{
    ArmorSlot ArmorSlot {get;set;}
    int GetTotalDefencePoint();
}
