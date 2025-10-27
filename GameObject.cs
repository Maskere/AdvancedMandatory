namespace Mandatory;

public abstract class GameObject{
    public string? Name {get;set;}
    public bool Lootable {get;set;}
    public bool Removeable {get;set;}

    public override string ToString() {
        return $"{Name} - Lootable: {Lootable} - Removeable: {Removeable}";
    }

    public abstract void Instantiate();
}
