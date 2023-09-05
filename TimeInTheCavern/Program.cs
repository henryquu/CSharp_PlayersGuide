
new Game();

public record struct Room(string message = "");
public record struct Cords(int row, int col);

public static class Player {
    public static string? Move() {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("What do you want to do? ");

        return Console.ReadLine().ToLower();
    }

    public static int PickGameSize() {
        Console.ForegroundColor = ConsoleColor.Cyan;

        while (true) {
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
    private Room [,] rooms;
    private Cords [] Pits;
    private Cords [] Maelstroms;

    private Cords CurrentCords;
    private Cords FountainCords;
    private Cords EntranceCords;
    private DateTime startTime;

    private int Size {
        get; init;
    }
    private bool FountainEnabled;

    public Game() {
        Size = Player.PickGameSize();
        rooms = new Room [Size, Size];
        CurrentCords = new Cords(0, 0);

        Random rnd = new Random();
        FountainCords = new Cords(rnd.Next(0, Size), rnd.Next(0, Size));
        rooms [FountainCords.row, FountainCords.col].message = "You hear water dripping in this room. The Fountain of Objects is here! ";

        EntranceCords = new Cords(0, 0);
        rooms [0, 0].message = "You see light coming from the cavern entrance. ";
        startTime = DateTime.Now;

        bool FountainEnabled = false;

        AddPits();
        AddMalestroms();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Welcome to the game!");

        while (true) {
            DisplayRoom();

            // player;s move
            GetPlayerMove();

            if (IsMaelstrom(CurrentCords))
                for (int i = 0; i < Maelstroms.Length; i++)
                    if (Maelstroms [i] == CurrentCords)
                        MaelstromEncounter(ref Maelstroms [i]);

            // game state check
            switch (isFinished()) {
                case 1:
                    WriteGameEndMessage("You win!");
                    return;
                case -1:
                    WriteGameEndMessage("You lost!");
                    return;
                default:
                    break;
            }
        }
    }

    public void WriteGameEndMessage(string message) {
        Console.ForegroundColor = ConsoleColor.Magenta;

        TimeSpan time = DateTime.Now - startTime;
        Console.WriteLine($"The game ended in {time.Seconds} seconds!");
        Console.WriteLine(message);
    }

    public void AddPits() {
        int number = Size switch {
            4 => 1,
            6 => 2,
            8 => 3,
            _ => 4
        };
        Pits = new Cords [number];

        Random rnd = new Random();
        Cords cur;

        for (int i = 0; i < number;) {
            cur = new Cords(rnd.Next(0, Size), rnd.Next(0, Size));
            if (IsFountain(cur) || IsPit(cur) || IsEntrance(cur) || IsMaelstrom(cur))
                continue;

            Pits [i++] = cur;
            AddHorVerMessages(cur, "You feel a draft. There is a pit in a nearby room. ");
        }
    }

    public void AddMalestroms() {
        int number = Size switch {
            4 => 1,
            6 => 1,
            _ => 3
        };

        Maelstroms = new Cords [number];

        Random rnd = new Random();
        Cords cur;

        for (int i = 0; i < number;) {
            cur = new Cords(rnd.Next(0, Size), rnd.Next(0, Size));
            if (IsFountain(cur) || IsPit(cur) || IsEntrance(cur) || IsMaelstrom(cur))
                continue;

            Maelstroms [i++] = cur;
            AddHorVerMessages(cur, "You hear the growling and groaning of a maelstrom nearby. ");
            AddDiagonalMessages(cur, "You hear the growling and groaning of a maelstrom nearby. ");
        }
    }

    public void MaelstromEncounter(ref Cords maelstrom) {
        if (CurrentCords.row < Size - 1)
            CurrentCords.row++;

        CurrentCords.col += (CurrentCords.col + 2) % Size - 1;

        if (CurrentCords.row > 0)
            maelstrom.row--;

        maelstrom.col += (maelstrom.col - 2) % Size - 1;

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("You encountered a maelstrom!");
    }

    public void AddDiagonalMessages(Cords cell, string message) {
        Cords cur;

        for (int i = -1; i < 2; i += 2) {
            // 1st row
            cur = new Cords(cell.row + i, cell.col + i);

            if (!IsPit(cur) && IsValid(cur))
                rooms [cur.row, cur.col].message += message;

            // 2nd row
            cur = new Cords(cell.row - i, cell.col - i);

            if (!IsPit(cur) && IsValid(cur))
                rooms [cur.row, cur.col].message += message;
        }
    }

    public void AddHorVerMessages(Cords cell, string message) {
        Cords cur;

        for (int i = -1; i < 2; i += 2) {
            // horizontals
            cur = new Cords(cell.row, cell.col + i);

            if (!IsPit(cur) && IsValid(cur))
                rooms [cur.row, cur.col].message += message;

            // verticals
            cur = new Cords(cell.row - i, cell.col);

            if (!IsPit(cur) && IsValid(cur))
                rooms [cur.row, cur.col].message += message;
        }
    }

    public bool IsMaelstrom(Cords cord) {
        foreach (Cords maelstrom in Pits) {
            if (cord == maelstrom)
                return true;
        }

        return false;
    }

    public bool IsValid(Cords cord) => (cord.row < Size && cord.row >= 0 && cord.col < Size && cord.col >= 0);

    public bool IsEntrance(Cords cord) => (cord == EntranceCords);

    public bool IsFountain(Cords cord) => (cord == FountainCords);

    public bool IsPit(Cords cord) {
        foreach (Cords pit in Pits) {
            if (cord == pit)
                return true;
        }

        return false;
    }

    public void DisplayRoom() {
        Console.WriteLine($"You are in the room at {CurrentCords.ToString()}");
        // senses
        if (IsFountain(CurrentCords))
            Console.ForegroundColor = ConsoleColor.Blue;
        else if (CurrentCords == new Cords(0, 0))
            Console.ForegroundColor = ConsoleColor.Yellow;
        else
            Console.ForegroundColor = ConsoleColor.White;

        if (rooms [CurrentCords.row, CurrentCords.col].message != null)
            Console.WriteLine(rooms [CurrentCords.row, CurrentCords.col].message);
    }
    public int isFinished() {
        if (FountainEnabled && IsEntrance(CurrentCords))
            return 1;
        else if (IsPit(CurrentCords))
            return -1;

        return 0;
    }

    public bool EnableFountain() {
        if (IsFountain(CurrentCords)) {
            FountainEnabled = true;
            rooms [FountainCords.row, FountainCords.col].message = "You hear the rushing waters from the Fountain of Objects. It has been reactivated!";
            return true;
        }

        Console.WriteLine("The Fountain of Objects is not here!");
        return false;
    }

    public void GetPlayerMove() {
        Cords moveResult;

        while (true) {
            moveResult = new Cords(CurrentCords.row, CurrentCords.col);

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


            if (!IsValid(moveResult)) {
                Console.WriteLine("You can't move there!");
                continue;
            }

            (CurrentCords.row, CurrentCords.col) = moveResult;
            return;
        }
    }
}