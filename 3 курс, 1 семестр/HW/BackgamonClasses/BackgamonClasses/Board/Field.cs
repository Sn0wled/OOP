namespace BackgamonClasses.Board;

public class Field
{
    public int Count { get; private set; } = 0;
    public Color Color { get; private set; } = Color.None;
    public void Push(Color color)
    {
        if (Color == color || Color == Color.None)
        {
            Color = color;
            Count++;
        }
    }
    public Color Pop()
    {
        if (Count > 0)
        {
            Count--;
            if (Count == 0)
            {
                Color temp = Color;
                Color = Color.None;
                return temp;
            }
        }
        return Color.None;
    }
}

public enum Color
{
    Black,
    White,
    None
}