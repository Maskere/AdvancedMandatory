namespace Mandatory;

public abstract class DefenceItem : GameObject, IIncreaseArmorValue,IDecreaseArmorValue{
    private IIncreaseArmorValue increaseArmorComponent;
    private IDecreaseArmorValue decreaseArmorComponent;

    public IIncreaseArmorValue IncreaseArmorComponent{
        get => increaseArmorComponent;
    }
    public IDecreaseArmorValue DecreaseArmorComponent{
        get => decreaseArmorComponent;
    }

    public DefenceItem(IIncreaseArmorValue increaseArmorComponent, IDecreaseArmorValue decreaseArmorComponent){
        this.increaseArmorComponent = increaseArmorComponent;
        this.decreaseArmorComponent = decreaseArmorComponent;
    }

    public virtual void IncreaseArmorValue(Armor target,int amount){
        increaseArmorComponent.IncreaseArmorValue(target,amount);
    }

    public virtual void DecreaseArmorValue(Armor target,int amount){
        decreaseArmorComponent.DecreaseArmorValue(target,amount);
    }

    public abstract int GetTotalDefencePoint();
}
