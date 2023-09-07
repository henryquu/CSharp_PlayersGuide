namespace Player{
    public static class Player {
        public static int GetGuess(string message) {
            int number = 0;

            Console.ForegroundColor = ConsoleColor.Yellow;
            while (number < 1 || number > 100) {
                Console.Write(message);
                number = int.Parse(Console.ReadLine());
            }

            return number;
        }
    }
}