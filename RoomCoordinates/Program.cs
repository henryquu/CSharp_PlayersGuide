Coordinate a = new Coordinate(1, 2);
Coordinate b = new Coordinate(4, 1);

Console.WriteLine(a.IsAdjacent(b));

public struct Coordinate {
    readonly int Row;
    readonly int Col;

    public Coordinate(int row, int col) {
        Row = row;
        Col = col;
    }

    public bool IsAdjacent(Coordinate other) {
        if (Math.Abs(Row - other.Row) <= 1 || Math.Abs(Col - other.Col) <= 1)
            return true;
        return false;
    }
}