using System.Drawing;

Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow };
Rank[] ranks = new Rank[] { 
    Rank.One, Rank.Two, 
    Rank.Three, Rank.Four, 
    Rank.Five, Rank.Six, 
    Rank.Seven, Rank.Eight, 
    Rank.Nine, Rank.Ten, 
    Rank.DollarSign, Rank.Percent, 
    Rank.Caret, Rank.Ampersand 
};

Card a;

foreach (Rank rank in ranks) {
    foreach (Color color in colors) {
        a = new Card(rank, color);
        Console.WriteLine($"The {a.Color} {a.Rank}");
    }
}


class Card {
    public Color Color { get; }
    public Rank Rank { get; }
    
    public bool isSymbol() {
        return Rank == Rank.DollarSign | Rank == Rank.Percent | Rank == Rank.Caret | Rank == Rank.Ampersand;
    }

    public bool isNumber() {
        return !isSymbol();
    }

    public Card(Rank rank, Color color) {
        Color = color;
        Rank = rank;
    }
}

enum Color { Red, Green, Blue, Yellow }
enum Rank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, DollarSign, Percent, Caret, Ampersand }