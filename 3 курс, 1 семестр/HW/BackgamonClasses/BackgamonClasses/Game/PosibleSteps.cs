namespace BackgamonClasses.Game;
using BackgamonClasses.Board;

internal class PosibleSteps
{
    bool[,] steps;
    int fieldCount;
    public PosibleSteps(in Board board, in Color currentPlayer, in List<int> posibleStepLengths)
    {
        fieldCount = board.FieldsCount;
        steps = new bool[fieldCount, fieldCount];
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

    public void FindSteps(in Board board, in Color currentPlayer, in List<int> posibleStepLengths)
    {
        InitFalse();

    }
}
