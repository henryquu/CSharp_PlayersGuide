


class Point {
    public float x { get; set; }
    public float y { get; set; }

    public Point(float X, float Y) {
        x = X;
        y = Y;
    }
    public Point() {
        x = 0;
        y = 0;
    }
    
}

class Color {
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }

    public static Color White = new (255, 255, 255);
    public static Color Black = new (0, 0, 0);
    public static Color Red = new (255, 0, 0);
    public static Color Orange  = new (255, 165, 0);
    public static Color Yellow = new (255, 255, 0);
    public static Color Green = new (0, 255, 0);
    public static Color Blue  = new (0, 0, 255);
    public static Color Purple = new (128, 0, 128);


    public Color(byte red, byte green, byte blue) {
        R = red;
        G = green;
        B = blue;
    }       
}

class Card {
    Color color { get; };
}
