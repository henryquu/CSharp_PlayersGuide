using static System.Net.Mime.MediaTypeNames;

int manticore = 10;
int city = 15;
int round = 1;

int distance = GetPosition();
int guessed = 0;

while (manticore > 0 && city > 0) {
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("-----------------------------------------------------------");
    Console.WriteLine($"STATUS: Round: {round} City: {city}/15 Manticore: {manticore}/10");

    int damage = CurrentDamage(round);
    Console.WriteLine($"The cannon is expected to deal {damage} damage this round.");

    guessed = GetGuess();
    if (guessed == distance)
        manticore -= damage;
    DistanceMessage(distance, guessed);

    if (manticore > 0) {
        city--;
        round++;
    }
}

GameOver(city, manticore);


void GameOver(int city, int manticore) {
    if (city < 0) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("The Manticore has won! The city of Consolas has been destroyed!");
    }
    else if (manticore < 0) {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
    }
}

void DistanceMessage(int goal, int guess) { 
    if (guessed == distance) {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("That round was a DIRECT HIT!");
    }
    else if (guessed < distance)
        Console.WriteLine("That round FELL SHORT of the target.");
    else
        Console.WriteLine("That round FELL FAR of the target.");
}

int GetPosition() {
    string text = "Player 1, how far away from the city " +  
                  "do you want to station the Manticore? ";

    int distance = GetNumberInRange(text, 1, 100);
    
    Console.Clear();
    return distance;
}

int GetGuess() {
    return GetNumberInRange("Enter desired cannon range: ", 1, 100);
}

int CurrentDamage(int round) {
    int damage = (round % 5 == 0) ? 5 : 1;
    damage *= (round % 3 == 0) ? 3 : 1;

    return damage;
}

/// 
int GetNumberInRange(string text, int min, int max) {
    int number = min -1;

    Console.ForegroundColor = ConsoleColor.Yellow;
    while(number < min || number > max) {
        Console.Write(text);
        number = int.Parse(Console.ReadLine());
    }

    return number;
}