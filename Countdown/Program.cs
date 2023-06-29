void Countdown(int number) {
    if (number < 10)
        Countdown(number + 1);

    Console.WriteLine(number);
}

Countdown(1);
