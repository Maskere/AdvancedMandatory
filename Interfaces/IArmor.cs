namespace MandatoryGameframework;

public interface IArmor : IWorldObject{
    ArmorSlot ArmorSlot {get;set;}
    int GetTotalDefencePoint();
}
