namespace BackgamonClasses.Game;
using BackgamonClasses.Board;

public delegate Color moveDlg();

public class Backgamon
{
    public const int fieldCount = 24;
    const int whiteBase = 0;
    const int blackBase = 12;
    const int checkersCount = 15;

    Board board;
    Dices dices = new();
    int ableToRemoveFromBase = 0;
    PosibleSteps posibleSteps;

    public Color currentColor { get; private set; }

    public event moveDlg MoveEnded;

    public Backgamon()
    {
        InitGame();
    }

    public void InitGame()
    {
        board = new(fieldCount);
        for (int i = 0; i < checkersCount; i++)
        {
            board[whiteBase].Push(Color.White);
            board[blackBase].Push(Color.Black);
        }
        currentColor = Color.White;
        posibleSteps = new(board, currentColor, dices.PosibleStepLengths);
    }

    public bool tryMove(int from, int to)
    {
        if (posibleSteps[from, to])
        {
            if (to == fieldCount)
            {
                Throw(from);
            }
            else
            {
                Move(from, to);
                if 
            }

            posibleSteps.FindSteps(board, )
            return true;
        }
        return false;
    }

    void Move(int from, int to)
    {
        Color checker = board[from].Pop();
        board[to].Push(checker);
        dices.DelLength((to - from) % fieldCount);
    }

    void Throw(int from)
    {
        board[from].Pop();
        if (currentColor == Color.White)
        {
            dices.DelLength((whiteBase - from) % fieldCount);
        }
        else
        {
            dices.DelLength((blackBase - from) % fieldCount);
        }
    }
    void RollDices()
    {

    }
}