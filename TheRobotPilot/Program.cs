new Game(new RobotPilot());

public class Game {
    private int manticore;
    private int city;
    private int Round { get;  set; }

    public Game(IPilot Pilot, int manticore = 10, int city = 15) {
        this.manticore = manticore;
        this.city = city;

        Round = 1;

        int distance = Pilot.GetPosition();
        int guessed = 0;
        int damage;

        while (manticore > 0 && city > 0) {
            damage = CurrentDamage(Round);
            
            TextMessages.RoundStart(Round, city, manticore, damage);

            guessed = Player.GetGuess("Enter desired cannon range: ");
            if (guessed == distance)
                manticore -= damage;

            TextMessages.Distance(distance, guessed);

            if (manticore > 0) {
                city--;
                Round++;
            }
        }
        TextMessages.GameOver(city, manticore);
    }

    int CurrentDamage(int round) {
        int damage = (round % 5 == 0) ? 5 : 1;
        damage *= (round % 3 == 0) ? 3 : 1;

        return damage;
    }
  
}

public static class TextMessages {
    public static void RoundStart(int round, int city, int manticore, int damage){
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

public interface IPilot {
    public int GetPosition();
}

public class RobotPilot: IPilot {
    public int GetPosition() {
        Random random = new Random();

        Console.Clear();
        return random.Next(1, 100);
    }
}

public class HumanPilot: IPilot {
    public int GetPosition() {
        return Player.GetGuess("Enter the position of the Manticore: ");
    }
}