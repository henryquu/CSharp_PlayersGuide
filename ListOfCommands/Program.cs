Robot robot = new Robot();
robot.Commands = new List<IRobotCommand>();

bool cont = true;
while (cont) {
    switch (Console.ReadLine()) {
        case "on":
            robot.Commands.Add(new OnCommand());
            break;
        case "off":
            robot.Commands.Add(new OffCommand());
            break;    
        case "north":
            robot.Commands.Add(new NorthCommand());
            break;    
        case "south":
            robot.Commands.Add(new SouthCommand());
            break;    
        case "west":
            robot.Commands.Add(new WestCommand());
            break;    
        case "east":
            robot.Commands.Add(new EastCommand());
            break;    
        case "stop":
            cont = false;
            break;
        default : break;
    };
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
    public List<IRobotCommand> Commands { get; set; }
    public void Run() {
        foreach (IRobotCommand command in Commands) {
            command.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}