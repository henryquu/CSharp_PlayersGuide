
new Game();

public record struct Room(string message);
public record struct Cords(int row, int col);

public static class Player {
    public static string Move() {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("What do you want to do? ");

        return Console.ReadLine().ToLower();
    }

    public static int PickGameSize() {
        Console.ForegroundColor = ConsoleColor.Cyan;

        while (true){
            Console.Clear();
            Console.WriteLine("Which size of the game do you want to play?");
            Console.WriteLine("1. Small\n2. Medium\n3. Large");

            switch (Console.ReadLine()) {
                case "1":
                case "Small":
                    return 4;
                case "2":
                case "medium":
                    return 6;
                case "3":
                case "large":
                    return 8;
                default:
                    Console.WriteLine("Wrong size!");
                    break;
            }
        }
    }
}

public class Game {
    Room [,] rooms;
    Cords [] Pits;

    Cords currentCords;
    private Cords fountainCords;
    int Size { get; init; }
    bool FountainEnabled;
    


    public Game() {
        Size = Player.PickGameSize();
        rooms = new Room [Size, Size];
        currentCords = new Cords (0, 0);

        Random rnd = new Random();
        fountainCords = new Cords(rnd.Next(0, Size), rnd.Next(0, Size));
        rooms [fountainCords.row, fountainCords.col].message = "You hear water dripping in this room. The Fountain of Objects is here!";

        bool FountainEnabled = false;

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Welcome to the game!");

        while (true) {
            DisplayRoom();

            // player;s move
            GetPlayerMove();

            // game state check
            if (isFinished()) {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("You win!");
                break;
            }
        }
    }

    public void AddPits() {
        int number = Size switch {
            4 => 1,
            6 => 2,
            8 => 3,
            _ => 4
        };
        Pits = new Cords[number];

        Random rnd = new Random();

        for (int i=0; i < number; i++) {
            Cords cur = new Cords(rnd.Next(0, Size), rnd.Next(0, Size));
            if (cur == fountainCords || CheckForPit(cur))
                continue;
     

        }
    }

    public bool CheckForPit(Cords cords) {

        return false;
    }

    public void DisplayRoom() {
        Console.WriteLine($"You are in the room at {currentCords.ToString()}");
        // senses
        if (currentCords == fountainCords)
            Console.ForegroundColor = ConsoleColor.Blue;
        else if (currentCords == new Cords (0, 0))
            Console.ForegroundColor = ConsoleColor.Yellow;
        else
            Console.ForegroundColor = ConsoleColor.White;

        if (rooms [currentCords.row, currentCords.col].message != null)
            Console.WriteLine(rooms [currentCords.row, currentCords.col].message);
    }
    public bool isFinished() {
        if (FountainEnabled && currentCords.row == 0 && currentCords.col == 0)
            return true;

        return false;
    }

    public bool EnableFountain() {
        if (currentCords == fountainCords) {
            FountainEnabled = true;
            rooms[fountainCords.row, fountainCords.col].message = "You hear the rushing waters from the Fountain of Objects. It has been reactivated!";
            return true;
        }
        
        Console.WriteLine("The Fountain of Objects is not here!");
        return false;
    }

    public void GetPlayerMove() {
        Cords moveResult;

        while (true) {
            moveResult = new Cords (currentCords.row, currentCords.col);

            switch (Player.Move()) {
                case "move east":
                    moveResult.col += 1;
                    break;
                case "move west":
                    moveResult.col -= 1;
                    break;
                case "move north":
                    moveResult.row += 1;
                    break;
                case "move south":
                    moveResult.row -= 1;
                    break;
                case "enable fountain":
                    if (this.EnableFountain()) 
                        return;
                    break;
                default:
                    break;
            }


            if (moveResult.row < 0 || moveResult.row >= Size ||
                moveResult.col < 0 || moveResult.col >= Size
            ){
                Console.WriteLine("You can't move there!");
                continue;
            }

            (currentCords.row, currentCords.col) = moveResult;
            return;
        }
    }
}