(Type type, Main main, Seasoning seasoning) food;

string [] types = new string [] { "Soup", "Stew", "Gumbo" };
string [] ingredients = new string [] { "Mushrooms", "Chicken", "Carrots", "Potatoes" };
string [] seasonings = new string [] { "Spicy", "Salty", "Sweet" };

food.type = (Type) (Menu(types, "type"));

food.main = (Main) (Menu(ingredients, "main ingredient"));

food.seasoning = (Seasoning) (Menu(seasonings, "seasoning"));

Console.WriteLine($"{food.seasoning.ToString()} {food.main.ToString()} {food.type.ToString()}");

int Menu(string []list, string what) {
    int number = list.Length + 1;

    while (number < 0 || number > list.Length - 1) {
        Console.Clear();

        Console.WriteLine("Choose the " + what + ":");
        for (int i = 0; i < list.Length; i++) {
            Console.WriteLine($"{i + 1}. {list [i]}");
        }

        Console.Write("Insert the number: ");
        number = int.Parse(Console.ReadLine()) - 1;
    }

    return number;
}


enum Type { Soup, Stew, Gumbo }
enum Main { Mushrooms, Chicken, Carrots, Potatoes }
enum Seasoning { Spicy, Salty, Sweet }