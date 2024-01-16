namespace Backgammon;

internal class Field
{
    Stack<Checker> checkersOnField = new Stack<Checker>();
    public Color? Color { get
        {
            Checker checker;
            try
            {
                checker = checkersOnField.Peek();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            return checker.Color;
        } }
    public int Count { get {  return checkersOnField.Count; } }
    public Field() { }
    public Field(Color color, int count)
    {
        for (int i = 0; i < count; i++)
        {
            checkersOnField.Push(new Checker(color));
        }
    }
    public bool Push(Checker checker)
    {
        if (checkersOnField.Count > 0 && checkersOnField.Peek().Color != checker.Color)
            return false;
        checkersOnField.Push(checker);
        return true;
    }
    public Checker? Top()
    {
        try
        {
            return checkersOnField.Peek();
        }
        catch (InvalidOperationException)
        { return null; }
    }
    public Checker? Pop()
    {
        try
        {
            return checkersOnField.Pop();
        }
        catch (InvalidOperationException)
        { return null; }
    }
    public override string ToString()
    {
        return $"{Count,2} {Color, 5}";
    }
}

class FieldInfo
{
    int Count { get; init; }
    Color? Color { get; init; }
    public FieldInfo(Field field)
    {
        Count = field.Count;
        Color = field.Color;
    }
}