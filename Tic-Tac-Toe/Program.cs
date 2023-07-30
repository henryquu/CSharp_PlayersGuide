
Game a  = new Game();
a.MultipleGames();


public class Game {
    private Board? board;
    private char currentPlayer;


    public char Start() {
        board = new Board();
        currentPlayer = 'O';

        while (true) {
            Console.Clear();
            Console.WriteLine($"It's {currentPlayer}'s turn.");
            board.Print();

            (int x, int y) cords;
            while(true) {
                cords = Player.GetCords(board.Size);

                if (board.InsertValue(cords, currentPlayer))
                    break;
                else
                    Console.WriteLine("Field isn't empty!");
            }

            if (board.IsFinished()) {
                Console.WriteLine($"{currentPlayer} wins!");
                return currentPlayer;
            }

            if (board.IsFull()) {
                Console.WriteLine("It's a draw!");
                return '\0';
            }

            currentPlayer = (currentPlayer == 'X') ? 'O': 'X';
        }
    }

    public void MultipleGames(int gameCount=5) {
        (int X, int O) score = (0, 0);

        char lastWinner = '\0';
        int curGame = gameCount;

        while (curGame > 0) {
            lastWinner = Start();

            if (lastWinner == 'O') {
                score.O++;
                curGame--;
            }
            if (lastWinner == 'X') {
                score.X++;
                curGame--;
            }

            if (score.O > gameCount / 2 || score.X > gameCount / 2)
                break;
        }

        Console.WriteLine($"{lastWinner} won!");
    }

}

public static class Player {
    public static (int x, int y) GetCords(int size) {
        (int row, int col) cords = (-1, -1);

        Console.WriteLine("What field do you want to play in? ");

        while (cords.col < 1 | cords.col > size) {
            Console.Write("Enter the column: ");

            try {
                cords.col = Convert.ToInt32(Console.ReadLine());
            }
            catch {
                Console.WriteLine($"Wrong input! Entera number from 1 to {size}");
            }
        }

        while (cords.row < 1 | cords.row > size){
            Console.Write("Enter the row: ");

            try {
                cords.row = Convert.ToInt32(Console.ReadLine());
            }
            catch {
                Console.WriteLine($"Wrong input! Entera number from 1 to {size}");
            }
        }

        return (cords.row - 1, cords.col -1);
    }
}

public class Board {
    public char [,] Grid;
    private int emptyCount;
    public int Size { get; }

    public Board(int size=3) {
        Grid = new char[size, size];
        emptyCount = size * size;
        Size = size;
    }

    public void Print() {
        char value;  

        for (int row=0; row < Size; row++) {
            for (int col = 0; col < Grid.GetLength(1); col++) {
                value = Grid [row, col] != 0 ? Grid [row, col] : ' ';

                if (col != Grid.GetLength(1) - 1)
                    Console.Write($" {value} |");
                else
                    Console.Write($" {value} ");
            }
            if (row != Grid.GetLength(0) - 1)
                Console.WriteLine("\n---+---+---");
        }

        Console.WriteLine();
    }

    public bool InsertValue((int row, int col) cords, char val) {
        if (Grid[cords.row, cords.col] == 0) {
            Grid[cords.row, cords.col] = val;
            emptyCount--;

            return true;
        }
        return false;
    }

    public bool IsFull() {
        return emptyCount == 0;
    }

    public bool IsFinished() {
        bool sameRow, sameCol, sameDiagonal;


        for (int row=0; row < Size; row++) {
            sameRow = sameCol = true;

            for (int col = 0; col < Size - 1; col++) {
                if (Grid[row, col] != Grid[row, col + 1] || Grid[row, col] == 0)
                    sameRow = false;

                if (Grid[col, row] != Grid[col + 1, row] || Grid [row, col] == 0)
                    sameCol = false;
            }
            if (sameRow || sameCol)
                return true;

        }

        sameDiagonal = true;
        for (int i=0; i < Size - 1; i++)
            if (Grid[i, i] != Grid[i + 1, i + 1] || Grid [i, i] == 0)
                sameDiagonal = false;

        if (sameDiagonal)
            return true;

        sameDiagonal = true;
        for (int i=0; i < Size - 1; i++)
            if (Grid [i, i] != Grid [i + 1, i + 1] || Grid [i, i] == 0)
                sameDiagonal = false;

        return sameDiagonal;
    }
}