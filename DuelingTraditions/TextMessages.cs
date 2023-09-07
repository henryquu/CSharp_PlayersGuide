namespace TextMessages{
    public static class TextMessages {
        public static void RoundStart(int round, int city, int manticore, int damage) {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine($"STATUS: Round: {round} City: {city}/15 Manticore: {manticore}/10");
            Console.WriteLine($"The cannon is expected to deal {damage} damage this round.");
        }

        public static void Distance(int distance, int guessed) {
            if (guessed == distance) {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("That round was a DIRECT HIT!");
            }
            else if (guessed < distance)
                Console.WriteLine("That round FELL SHORT of the target.");
            else
                Console.WriteLine("That round FELL FAR of the target.");
        }

        public static void GameOver(int city, int manticore) {
            if (city < 0) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The Manticore has won! The city of Consolas has been destroyed!");
            }
            else if (manticore < 0) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
            }
        }
    }
}