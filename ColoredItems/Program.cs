ColoredItem<Sword> sword = new ColoredItem<Sword>(ConsoleColor.Blue, 10);
ColoredItem<Bow> bow = new ColoredItem<Bow>(ConsoleColor.Red, 10);
ColoredItem<Axe> axe = new ColoredItem<Axe>(ConsoleColor.Green, 10);

sword.Display();
bow.Display();
axe.Display();


public class ColoredItem<T> {
    int weight;
    ConsoleColor color;

    public ColoredItem(ConsoleColor Color, int Weight){
        weight = Weight;
        color = Color;
    }
    public void Display() {
        Console.ForegroundColor = color;
        Console.WriteLine(this.ToString());
    }
}

public class Sword {
}
public class Bow {
}
public class Axe {
}