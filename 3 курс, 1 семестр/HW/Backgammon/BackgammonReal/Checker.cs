namespace Backgammon;

internal class Checker {
    Color color;
    public Color Color { get { return color; } }
    public Checker(Color color)
    {
        this.color = color;
    }
}

enum Color {
    White,
    Black
}
