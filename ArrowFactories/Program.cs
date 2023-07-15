Console.WriteLine("Which arrow do you want to get?");
Console.WriteLine("1. Elite arrow");
Console.WriteLine("2. Begginer arrow");
Console.WriteLine("3. Marksman arrow");
Console.WriteLine("4. Custom arrow");
Console.Write("Enter the number of the arrow: ");

Arrow a = Console.ReadLine() switch {
    "1" => Arrow.CreateEliteArrow(),
    "2" => Arrow.CreateBeginnerArrow(),
    "3" => Arrow.CreateMarksmanArrow(),
    _ => new Arrow()

};


Console.WriteLine(a.GetCost());

class Arrow {
    public Arrowhead _Arrowhead {
        get; set;
    }
    public int _Shaft {
        get; set;
    }
    public Fletching _Fletching {
        get; set;
    }

    public static Arrow CreateEliteArrow() {
        Arrow arrow = new Arrow();

        arrow._Arrowhead = (Arrowhead) 10;
        arrow._Shaft = 95;
        arrow._Fletching = (Fletching) 10;

        return arrow;
    }
    public static Arrow CreateBeginnerArrow() {
        Arrow arrow = new Arrow();

        arrow._Arrowhead = (Arrowhead) 3;
        arrow._Shaft = 75;
        arrow._Fletching = (Fletching) 3;

        return arrow;
    }

    public static Arrow CreateMarksmanArrow() {
        Arrow arrow = new Arrow();

        arrow._Arrowhead = (Arrowhead) 5;
        arrow._Shaft = 65;
        arrow._Fletching = (Fletching) 5;

        return arrow;
    }

    public static Arrow CreateCustom() {
        string [] arrowheads = new string [] { "Steel", "Wood", "Obsidian" };
        string [] fletchings = new string [] { "Plastic", "Turkey Feathers", "Goose Feathers" };

        Arrow arrow = new Arrow();

        arrow._Arrowhead = (Arrowhead) (arrow.Menu(arrowheads, "arrowhead", 0, 2));
        arrow._Shaft = arrow.GetInt("shaft", "length", 60, 100);
        arrow._Fletching = (Fletching) (arrow.Menu(fletchings, "fletching", 0, 2));

        return arrow;
    }


    public int Menu(string [] items, string item, int min, int max) {
        int number = min - 1;

        while (number < min || number > max) {
            Console.Clear();

            Console.WriteLine($"Choose {item} from the list below:");
            for (int i = 0; i < items.Length; i++)
                Console.WriteLine($"{i + 1}. {items [i]}");

            Console.Write($"Enter the number of the {item}: ");
            number = int.Parse(Console.ReadLine()) - 1;
        }

        return number;
    }

    public int GetInt(string item, string text, int min, int max) {
        int number = min - 1;

        while (number < min || number > max) {
            Console.Clear();
            Console.WriteLine($"Enter the {text} of the {item}");
            Console.WriteLine($"Allowed numbers: {min} - {max}");

            number = int.Parse(Console.ReadLine());
        }

        return number;
    }

    public float GetCost() {
        float cost;

        cost = _Arrowhead switch {

            Arrowhead.Steel => 10,
            Arrowhead.Wood => 3,
            _ => 5
        };

        cost += _Fletching switch {
            Fletching.Plastic => 10,
            Fletching.TurkeyFeathers => 5,
            _ => 3
        };

        cost += 0.05f * _Shaft;

        return cost;
    }
}



enum Arrowhead {
    Steel = 10, Wood = 3, Obsidian = 5
}
enum Fletching {
    Plastic = 10, TurkeyFeathers = 5, GooseFeathers = 3
}