int integer;
do {
    Console.WriteLine("Enter an integer");
  
} while (!int.TryParse(Console.ReadLine(), out integer));
Console.WriteLine(integer);

double doub;
do {
    Console.WriteLine("Enter an double");

} while (!double.TryParse(Console.ReadLine(), out doub));
Console.WriteLine(doub);

float floating;
do {
    Console.WriteLine("Enter an float");

} while (!float.TryParse(Console.ReadLine(), out floating));
Console.WriteLine(floating);
