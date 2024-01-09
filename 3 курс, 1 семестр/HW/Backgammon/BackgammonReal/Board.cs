namespace Backgammon;

internal class Board
{
    const int fieldsCount = 24;
    const int blackStartFieldIndex = 11;
    const int whiteStartFieldIndex = 23;
    const int checkerCount = 15;
    Field[] fields = new Field[fieldsCount];
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
}
