Console.WriteLine("How many provinces do you have? ");
int provinces = int.Parse(Console.ReadLine());

Console.WriteLine("How many duchies do you have? ");
int duchies = int.Parse(Console.ReadLine());

Console.WriteLine("How many estates do you have? ");
int estates = int.Parse(Console.ReadLine());

int totalScore = 6 * provinces + 3 * duchies + estates;
Console.WriteLine("Total score: " + totalScore);