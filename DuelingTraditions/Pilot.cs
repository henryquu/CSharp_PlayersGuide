namespace Pilot;

public interface IPilot {
    public int GetPosition();
}

public class RobotPilot:IPilot {
    public int GetPosition() {
        Random random = new Random();

        Console.Clear();
        return random.Next(1, 100);
    }
}

public class HumanPilot:IPilot {
    public int GetPosition() {
        return Player.Player.GetGuess("Enter the position of the Manticore: ");
    }
}