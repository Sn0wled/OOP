namespace BackgamonClasses.Game;
using BackgamonClasses.Board;

internal class Dices
{
    Dice[] dices = new Dice[2];

    public int DiceCount { get; } = 2;
    public List<int> PosibleStepLengths { get; } = new List<int>();
    public Dice this[int n] { get { return dices[n]; } }
    public bool AreSame { get { return dices[0].Value == dices[1].Value; } }

    public Dices()
    {
        for (int i = 0; i < dices.Length; i++)
        {
            dices[i] = new();
        }
    }

    public void RollDices(out int ableToRemoveFromBase)
    {
        for (int i = 0; i < dices.Length; i++)
        {
            dices[i].Roll();
        }
        PosibleStepLengths.Clear();
        if (AreSame)
        {
            for (int i = 0; i < 4; i++)
            {
                PosibleStepLengths.Add(dices[0].Value);
            }
            ableToRemoveFromBase = 2;
        }
        else
        {
            PosibleStepLengths.Add(dices[0].Value);
            PosibleStepLengths.Add(dices[1].Value);
            ableToRemoveFromBase = 1;
        }
    }

    public bool DelLength(int length)
    {
        return PosibleStepLengths.Remove(length);
    }
}
