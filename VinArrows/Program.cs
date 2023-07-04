Arrow b = new Arrow();
Console.WriteLine(b.GetCost());

class Arrow {
    public Arrowhead _arrowhead;
    public int _shaft;
    public Fletching _fletching;

    public Arrow() {
        string [] arrowheads = new string [] { "Steel", "Wood", "Obsidian" };
        string [] fletchings = new string [] { "Plastic", "Turkey Feathers", "Goose Feathers" };

        _arrowhead = (Arrowhead) (Menu(arrowheads, "arrowhead", 0, 2));
        _shaft = GetInt("shaft", "length", 60, 100);
        _fletching = (Fletching) (Menu(fletchings, "fletching", 0, 2));
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

        cost = _arrowhead switch {

            Arrowhead.Steel => 10,
            Arrowhead.Wood => 3,
            _ => 5
        };

        cost += _fletching switch {
            Fletching.Plastic => 10,
            Fletching.TurkeyFeathers => 5,
            _ => 3
        };

        cost += 0.05f * _shaft;

        return cost;
    }
}



enum Arrowhead { Steel = 10, Wood = 3, Obsidian = 5 }
enum Fletching { Plastic = 10, TurkeyFeathers = 5, GooseFeathers = 3 }