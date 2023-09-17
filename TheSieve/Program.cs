using System.Reflection;

Predicate<int> [] options = {Sieve.IsEven, Sieve.IsPositive, Sieve.IsTenMultiple};
Predicate<int>? pickedFunction = null;

while (true){
    Console.Clear();
    Console.WriteLine("Pick the thing to check");

    foreach (Predicate<int> option in options) 
        Console.WriteLine(option.GetMethodInfo().Name);

    Console.Write("Pick the name: ");
    string? answer = Console.ReadLine();

    foreach (Predicate<int> option in options)
        if (answer == option.GetMethodInfo().Name) {
            pickedFunction = option;
            break;
        }
    if (pickedFunction != null) {
        break;
    }
}

string? input;
int number;
while (true) {
    Console.Write("Enter a number: ");
    input = Console.ReadLine();

    if (!int.TryParse(input, out number)) {
        Console.WriteLine("Input must be a number!");
        continue;
    }
  
    Console.WriteLine("The output of checking the number is: {0}", pickedFunction(number));
}

public static class Sieve {
    public static bool IsGood(int number, Predicate<int> comparator) {
        return true;
    }

    public static bool IsEven(int number) {
        return number % 2 == 0;
    }

    public static bool IsPositive(int number) {
        return number > 0;
    }

    public static bool IsTenMultiple(int number) {
        return (number / 10) % 1 == 0;
    }
}