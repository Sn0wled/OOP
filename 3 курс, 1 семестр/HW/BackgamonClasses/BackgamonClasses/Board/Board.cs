namespace BackgamonClasses.Board;

public class Board
{
    Field[] fields;
    public int FieldsCount { get; }
    public Field this[int inex] { get { return fields[inex]; } }
    public Board(int fieldCount)
    {
        FieldsCount = fieldCount;
        fields = new Field[fieldCount];
        for (int i = 0; i < fields.Length; i++)
        {
            fields[i] = new Field();
        }
    }
}
