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
    List<int> posibleStepLengths;
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
    }

    public bool tryMove(int from, int to)
    {
    }

    void Throw(int from)
    {
        board[from].Pop();
    }
    void RollDices()
    {

    }
}