Sword sword = new Sword(Materials.Iron, Gems.None, 10, 10);

Sword sword1 = sword with {material = Materials.Wood};
Sword sword2 = sword with {CrossguardLength = 15};

Console.WriteLine(sword);
Console.WriteLine(sword1);
Console.WriteLine(sword2);


public enum Materials{Wood, Bronze, Iron, Steel, Binarium}
public enum Gems{Emerald, Amber, Sapphire, Diamond, Bitstone, None}

public record Sword(Materials material, Gems gemstone, int CrossguardLength, int CrossguardWidth);