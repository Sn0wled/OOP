using System.Text;

namespace Backgammon;

internal class Board
{
    const int fieldsCount = 24;
    const int blackStartFieldIndex = 11;
    const int whiteStartFieldIndex = 23;
    const int checkerCount = 15;
    Field[] fields = new Field[fieldsCount];
    public FieldInfo this[int n] { get { return new(fields[n]); } }
    public int FieldsCount { get { return fieldsCount; } }
    public Board()
    {
        for (int i = 0; i < blackStartFieldIndex; i++)
        {
            fields[i] = new Field();
        }
        fields[blackStartFieldIndex] = new Field(Color.Black, checkerCount);
        for (int i = blackStartFieldIndex + 1; i < whiteStartFieldIndex; i++)
        {
            fields[i] = new Field();
        }
        fields[whiteStartFieldIndex] = new Field(Color.White, checkerCount);
    }
    public MoveResult Move(int from, int to)
    {
        if (to < from) return MoveResult.ToLessThanFrom;
        if (from < 0 || to < 0) return MoveResult.FromOrToLessThanZero;
        if (from > 23 || to > 23) return MoveResult.FromOrToMoreThan23;
        Color? fromFieldColor = fields[from].Color;
        if (fromFieldColor == null) return MoveResult.FromFieldIsEmpty;
        if (fromFieldColor == fields[to].Color || fields[to].Color == null)
        {
            fields[to].Push(fields[from].Pop()!);
            return MoveResult.MoveSuccess;
        }
        return MoveResult.ImpossibleMove;
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 12; i < 24; i++)
        {
            sb.Append(fields[i] + "\t");
        }
        sb.Append("\n\n");
        for (int i = 11; i >= 0; i--)
        {
            sb.Append(fields[i] + "\t");
        }
        return sb.ToString();
    }
    public bool IsStepPossible(int from, int to)
    {
        if (to < from) return false;
        if (from < 0 || to < 0) return false;
        if (from > 23 || to > 23) return false;
        Color? fromFieldColor = fields[from].Color;
        if (fromFieldColor == null) return false;
        if (fromFieldColor == fields[to].Color || fields[to].Color == null)
        {
            return true;
        }
        return false;
    }
}

enum MoveResult
{
    ToLessThanFrom,
    FromOrToLessThanZero,
    FromOrToMoreThan23,
    FromFieldIsEmpty,
    ImpossibleMove,
    MoveSuccess
}