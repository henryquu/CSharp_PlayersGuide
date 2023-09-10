Random rnd  = new Random();
char oatmeal = (char) (Convert.ToChar(rnd.Next(0, 9)) + '0');

List<char> used  = new List<char>();

while (used.Count < 10) {
    Console.Write("\nPick a number from 0 to 9: ");
    char input = Console.ReadKey().KeyChar;

    if (!char.IsDigit(input)){
        Console.WriteLine("\nEnter a single digit!");
        continue;
    }

    if (used.Contains(input)) {
        Console.WriteLine("\nNumber already used!");
        continue;
    }

    if (input == oatmeal) {
        throw new Exception("\nYou lost fool!");
    }

    used.Add(input);
}
