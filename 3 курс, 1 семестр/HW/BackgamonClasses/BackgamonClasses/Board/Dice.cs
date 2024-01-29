namespace BackgamonClasses.Board;

public class Dice
{
    Random rnd = new Random();
    public int Value { get; private set; } = 6;
    public void Roll() => Value = rnd.Next(1, 7);
}
