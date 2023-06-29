// See https://aka.ms/new-console-template for more information

Console.WriteLine("Enter the number of chocolate eggs: ");
int eggsTotal = int.Parse(Console.ReadLine());

int eggsSister = eggsTotal / 3;
int eggsDuck = eggsTotal % 3;

Console.WriteLine("Eggs for each sister: " + eggsSister + " for Duck: " + eggsDuck);
