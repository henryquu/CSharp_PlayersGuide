Console.Write("Give the x value: ");
int x = int.Parse(Console.ReadLine());

Console.Write("Give the y value: ");
int y = int.Parse(Console.ReadLine());

if (y > 0){
    if (x < 0)
        Console.WriteLine("The enemy is to the northwest!");
    else if (x == 0)
        Console.WriteLine("The enemy is to the north!");
    else
        Console.WriteLine("The enemy is to the northeast!");
}
else if (y == 0){
    if (x < 0)
        Console.WriteLine("The enemy is to the west!");
    else if (x == 0)
        Console.WriteLine("The enemy is here!");
    else
        Console.WriteLine("The enemy is to the east!");
}
else{
    if (x < 0)
        Console.WriteLine("The enemy is to the southwest!");
    else if (x == 0)
        Console.WriteLine("The enemy is to the south!");
    else
        Console.WriteLine("The enemy is to the southeast!");
}