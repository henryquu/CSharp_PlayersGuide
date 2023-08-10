Pack inventory = new Pack(10, 10, 5);
int picked = 0;
InventoryItem item;


while (true) {
    Console.Clear();

    while (picked < 1 || picked > 6) {
        Console.WriteLine(inventory.ToString());
        Console.WriteLine(
    @"Items you can add to the inventory:
         1. Arrow
         2. Bow
         3. Rope
         4. Water
         5. Food
         6. Sword");

        Console.Write("Insert the number of the item to add: ");
        picked = Convert.ToInt32(Console.ReadLine());
    }

    item = picked switch {
        1 => new Arrow(),
        2 => new Bow(),
        3 => new Rope(),
        4 => new Water(),
        5 => new Food(),
        _ => new Sword()
    };

    if (inventory.AddInventoryItem(item))
        Console.WriteLine("Item succesfully added!");
    else
        Console.WriteLine("Wasn't able to add the item!");

    Console.WriteLine("Press a key...");
    Console.ReadKey();
    picked = 0;
}


class Pack {
    private double WeightMax {
        get;
    }
    private double VolumeMax {
        get;
    }
    private int ItemsMax {
        get;
    }

    private double WeightCurrent { get; set; } = 0;
    private double VolumeCurrent { get; set; } = 0;
    private int ItemsCurrent { get; set; } = 0;

    public InventoryItem [] items;

    public Pack(double maxWeight, double maxVolume, int maxItems) {
        WeightMax = maxWeight;
        VolumeMax = maxVolume;
        ItemsMax = maxItems;

        items = new InventoryItem [ItemsMax];
    }

    public bool AddInventoryItem(InventoryItem item) {
        if (ItemsMax == ItemsCurrent)
            return false;

        if (item._weight > WeightMax - WeightCurrent)
            return false;

        if (item._volume > VolumeMax - VolumeCurrent)
            return false;

        items [ItemsCurrent++] = item;
        VolumeCurrent += item._volume;
        WeightCurrent += item._weight;

        return true;
    }

    public new string ToString() {
        if (ItemsCurrent == 0)
            return "Pack is empty!";

        string str = "Pack containing";

        for (int i=0; i < ItemsCurrent; i++)
            str += " " + items[i].ToString();

        return str;
    }
}

class InventoryItem {
    public double _weight;
    public double _volume;

    public InventoryItem(double weight, double volume) {
        _weight = weight;
        _volume = volume;
    }
}

class Arrow:InventoryItem {

    public Arrow() : base(0.1, 0.05) { }

    public new string ToString() => "Arrow";
}

class Bow:InventoryItem {

    public Bow() : base(1, 4) { }

    public new string ToString() => "Bow";
}

class Rope:InventoryItem {

    public Rope() : base(1, 1.5) { }

    public new string ToString() => "Rope";
}

class Water:InventoryItem {

    public Water() : base(2, 3) { }

    public new string ToString() => "Water";
}

class Food:InventoryItem {

    public Food() : base(1, 0.5) { }

    public new string ToString() => "Food";
}

class Sword:InventoryItem {
    public Sword() : base(5, 3) { }

    public new string ToString() => "Sword";
}