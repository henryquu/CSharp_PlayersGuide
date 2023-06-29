// See https://aka.ms/new-console-template for more information

Console.Title = "Defense of Consolas";

int rowTotal = 8;
int columnTotal = 8;

Console.Write("Target Row: ");
int row = int.Parse(Console.ReadLine());

Console.Write("Target Column: ");
int column = int.Parse(Console.ReadLine());

Console.WriteLine("Deploy to:");
Console.WriteLine($"({row}, {Math.Max(0, column - 1)})"); // left
Console.WriteLine($"({Math.Max(0, row - 1)}, {column})"); // down
Console.WriteLine($"({row}, {Math.Min(columnTotal, column + 1)})"); // right
Console.WriteLine($"({Math.Min(rowTotal, row + 1)}, {column})"); // top

Console.Beep();
