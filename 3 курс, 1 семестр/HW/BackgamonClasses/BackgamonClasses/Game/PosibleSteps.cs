namespace BackgamonClasses.Game;
using BackgamonClasses.Board;

internal class PosibleSteps
{
    bool[,] steps;
    int fieldCount;

    public bool this[int i, int j] { get { return steps[i, j]; } }

    public bool this[int n]
    {
        get
        {
            for (int i = 0; i < fieldCount + 1; i++)
            {
                if (steps[n, i]) return true;
            }
            return false;
        }
    }

    public PosibleSteps(in Board board, in Color currentPlayer, in List<int> posibleStepLengths)
    {
        fieldCount = board.FieldsCount;
        steps = new bool[fieldCount, fieldCount + 1];
        InitFalse();
    }

    void InitFalse()
    {
        for (int i = 0; i < fieldCount; i++)
        {
            for (int j = 0; j < fieldCount; j++)
            {
                steps[i, j] = false;
            }
        }
    }

    public void FindSteps(in Board board, in Color currentPlayer, in List<int> posibleStepLengths, in int ableToRemoveFromBase)
    {
        InitFalse();

    }
}
