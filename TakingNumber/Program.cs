int AskForNumber(string text){
    Console.WriteLine(text);
    int response = int.Parse(Console.ReadLine());

    return response;
}

int AskForNumberInRange(string text, int min, int max){
    int response = min - 1;

    while (response < min || response > max) {
        Console.Write(text);
        response = int.Parse(Console.ReadLine());
    }

    return response;
}