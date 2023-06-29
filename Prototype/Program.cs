int theNumber = -1;
while (theNumber < 0 || theNumber > 100) {
    Console.Write("User 1, enter a number between 0 and 100: ");
    theNumber = int.Parse(Console.ReadLine());
}

Console.Clear();

Console.WriteLine("User 2, guess the number.");
int guessed = - 1;
while (guessed != theNumber){
    Console.Write("What is your next guess? ");
    guessed = int.Parse(Console.ReadLine());

    if (guessed > theNumber)
        Console.WriteLine($"{guessed} is too high.");
    else if (guessed < theNumber)
        Console.WriteLine($"{guessed} is too low.");
}

Console.WriteLine("You guessed the number!");
