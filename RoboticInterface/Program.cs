Robot robot = new Robot();

for (int i = 0; i < 3;) {
    robot.Commands [i] = Console.ReadLine() switch {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "west" => new WestCommand(),
        "east" => new EastCommand(),
        _ => null
    };

    if (robot.Commands [i] != null)
        i++;
}

robot.Run();

public interface IRobotCommand {
    void Run(Robot robot);
}

public class OnCommand:IRobotCommand {
    public void Run(Robot robot) {
        robot.IsPowered = true;
    }
}

public class OffCommand:IRobotCommand {
    public void Run(Robot robot) {
        robot.IsPowered = false;
    }
}

public class NorthCommand:IRobotCommand {
    public void Run(Robot robot) {
        if (robot.IsPowered)
            robot.Y++;
    }
}

public class SouthCommand:IRobotCommand {
    public void Run(Robot robot) {
        if (robot.IsPowered)
            robot.Y--;
    }
}

public class EastCommand:IRobotCommand {
    public void Run(Robot robot) {
        if (robot.IsPowered)
            robot.X++;
    }
}

public class WestCommand:IRobotCommand {
    public void Run(Robot robot) {
        if (robot.IsPowered)
            robot.X--;
    }
}

public class Robot {
    public int X {
        get; set;
    }
    public int Y {
        get; set;
    }
    public bool IsPowered {
        get; set;
    }
    public IRobotCommand? [] Commands { get; } = new IRobotCommand? [3];
    public void Run() {
        foreach (IRobotCommand? command in Commands) {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}