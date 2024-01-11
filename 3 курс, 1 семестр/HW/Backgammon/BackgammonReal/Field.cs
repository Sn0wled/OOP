namespace Backgammon;

internal class Field
{
    Stack<Checker> checkersOnField = new Stack<Checker>();
    public Color? Color { get { return checkersOnField.Peek().Color; } }
    public Field() { }
    public Field(Color color, int count) {
        for (int i = 0; i < count; i++)
        {
            checkersOnField.Push(new Checker(color));
        }
    }
}
